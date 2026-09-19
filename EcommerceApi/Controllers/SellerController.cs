using EcommerceApi.Data;
using EcommerceApi.DTOs;
using EcommerceApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace EcommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController(EcommerceDbContext _context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seller>>> GetSellers()
        {
            var sellers =await _context.Sellers
                .AsNoTracking()
                .Select(s => new SellerResponse
                {
                    Id = s.Id,
                    StoreName = s.StoreName
                })
                .ToListAsync();

            return Ok(sellers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Seller>>> GetSellers(int id)
        {
            var seller =await _context.Sellers
                .AsNoTracking()
                .Where(s => s.Id == id)
                .Select(s => new SellerResponse
                {
                    Id = s.Id,
                    StoreName = s.StoreName
                })
                .FirstOrDefaultAsync();
            if (seller == null)
                return NotFound($"The seller with {id} doesnt exist");

            return Ok(seller);
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<SellerResponse>> CreateSeller(CreateSellerRequest request)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized();

            var userId = int.Parse(userIdClaim.Value);

            var user=await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return BadRequest("User Not found!");
            }

            var existingSeller = await _context.Sellers.AnyAsync(s => s.UserId == userId);
            if (existingSeller)
                return BadRequest("User is already a seller");


            var seller = new Seller
            {
                StoreName = request.StoreName,
                UserId = userId
            };

            _context.Sellers.Add(seller);

            user.Role = "Seller";
            await _context.SaveChangesAsync();
            var response = new SellerResponse
            {
                Id = seller.Id,
                StoreName = seller.StoreName
            };

            return Ok(response);
        }
    }
}
