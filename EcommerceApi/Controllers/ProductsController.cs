using EcommerceApi.Data;
using EcommerceApi.DTOs;
using EcommerceApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EcommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly EcommerceDbContext _context;

        public ProductsController(EcommerceDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetProducts()
        {
            var products = await _context.Products
                .AsNoTracking()
                .Select(p => new ProductResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Stock = p.Stock,
                    Seller = new SellerResponse
                    {
                        Id = p.Seller.Id,
                        StoreName = p.Seller.StoreName
                    },
                    Category = new CategoryResponse
                    {
                        Id = p.Category.Id,
                        Name = p.Category.Name
                    }
                }).ToListAsync();
            return Ok(products);
        }
        [Authorize(Roles = "Seller")]
        [HttpPost]
        public async Task<ActionResult> CreateProduct(CreateProductRequest request)
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
                return BadRequest("Seller profile not found.");
            }

            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
                SellerId = seller.Id,
                CategoryId = request.CategoryId
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }

        [Authorize(Roles="seller")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id,UpdateProductRequest request)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized();
            var UserId = int.Parse(userIdClaim.Value);

            var product = await _context.Products
                .Include(p => p.Seller)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return NotFound("product not found");

            if (product.Seller.UserId != UserId)
                return Forbid();

            product.Name = request.Name;
            product.Price = request.Price;
            product.Stock = request.Stock;
            product.CategoryId = request.CategoryId;
            await _context.SaveChangesAsync();

            return Ok(product);
        }

        [Authorize(Roles = "Seller")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            var userId = int.Parse(userIdClaim.Value);

            var product = await _context.Products
                .Include(p => p.Seller)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound("Product not found.");
            }

            if (product.Seller.UserId != userId)
            {
                return Forbid();
            }

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
