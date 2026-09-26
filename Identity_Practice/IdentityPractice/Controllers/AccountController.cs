using Microsoft.AspNetCore.Mvc;

namespace IdentityPractice.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
