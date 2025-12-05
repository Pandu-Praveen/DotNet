using Microsoft.AspNetCore.Mvc;
using MVCCore_EmployeeManagementSystem.Models;
using MVCCore_EmployeeManagementSystem.Services;

namespace MVCCore_EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        // Dependency Injection of Employee Service
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }
        
        public async Task<IActionResult> Index()
        {
            var employees = await _service.GetAllEmployeesAsync();
            return View(employees);
        }
        
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Employee emp)
        {
            if (!ModelState.IsValid)
                return View(emp);
            await _service.AddEmployeeAsync(emp);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var emp = await _service.GetEmployeeByIdAsync(id);
            if (emp == null)
                return NotFound();
            return View(emp);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee emp)
        {
            if (!ModelState.IsValid)
                return View(emp);
            await _service.UpdateEmployeeAsync(emp);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var emp = await _service.GetEmployeeByIdAsync(id);
            if (emp == null)
                return NotFound();
            return View(emp);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteEmployeeAsync(id);
            return RedirectToAction(nameof(Index));
        }
       

    }
}
