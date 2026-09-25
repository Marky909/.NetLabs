using EcommerceApi.Data;
using EcommerceApi.Helpers;
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
    }
}
