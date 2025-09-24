using Microsoft.AspNetCore.Mvc;

namespace MyFirst_MVC_CoreApp.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
