using Microsoft.AspNetCore.Mvc;
using MVC_AtmApp.Models;
using MVC_AtmApp.Services;

namespace MVC_AtmApp.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService _svc;

        public CustomersController(ICustomerService svc) => _svc = svc;

        public async Task<IActionResult> Index()
        {
            var list = await _svc.GetAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Details(int id)
        {
            var cust = await _svc.GetByIdAsync(id);
            if (cust == null) return NotFound();
            return View(cust);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (!ModelState.IsValid) return View(customer);
            await _svc.CreateAsync(customer);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var cust = await _svc.GetByIdAsync(id);
            if (cust == null) return NotFound();
            return View(cust);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Customer customer)
        {
            if (id != customer.Id) return BadRequest();
            if (!ModelState.IsValid) return View(customer);

            var ok = await _svc.UpdateAsync(customer);
            if (!ok) ModelState.AddModelError("", "Concurrency or update failed.");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cust = await _svc.GetByIdAsync(id);
            if (cust == null) return NotFound();
            return View(cust);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _svc.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

