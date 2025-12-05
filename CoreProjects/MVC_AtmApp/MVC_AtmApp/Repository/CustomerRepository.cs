using Microsoft.EntityFrameworkCore;
using MVC_AtmApp.Data;
using MVC_AtmApp.Models;

namespace MVC_AtmApp.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext ctx) : base(ctx) { }

        public async Task<Customer> GetWithTransactionsAsync(int id)
        {
            return await _dbSet
                .Include(c => c.Transactions.OrderByDescending(t => t.Date))
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Customer> GetByAccountNumberAsync(string accountNumber)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.AccountNumber == accountNumber);
        }
    }
}
