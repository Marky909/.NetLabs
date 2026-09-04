using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JwtAuthDotNet10.Data;
using JwtAuthDotNet10.Entities;
using Microsoft.AspNetCore.Identity;
using JwtAuthDotNet10.Models;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;


namespace JwtAuthDotNet10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(UserDbContext _context ,IConfiguration _configuration ) : ControllerBase
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
        public async Task<ActionResult<TokenResponseDto>> Login(UserDTO request)
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

            //Generatee the JWT token for the authenticated user

            string token = CreateToken(user);

            return Ok(new TokenResponseDto { AccessToken = token});
        }

        private string CreateToken(User user)
        {
            //1.Define the claims

            var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier,user.Id.ToString()),
                new (ClaimTypes.Name,user.UserName)
            };

            //2.read the secret key from the configuration

            var SecretKey = _configuration.GetValue<string>("AppSetings:Token") ?? throw new InvalidOperationException("Jwt secret Token is missing in appsettings.json");

            //3.convert the secret string into symmetric byte array

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));

            //4.combine key with the cryptographic sigining algo

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            //5.Build the token descriptor

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = creds,
                Issuer = _configuration.GetValue<string>("AppSettings:Issuer"),
                Audience = _configuration.GetValue<string>("AppSettings:Audeience")
            };

            //6. serialize token to raw compact jwt String
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
