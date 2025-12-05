using Microsoft.EntityFrameworkCore;
using MVC_AtmApp.Data;
using MVC_AtmApp.Models;
using MVC_AtmApp.Repository;

namespace MVC_AtmApp.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _custRepo;
        private readonly IRepository<Transaction> _txnRepo;
        private readonly AppDbContext _context;

        public CustomerService(
            ICustomerRepository custRepo,
            IRepository<Transaction> txnRepo,
            AppDbContext context
        )
        {
            _custRepo = custRepo;
            _txnRepo = txnRepo;
            _context = context;
        }

        public async Task<int> CreateAsync(Customer customer)
        {
            await _custRepo.AddAsync(customer);
            await _custRepo.SaveChangesAsync();
            return customer.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var c = await _custRepo.GetByIdAsync(id);
            if (c == null)
                return false;
            _custRepo.Remove(c);
            await _custRepo.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _custRepo.GetAllAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _custRepo.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(Customer customer)
        {
            try
            {
                _custRepo.Update(customer);
                await _custRepo.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                // concurrency conflict
                return false;
            }
        }

        // ATM ops

        public async Task<bool> DepositAsync(string accountNumber, decimal amount, string notes = null)
        {
            if (amount <= 0) return false;

            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.AccountNumber == accountNumber);
            if (customer == null) return false;

            using var tx = await _context.Database.BeginTransactionAsync();
            try
            {
                customer.Balance += amount;
                var txn = new Transaction
                {
                    AccountNumber = accountNumber,
                    Type = TransactionType.Deposit,
                    Amount = amount,
                    Date = DateTime.UtcNow,
                    BalanceAfter = customer.Balance,
                    Notes = notes
                };

                await _context.Transactions.AddAsync(txn);
                _context.Customers.Update(customer);
                await _context.SaveChangesAsync();
                await tx.CommitAsync();
                return true;
            }
            catch
            {
                await tx.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> WithdrawAsync(string accountNumber, decimal amount, string notes = null)
        {
            if (amount <= 0) return false;

            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.AccountNumber == accountNumber);
            if (customer == null) return false;

            if (customer.Balance < amount) return false;

            using var tx = await _context.Database.BeginTransactionAsync();
            try
            {
                customer.Balance -= amount;
                var txn = new Transaction
                {
                    AccountNumber = accountNumber,
                    Type = TransactionType.Withdraw,
                    Amount = amount,
                    Date = DateTime.UtcNow,
                    BalanceAfter = customer.Balance,
                    Notes = notes
                };

                await _context.Transactions.AddAsync(txn);
                _context.Customers.Update(customer);
                await _context.SaveChangesAsync();
                await tx.CommitAsync();
                return true;
            }
            catch
            {
                await tx.RollbackAsync();
                throw;
            }
        }

        public async Task<decimal> GetBalanceAsync(string accountNumber)
        {
            var c = await _context.Customers.AsNoTracking()
                .FirstOrDefaultAsync(x => x.AccountNumber == accountNumber);
            return c?.Balance ?? 0m;
        }

        public async Task<IEnumerable<Transaction>> GetMiniStatementAsync(string accountNumber, int count = 10)
        {
            return await _context.Transactions
                .Where(t => t.AccountNumber == accountNumber)
                .OrderByDescending(t => t.Date)
                .Take(count)
                .AsNoTracking()
                .ToListAsync();
        }

    }
}
