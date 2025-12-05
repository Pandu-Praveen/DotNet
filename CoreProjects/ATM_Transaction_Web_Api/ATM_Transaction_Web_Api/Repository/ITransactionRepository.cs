using ATM_Transaction_Web_Api.Models;

namespace ATM_Transaction_Web_Api.Repository
{
    public interface ITransactionRepository
    {
        Task AddAsync(Transaction tx);
        Task<IEnumerable<Transaction>> GetLastTransactionsAsync(int accountId, int count);
        Task SaveChangesAsync();
    }
}
