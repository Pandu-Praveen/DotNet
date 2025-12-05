using ATM_Transaction_Web_Api.DTO;
using ATM_Transaction_Web_Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATM_Transaction_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ATMController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public ATMController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit([FromBody] DepositRequest req)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var (success, message, newBalance) = await _accountService.DepositAsync(
                req.AccountNumber,
                req.Amount,
                req.Description
            );
            if (!success)
                return BadRequest(new { message });

            return Ok(new { message, newBalance });
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] WithdrawRequest req)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var (success, message, remaining) = await _accountService.WithdrawAsync(
                req.AccountNumber,
                req.Amount,
                req.Description
            );
            if (!success)
            {
                if (message == "Account not found")
                    return NotFound(new { message });
                return BadRequest(new { message });
            }

            return Ok(new { message, remainingBalance = remaining });
        }

        [HttpGet("balance/{accountNumber}")]
        public async Task<IActionResult> Balance(string accountNumber)
        {
            var res = await _accountService.GetBalanceAsync(accountNumber);
            if (res == null)
                return NotFound(new { message = "Account not found" });
            return Ok(res);
        }

        [HttpGet("ministatement/{accountNumber}")]
        public async Task<IActionResult> MiniStatement(
            string accountNumber,
            [FromQuery] int count = 5
        )
        {
            var res = await _accountService.GetMiniStatementAsync(accountNumber, count);
            if (res == null)
                return NotFound(new { message = "Account not found" });
            return Ok(res);
        }
    }
}
