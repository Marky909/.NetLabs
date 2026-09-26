using IdentityPractice.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityPractice.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        public async Task<IActionResult> Register(
            string email,
            string password)
        {
            var user = new ApplicationUser
            {
                UserName = email,
                Email = email
            };

            var result = await _userManager.CreateAsync(
                user,
                password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }

            return BadRequest(result.Errors);
        }


        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(
            string email,
            string password)
        {
            var result =
                await _signInManager.PasswordSignInAsync(
                    email,
                    password,
                    false,
                    false);

            if (result.Succeeded)
            {
                return RedirectToAction("Profile");
            }

            return Unauthorized("Invalid email or password.");
        }


        // GET: /Account/Profile
        [HttpGet]
        public IActionResult Profile()
        {
            return View();
        }


        // POST: /Account/Logout
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }
    }
}