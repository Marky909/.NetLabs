using EcommerceApi.Data;
using EcommerceApi.DTOs;
using EcommerceApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EcommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly EcommerceDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IConfiguration _configuration;


        public AuthController(EcommerceDbContext context,IPasswordHasher<User> passwordHasher,IConfiguration configuration)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
        }


        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterRequest request)
        {
            bool existingUser = await _context.Users.AnyAsync(u => u.Email == request.Email);
            if (existingUser)
                return BadRequest("Email is already Registered");
            User user = new User
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

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginRequest request)
        {
            User? user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            PasswordVerificationResult result = _passwordHasher.VerifyHashedPassword(
                user,
                user.PasswordHash,
                request.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                return Unauthorized("Invalid email or password.");
            }

           

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Username),
                new Claim(ClaimTypes.Role,user.Role),
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:key"]!));

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: credentials
                );

            string jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new 
            {
                token = jwt
            });
        }
        [Authorize]
        [HttpGet("protected")]
        public IActionResult Protected()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var username = User.FindFirst(ClaimTypes.Name)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            return Ok(new
            {
                userId,
                username,
                role
            });
        }

    }
}
