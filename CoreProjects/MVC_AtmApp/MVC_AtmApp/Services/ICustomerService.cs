using MVC_AtmApp.Models;

namespace MVC_AtmApp.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
        Task<int> CreateAsync(Customer customer);
        Task<bool> UpdateAsync(Customer customer);
        Task<bool> DeleteAsync(int id);

        // ATM operations
        Task<bool> DepositAsync(string accountNumber, decimal amount, string notes = null);
        Task<bool> WithdrawAsync(string accountNumber, decimal amount, string notes = null);
        Task<decimal> GetBalanceAsync(string accountNumber);
        Task<IEnumerable<Transaction>> GetMiniStatementAsync(string accountNumber, int count = 10);

    }

}