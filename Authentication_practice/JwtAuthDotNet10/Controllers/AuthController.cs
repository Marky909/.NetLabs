using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JwtAuthDotNet10.Data;
using JwtAuthDotNet10.Entities;
using Microsoft.AspNetCore.Identity;
using JwtAuthDotNet10.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthDotNet10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(UserDbContext _context ) : ControllerBase
    {
        private readonly PasswordHasher<User> _passwordHasher = new();

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDTO request)
        {
            if(await _context.Users.AnyAsync(u=>u.UserName==request.UserName))
            {
                return BadRequest("Username is already taken ");
            }

            var user = new User
            {
                UserName = request.UserName
            };

            //hash the plain password
            user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return Ok(new { message = "user registered successfully!", UserId = user.Id });
        }

        [HttpPost("login")]
        public async Task<ActionResult<String>> Login(UserDTO request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == request.UserName);
            if(user is null)
            {
                return BadRequest("Invalid Username or password");
            }

            var VerificationResult = _passwordHasher.VerifyHashedPassword(
                user,
                user.PasswordHash,
                request.Password
                );
            if (VerificationResult == PasswordVerificationResult.Failed)
                return BadRequest("Invalid Username or password");

            return Ok("Login Successfull! Identity Confirmed");
        }
    }
}
