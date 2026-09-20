using Azure.Core;
using EcommerceApi.Data;
using EcommerceApi.DTOs;
using EcommerceApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Security.Claims;

namespace EcommerceApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CartController : ControllerBase
{
    private readonly EcommerceDbContext _context;

    public CartController(EcommerceDbContext context)
    {
        _context = context;
    }

    [HttpPost("items")]
    public async Task<ActionResult> AddToCart(AddToCartRequest request)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
            return Unauthorized();

        var userId = int.Parse(userIdClaim.Value);

        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.ProductId);
        if (product == null)
            return NotFound("Product not Found");

        if (product.Stock < request.Quantity)
            return BadRequest("Not enough stock available");

        var cart = await _context.Carts.FirstOrDefaultAsync(c => c.Id == userId);
        if (cart == null)
        {
            cart = new Cart
            {
                UserId = userId
            };
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
        }

        var cartItem = await _context.CartItems.FirstOrDefaultAsync(ci => ci.CartId == cart.Id && ci.ProductId == request.ProductId);

        if (cartItem != null)
        {
            if (cartItem.Quantity + request.Quantity > product.Stock)
                return BadRequest("Requested quantity exceeds available stock");

            cartItem.Quantity += request.Quantity;
        }
        else
        {
            cartItem = new CartItem
            {
                CartId = cart.Id,
                ProductId = request.ProductId,
                Quantity = request.Quantity

            };

        }
        _context.CartItems.Add(cartItem);
        await _context.SaveChangesAsync();

        return Ok(cartItem);
    }

    [HttpGet]
    public async Task<ActionResult<CartResponse>> GetMycart()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
            return Unauthorized();

        var userId = int.Parse(userIdClaim.Value);


        CartResponse? cart = await _context.Carts
        .AsNoTracking()
        .Where(c => c.UserId == userId)
        .Select(c => new CartResponse
        {
            CartId = c.Id,

            Items = c.Items.Select(ci => new CartItemResponse
            {
                ProductId = ci.ProductId,
                ProductName = ci.Product.Name,
                Price = ci.Product.Price,
                Quantity = ci.Quantity
            }).ToList()
        })
        .FirstOrDefaultAsync();
        if (cart == null)
        {
            return NotFound("Cart not found.");
        }

        return Ok(cart);

    }

    [HttpPut("item/{productId}")]
    public async Task<ActionResult> UpdateCartItem(int productId, UpdateCartItemRequest request)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
            return Unauthorized();

        var userId = int.Parse(userIdClaim.Value);
        var cartItem = await _context.CartItems
               .Include(ci => ci.Cart)
               .Include(ci => ci.Product)
               .FirstOrDefaultAsync(ci =>
                   ci.ProductId == productId &&
                   ci.Cart.UserId == userId);

        if (cartItem == null)
        {
            return NotFound("Cart item not found.");
        }

        if (request.Quantity > cartItem.Product.Stock)
        {
            return BadRequest("Not enough stock available.");
        }

        cartItem.Quantity = request.Quantity;

        await _context.SaveChangesAsync();

        return Ok(cartItem);
    }
    [HttpDelete("items/{productId}")]
    public async Task<ActionResult> RemoveCartItem(int productId)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

        if (userIdClaim == null)
        {
            return Unauthorized();
        }

        var userId = int.Parse(userIdClaim.Value);

        var cartItem = await _context.CartItems
            .Include(ci => ci.Cart)
            .FirstOrDefaultAsync(ci =>
                ci.ProductId == productId &&
                ci.Cart.UserId == userId);

        if (cartItem == null)
        {
            return NotFound("Cart item not found.");
        }

        _context.CartItems.Remove(cartItem);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}
