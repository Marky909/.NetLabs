using EcommerceApi.Data;
using EcommerceApi.DTOs;
using EcommerceApi.Helpers;
using EcommerceApi.Models;
using EcommerceApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Validation;
using System.Linq.Expressions;
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
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<OrderResponse>>> GetMyOrders()
        {
            try
            {
                var orders =await _orderService.GetMyOrdersAsync();
                return Ok(orders);
            }
            catch(UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponse>> GetOrder(int id)
        {
            try
            {
                var order = _orderService.GetMyOrderAsync(id);
                return Ok(order);
            }
            catch(UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }

        [Authorize(Roles = "Seller")]
        [HttpGet("seller")]
        public async Task<ActionResult<List<SellerOrderItemResponse>>> GetSellerOrders()
        {
            try
            {
                var items = await _orderService.GetSellerOrdersAsync();

                return Ok(items);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [Authorize(Roles ="Seller")]
        [HttpPut("Seller/items/{orderItemId}/status")]
        public async Task<ActionResult> UpdateOrderItemStatus(int orderItemId,UpdateOrderItemStatusRequest request)
        {
            try
            {
                await _orderService.UpdateOrderItemStatusAsync(orderItemId, request.Status);
                return Ok(new
                {
                    message = "Order Item status updated successfully.",
                    orderItemId,
                    status=request.Status
                });
            }
            catch(UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public async Task<ActionResult<List<AdminOrderResponse>>> GetAllOrders()
        {
            var orders = await _orderService.GetAdminOrdersAsync();

            return Ok(orders);
        }

    }
}
