using Microsoft.AspNetCore.Mvc;
using MVC_CoreApp1.Models;

namespace MVC_CoreApp1.Controllers
{
    public class EmployController : Controller
    {
        public IActionResult Index()
        {
            //Creating employ object with some default values using object initializer
            Employ emp = new Employ()
            {
                Id = 1,
                Name = "Pandu",
                Salary = 99999
            };
            //returning emp object here
            return View(emp);
        }
    }
}
