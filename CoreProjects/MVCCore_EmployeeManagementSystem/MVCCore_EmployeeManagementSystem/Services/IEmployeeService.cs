using MVCCore_EmployeeManagementSystem.Models;

namespace MVCCore_EmployeeManagementSystem.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task AddEmployeeAsync(Employee emp);
        Task UpdateEmployeeAsync(Employee emp);
        Task DeleteEmployeeAsync(int id);
    }
}
