using EcommerceApi.Data;
using EcommerceApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcommerceApi.DTOs;
using Microsoft.AspNetCore.Authorization;
namespace EcommerceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController(EcommerceDbContext _context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> Getproducts()
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

                })
                .ToListAsync();
            return Ok(products);
        }

        //[HttpPost("Product")]
        //public async Task<ActionResult<Product>> AddProduct(CreateProductRequest request)
        //{
        //    var product = new Product()
        //    {
        //        Name = request.Name,
        //        Price = request.Price,
        //        Stock = request.Stock,
        //        SellerId = request.SellerId,
        //        CategoryId = request.CategoryId
        //    };
        //    _context.Products.Add(product);
        //    await _context.SaveChangesAsync();

        //    return Ok(product);
        //}

        [HttpPost("User")]
        public async Task<ActionResult<User>> AddUser([FromBody] User newUser)
        {
            
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return Ok(newUser);
        }

        [HttpPost("Seller")]
        public async Task<ActionResult<Seller>> AddSeller(CreateSellerRequest request)
        {
            var seller = new Seller()
            {
                StoreName = request.StoreName,
                UserId= request.UserId
            };
            _context.Sellers.Add(seller);
            await _context.SaveChangesAsync();

            return Ok(seller);
        }

        [HttpPost("category")]
        public async Task<ActionResult<Category>> AddCategory(
            CreateCategoryRequest request)
        {
            var category = new Category()
            {
                Name = request.Name
            };
            _context.Categories.Add(category);

            await _context.SaveChangesAsync();

            return Ok(category);
        }
        [Authorize]
        [HttpGet("protected")]
        public IActionResult Protected()
        {
            return Ok("You are authenticated.");
        }
    }
}
