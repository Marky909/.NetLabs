using EcommerceApi.Data;
using EcommerceApi.DTOs;
using EcommerceApi.Helpers;
using EcommerceApi.Models;
using EcommerceApi.Services;
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

        private readonly ICurrentUserService _currentUser;

        private readonly IOrderService _orderService;


        public OrdersController(EcommerceDbContext context,ICurrentUserService currentUser,IOrderService orderService)
        {
            _context = context;
            _currentUser = currentUser;
            _orderService = orderService;
        }
        [Authorize]
        [HttpPost("checkout")]
        public async Task<ActionResult> Checkout()
        {
            try
            {
                var orderId = await _orderService.CheckOutAsync();
                return Ok(new {
                    message = "Order Created Successfully",
                    orderId
                });
            }
            catch(UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch(InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> GetMyOrders()
        {
            var userId = _currentUser.UserId;

            if (userId == null)
            {
                return Unauthorized();
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

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponse>> GetOrder(int id)
        {
            var userId = _currentUser.UserId;

            if (userId == null)
            {
                return Unauthorized();
            }


            var order = await _context.Orders
                .AsNoTracking()
                .Where(o => o.Id == id && o.UserId == userId.Value)
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
            var userId = _currentUser.UserId;

            if (userId == null)
            {
                return Unauthorized();
            }


            var seller = await _context.Sellers
                .FirstOrDefaultAsync(s => s.UserId == userId.Value);

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
            var userId = _currentUser.UserId;

            if (userId == null)
                return Unauthorized("seller is not authorized");

            var seller = await _context.Sellers.FirstOrDefaultAsync(s => s.UserId == userId.Value);
            if (seller == null)
                return NotFound("seller profile not Found");

            var orderItem = await _context.OrderItems
                               .Include(oi => oi.Product)
                               .FirstOrDefaultAsync(oi => oi.Id == orderItemId && oi.Product.SellerId == seller.Id);

            if (orderItem == null)
                return NotFound("Order item not found");

            if(!OrderStatusRules.CanTransition(orderItem.Status,request.Status))
            {
                return BadRequest($"Can't transit from {orderItem.Status} to {request.Status}");
            }


            orderItem.Status = request.Status;

            await _context.SaveChangesAsync();



            return Ok(new
            {
                message="Order Item Status updated successfully",
                orderItemId=orderItem.Id,
                status = orderItem.Status
            });
        }

        [Authorize(Roles ="Admin")]
        [HttpGet("admin")]
        public async Task<ActionResult<IEnumerable<AdminOrderResponse>>> GetAllOrders()
        {
            var orders = await _context.Orders
                .AsNoTracking()
                .Select(o => new AdminOrderResponse
                {
                    OrderId = o.Id,
                    UserId = o.UserId,
                    OrderDate = o.OrderDate,
                    Items = o.Items.Select(oi => new AdminOrderItemResponse
                    {
                        OrderItemId = oi.Id,
                        ProductName = oi.Product.Name,
                        SellerName = oi.Product.Seller.StoreName,
                        Quantity = oi.Quantity,
                        UnitPrice = oi.UnitPrice,
                        Status = oi.Status
                    }).ToList()
                })
                .ToListAsync();

            return Ok(orders);
        }

    }
}
