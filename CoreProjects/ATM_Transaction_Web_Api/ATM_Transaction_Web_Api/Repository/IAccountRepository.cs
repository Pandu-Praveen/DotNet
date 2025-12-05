using ATM_Transaction_Web_Api.Models;

namespace ATM_Transaction_Web_Api.Repository
{
    public interface IAccountRepository
    {
        Task<Account> GetByNumberAsync(string accountNumber);
        Task<Account> GetByIdAsync(int accountId);
        Task<IEnumerable<Account>> GetAllAsync();
        Task AddAsync(Account account);
        Task UpdateAsync(Account account);
        Task SaveChangesAsync();
    }
}
