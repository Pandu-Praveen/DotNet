using MVCCore_EmployeeManagementSystem.Models;
using MVCCore_EmployeeManagementSystem.Repository;
using MVCCore_EmployeeManagementSystem.Services;

namespace MVCCore_EmployeeManagementSystem.Services
{
    public class EmployeeService : IEmployeeService
    {
        // Dependency Injection of Generic Repository
        private readonly IRepository<Employee> _repo;
        public EmployeeService(IRepository<Employee> repo) { _repo = repo; }

        public async Task AddEmployeeAsync(Employee emp) => await _repo.AddAsync(emp);
        public async Task DeleteEmployeeAsync(int id) => await _repo.DeleteAsync(id);
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync() => await _repo.GetAllAsync();
        public async Task<Employee> GetEmployeeByIdAsync(int id) => await _repo.GetByIdAsync(id);
        public async Task UpdateEmployeeAsync(Employee emp) => await _repo.UpdateAsync(emp);
    }
}

