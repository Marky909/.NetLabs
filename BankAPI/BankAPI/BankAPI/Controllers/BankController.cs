using BankAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly BankService _bankService;

        public BankController(BankService service)
        {
            _bankService = service;
        }

        [HttpPost("withdraw")]
        public IActionResult Withdraw(decimal amount)
        {
            var balance = _bankService.Withdraw(amount);

            return Ok(
                new
                {
                    message = "Withdrawl successful",
                    balance
                });
        }
    }
}
