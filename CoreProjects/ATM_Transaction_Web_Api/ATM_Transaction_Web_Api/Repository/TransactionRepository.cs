using ATM_Transaction_Web_Api.Data;
using ATM_Transaction_Web_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ATM_Transaction_Web_Api.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;

        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Transaction tx)
        {
            await _context.Transactions.AddAsync(tx);
        }

        public async Task<IEnumerable<Transaction>> GetLastTransactionsAsync(
            int accountId,
            int count
        )
        {
            return await _context
                .Transactions.Where(t => t.AccountId == accountId)
                .OrderByDescending(t => t.TransactionDate)
                .Take(count)
                .ToListAsync();
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
