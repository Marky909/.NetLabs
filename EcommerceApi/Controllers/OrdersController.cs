using EcommerceApi.Data;
using EcommerceApi.DTOs;
using EcommerceApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EcommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly EcommerceDbContext _context;

        public OrdersController(EcommerceDbContext context)
        {
            _context = context;
        }
        [Authorize]
        [HttpPost("checkout")]
        public async Task<ActionResult> Checkout()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            var userId = int.Parse(userIdClaim.Value);

            var cart = await _context.Carts
                .Include(c => c.Items)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null || !cart.Items.Any())
            {
                return BadRequest("Cart is empty.");
            }

            foreach (var item in cart.Items)
            {
                if (item.Quantity > item.Product.Stock)
                {
                    return BadRequest(
                        $"Not enough stock for {item.Product.Name}.");
                }
            }

            await using var transaction =
                await _context.Database.BeginTransactionAsync();

            try
            {
                var order = new Models.Order
                {
                    UserId = userId,
                    OrderDate = DateTime.UtcNow,
                    Status = "Pending"
                };

                _context.Orders.Add(order);

                foreach (var item in cart.Items)
                {
                    var orderItem = new Models.OrderItem
                    {
                        Order = order,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.Product.Price
                    };

                    _context.OrderItems.Add(orderItem);

                    item.Product.Stock -= item.Quantity;
                }

                _context.CartItems.RemoveRange(cart.Items);

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return Ok(new
                {
                    message = "Order created successfully.",
                    orderId = order.Id
                });
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> GetMyOrders()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            var userId = int.Parse(userIdClaim.Value);

            var orders = await _context.Orders
                .AsNoTracking()
                .Where(o => o.UserId == userId)
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

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponse>> GetOrder(int id)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            var userId = int.Parse(userIdClaim.Value);

            var order = await _context.Orders
                .AsNoTracking()
                .Where(o => o.Id == id && o.UserId == userId)
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

            if (order == null)
            {
                return NotFound("Order not found.");
            }

            return Ok(order);
        }

        [Authorize(Roles = "Seller")]
        [HttpGet("seller")]
        public async Task<ActionResult<IEnumerable<SellerOrderItemResponse>>> GetSellerOrders()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            var userId = int.Parse(userIdClaim.Value);

            var seller = await _context.Sellers
                .FirstOrDefaultAsync(s => s.UserId == userId);

            if (seller == null)
            {
                return NotFound("Seller profile not found.");
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

            return Ok(items);
        }


        [Authorize(Roles ="Seller")]
        [HttpPut("Seller/items/{orderItemId}/status")]
        public async Task<ActionResult> UpdateOrderItemStatus(int orderItemId,UpdateOrderItemStatusRequest request)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized("seller is not authorized");
            var userId = int.Parse(userIdClaim.Value);

            var seller = await _context.Sellers.FirstOrDefaultAsync(s => s.UserId == userId);
            if (seller == null)
                return NotFound("seller profile not Found");

            var orderItem = await _context.OrderItems
                               .Include(oi => oi.Product)
                               .FirstOrDefaultAsync(oi => oi.Id == orderItemId && oi.Product.SellerId == seller.Id);

            if (orderItem == null)
                return NotFound("Order item not found");

            var allowedStatuses = new[]
            {
                "Pending",
                "Processing",
                "Shipped",
                "Delivered",
                "Cancelled"
            };

            if (!allowedStatuses.Contains(request.Status))
                return BadRequest("Invalid Order Status");

            orderItem.Status = request.Status;

            await _context.SaveChangesAsync();



            return Ok(new
            {
                message="Order Item Status updated successfully",
                orderItemId=orderItem.Id,
                status = orderItem.Status
            });
        }

    }
}
