using EcommerceApi.Data;
using EcommerceApi.DTOs;
using EcommerceApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController(EcommerceDbContext _context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seller>> GetSellers()
        {
            var sellers = _context.Sellers
                .AsNoTracking()
                .Select(s => new SellerResponse
                {
                    Id = s.Id,
                    StoreName = s.StoreName
                })
                .ToListAsync();

            return Ok(sellers);
        }
    }
}
