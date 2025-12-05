using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_Client_ATM.Models;

namespace MVC_Client_ATM.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _http;
        private readonly string _apiBase;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IHttpClientFactory httpFactory, IConfiguration config, ILogger<HomeController> logger)
        {
            _logger = logger;
            _http = httpFactory.CreateClient("atm");
            _apiBase =  "https://localhost:7168/api/ATM";
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Deposit() => View();

        [HttpPost]
        public async Task<IActionResult> Deposit(DepositViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);
            var res = await _http.PostAsJsonAsync(_apiBase + "/deposit", vm);
            var content = await res.Content.ReadFromJsonAsync<object>();
            ViewBag.Response = content;
            return View();
        }
        [HttpGet]
        public IActionResult Withdraw() => View();

        [HttpPost]
        public async Task<IActionResult> Withdraw(WithdrawViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);
            var res = await _http.PostAsJsonAsync(_apiBase + "/withdraw", vm);
            var content = await res.Content.ReadFromJsonAsync<object>();
            ViewBag.Response = content;
            return View();
        }

        [HttpGet]
        public IActionResult Balance()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Balance(string accountNumber)
        {
            if (string.IsNullOrEmpty(accountNumber))
            {
                ModelState.AddModelError("", "Account number is required");
                return View();
            }

            var balance = await _http.GetFromJsonAsync<BalanceViewModel>(_apiBase + $"/balance/{accountNumber}");
            return View(balance); // Pass model to view
        }

        [HttpGet]
        public IActionResult MiniStatement()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> MiniStatement(string accountNumber)
        {
            if (string.IsNullOrEmpty(accountNumber))
            {
                ModelState.AddModelError("", "Account number is required");
                return View();
            }

            // Deserialize JSON directly into a list of strongly-typed models
            var txs = await _http.GetFromJsonAsync<List<MiniStatementViewModel>>(_apiBase + $"/ministatement/{accountNumber}");
            return View(txs); // pass as model
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(
                new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                }
            );
        }
    }
}
