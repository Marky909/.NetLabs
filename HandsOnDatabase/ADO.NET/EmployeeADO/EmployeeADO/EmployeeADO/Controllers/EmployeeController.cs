using Microsoft.AspNetCore.Mvc;

namespace EmployeeADO.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration; //injection
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
