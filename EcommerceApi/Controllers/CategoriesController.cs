using EcommerceApi.Data;
using EcommerceApi.DTOs;
using EcommerceApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(EcommerceDbContext _context) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _context.Categories
                .AsNoTracking()
                .Select(c => new CategoryResponse
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategory(int id)
        {
            var category = await _context.Categories.Select(c => new CategoryResponse
            {
                Id = c.Id,
                Name = c.Name
            })
                .FirstOrDefaultAsync(c=>c.Id==id);

            if (category == null)
                return NotFound("category doesnt exist");

            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategory(int id,CreateCategoryRequest request)
        {
            var category = new Category
            {
                Name = request.Name
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            var response = new CategoryResponse
            {
                Id = category.Id,
                Name = category.Name
            };

            return Ok(response);
        }
    }
}
