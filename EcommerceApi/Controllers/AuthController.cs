using EcommerceApi.Data;
using EcommerceApi.DTOs;
using EcommerceApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly EcommerceDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;


        public AuthController(EcommerceDbContext context,IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }


        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterRequest request)
        {
            var existingUser = await _context.Users.AnyAsync(u => u.Email == request.Email);
            if (existingUser)
                return BadRequest("Email is already Registered");
            var user = new User
            {
                Username=request.Username,
                Email=request.Email
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);


            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok( new
               { message = "User registered successfully",
                user.Id,
                user.Username,
                user.Email,
                user.Role }
                );

        }
    }
}
