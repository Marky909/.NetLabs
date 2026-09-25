using EcommerceApi.Data;
using EcommerceApi.DTOs;
using EcommerceApi.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Services
{
    public class OrderService:IOrderService
    {
        private readonly EcommerceDbContext _context;
        private readonly ICurrentUserService _currentUser;

        public OrderService(
            EcommerceDbContext context,
            ICurrentUserService currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<int> CheckOutAsync()
        {
            var userId = _currentUser.UserId;

            if (userId == null)
            {
                throw new UnauthorizedAccessException();
            }

            var cart = await _context.Carts
                .Include(c => c.Items)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId.Value);

            if (cart == null || !cart.Items.Any())
            {
                throw new InvalidOperationException("Cart is empty.");
            }

            foreach (var item in cart.Items)
            {
                if (item.Quantity > item.Product.Stock)
                {
                    throw new InvalidOperationException(
                        $"Not enough stock for {item.Product.Name}.");
                }
            }

            await using var transaction =
                await _context.Database.BeginTransactionAsync();

            try
            {
                var order = new Models.Order
                {
                    UserId = userId.Value,
                    OrderDate = DateTime.UtcNow,
                    Status = OrderStatus.Pending
                };

                _context.Orders.Add(order);

                foreach (var item in cart.Items)
                {
                    var orderItem = new Models.OrderItem
                    {
                        Order = order,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.Product.Price,
                        Status = OrderStatus.Pending
                    };

                    _context.OrderItems.Add(orderItem);

                    item.Product.Stock -= item.Quantity;
                }

                _context.CartItems.RemoveRange(cart.Items);

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return order.Id;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<List<OrderResponse>> GetMyOrdersAsync()
        {
            var userId = _currentUser.UserId;

            if (userId == null)
            {
                throw new UnauthorizedAccessException();
            }

            var orders = await _context.Orders
                .AsNoTracking()
                .Where(o => o.UserId == userId.Value)
                .Select(o => new OrderResponse
                {
                    Id = o.Id,
                    OrderDate = o.OrderDate,
                    Status = o.Status,

                    TotalAmount = o.Items.Sum(oi =>
                        oi.Quantity * oi.UnitPrice),

                    Items = o.Items.Select(oi => new OrderItemResponse
                    {
                        ProductId = oi.ProductId,
                        ProductName = oi.Product.Name,
                        Quantity = oi.Quantity,
                        UnitPrice = oi.UnitPrice
                    }).ToList()
                })
                .ToListAsync();

            return orders;
        }
        public async Task<OrderResponse?> GetMyOrderAsync(int orderId)

        {
            var userId = _currentUser.UserId;

            if (userId == null)
            {
                throw new UnauthorizedAccessException();
            }


            var order = await _context.Orders
                .AsNoTracking()
                .Where(o => o.Id == orderId && o.UserId == userId.Value)
                .Select(o => new OrderResponse
                {
                    Id = o.Id,
                    OrderDate = o.OrderDate,
                    Status = o.Status,

                    TotalAmount = o.Items.Sum(oi =>
                        oi.Quantity * oi.UnitPrice),

                    Items = o.Items.Select(oi => new OrderItemResponse
                    {
                        ProductId = oi.ProductId,
                        ProductName = oi.Product.Name,
                        Quantity = oi.Quantity,
                        UnitPrice = oi.UnitPrice
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            return order;
        }

        public async Task<List<SellerOrderItemResponse>> GetSellerOrdersAsync()
        {
            var userId = _currentUser.UserId;

            if (userId == null)
            {
                throw new UnauthorizedAccessException();
            }

            var seller = await _context.Sellers
                .FirstOrDefaultAsync(s => s.UserId == userId.Value);

            if (seller == null)
            {
                throw new KeyNotFoundException("Seller profile not found.");
            }

            var items = await _context.OrderItems
                .AsNoTracking()
                .Where(oi => oi.Product.SellerId == seller.Id)
                .Select(oi => new SellerOrderItemResponse
                {
                    OrderId = oi.OrderId,
                    OrderItemId = oi.Id,
                    ProductName = oi.Product.Name,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice,
                    Status = oi.Status,
                    OrderDate = oi.Order.OrderDate
                })
                .ToListAsync();

            return items;
        }
        public async Task UpdateOrderItemStatusAsync(
                int orderItemId,
                string newStatus)
        {
            var userId = _currentUser.UserId;

            if (userId == null)
            {
                throw new UnauthorizedAccessException();
            }

            var seller = await _context.Sellers
                .FirstOrDefaultAsync(s => s.UserId == userId.Value);

            if (seller == null)
            {
                throw new KeyNotFoundException(
                    "Seller profile not found.");
            }

            var orderItem = await _context.OrderItems
                .Include(oi => oi.Product)
                .FirstOrDefaultAsync(
                    oi => oi.Id == orderItemId &&
                          oi.Product.SellerId == seller.Id);

            if (orderItem == null)
            {
                throw new KeyNotFoundException(
                    "Order item not found.");
            }

            if (!OrderStatusRules.CanTransition(
                    orderItem.Status,
                    newStatus))
            {
                throw new InvalidOperationException(
                    $"Can't transition from {orderItem.Status} to {newStatus}.");
            }

            orderItem.Status = newStatus;

            await _context.SaveChangesAsync();
        }
        

    }
}
