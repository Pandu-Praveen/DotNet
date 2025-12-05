using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCCore_EmployeeManagementSystem.Models;
using MVCCore_EmployeeManagementSystem.Services;

namespace MVCCore_EmployeeManagementSystem.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IAttendanceService _attendanceService;
        private readonly IEmployeeService _employeeService;

        public AttendanceController(
            IAttendanceService attendanceService,
            IEmployeeService employeeService
        )
        {
            _attendanceService = attendanceService;
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var attendances = await _attendanceService.GetAllAttendancesAsync();
            return View(attendances);
        }

        public async Task<IActionResult> Mark()
        {
            ViewBag.Employees = await _employeeService.GetAllEmployeesAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Mark(Attendance attendance)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Employees = await _employeeService.GetAllEmployeesAsync();
                return View(attendance);
            }

            try
            {
                await _attendanceService.AddAttendanceAsync(attendance);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                ViewBag.Employees = await _employeeService.GetAllEmployeesAsync();
                return View(attendance);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var attendance = await _attendanceService.GetAttendanceByIdAsync(id);
            if (attendance == null)
                return NotFound();

            var employees = await _employeeService.GetAllEmployeesAsync();

            ViewBag.Employees = new SelectList(
                employees,
                "EmployeeId",
                "Name",
                attendance.EmployeeId
            );

            return View(attendance);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Attendance attendance)
        {
            if (!ModelState.IsValid)
            {
                var employees = await _employeeService.GetAllEmployeesAsync();
                ViewBag.Employees = employees
                    .Select(e => new SelectListItem
                    {
                        Value = e.EmployeeId.ToString(),
                        Text = e.Name,
                    })
                    .ToList();

                return View(attendance);
            }

            await _attendanceService.UpdateAttendanceAsync(attendance);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var attendance = await _attendanceService.GetAttendanceByIdAsync(id);
            if (attendance == null)
                return NotFound();
            return View(attendance);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _attendanceService.DeleteAttendanceAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Report(
            DateTime? startDate,
            DateTime? endDate,
            int? employeeId,
            string status
        )
        {
            var attendances = await _attendanceService.GetAllAttendancesAsync();

            if (startDate.HasValue && endDate.HasValue)
                attendances = attendances.Where(a =>
                    a.Date.Date >= startDate.Value.Date && a.Date.Date <= endDate.Value.Date
                );

            if (employeeId.HasValue)
                attendances = attendances.Where(a => a.EmployeeId == employeeId.Value);

            if (!string.IsNullOrEmpty(status))
                attendances = attendances.Where(a =>
                    a.Status.Equals(status, StringComparison.OrdinalIgnoreCase)
                );

            ViewBag.Employees = await _employeeService.GetAllEmployeesAsync();

            var summary = attendances
                .GroupBy(a => a.Employee)
                .Select(g => new
                {
                    Employee = g.Key,
                    PresentDays = g.Count(a => a.Status == "Present"),
                    AbsentDays = g.Count(a => a.Status == "Absent"),
                    LeaveDays = g.Count(a => a.Status == "On Leave"),
                })
                .ToList();

            ViewBag.Summary = summary;

            return View(attendances);
        }
    }
}
