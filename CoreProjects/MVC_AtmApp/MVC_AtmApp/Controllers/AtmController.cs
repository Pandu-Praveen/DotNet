using Microsoft.AspNetCore.Mvc;
using MVC_AtmApp.Services;

namespace MVC_AtmApp.Controllers
{
    public class AtmController : Controller
    {
        private readonly ICustomerService _svc;
        public AtmController(ICustomerService svc) => _svc = svc;

        public IActionResult Index() => View();

        public IActionResult Deposit() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deposit(string accountNumber, decimal amount)
        {
            var ok = await _svc.DepositAsync(accountNumber, amount, "ATM deposit");
            ViewBag.Success = ok;
            ViewBag.Balance = await _svc.GetBalanceAsync(accountNumber);
            return View();
        }

        public IActionResult Withdraw() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Withdraw(string accountNumber, decimal amount)
        {
            var ok = await _svc.WithdrawAsync(accountNumber, amount, "ATM withdrawal");
            ViewBag.Success = ok;
            ViewBag.Balance = await _svc.GetBalanceAsync(accountNumber);
            return View();
        }

        public async Task<IActionResult> Balance(string accountNumber)
        {
            ViewBag.Balance = await _svc.GetBalanceAsync(accountNumber);
            return View();
        }

        public async Task<IActionResult> MiniStatement(string accountNumber)
        {
            var list = await _svc.GetMiniStatementAsync(accountNumber, 10);
            return View(list);
        }
    }

}
