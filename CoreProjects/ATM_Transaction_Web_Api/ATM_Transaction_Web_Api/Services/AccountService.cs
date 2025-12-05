using ATM_Transaction_Web_Api.DTO;
using ATM_Transaction_Web_Api.Models;
using ATM_Transaction_Web_Api.Repository;

namespace ATM_Transaction_Web_Api.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepo;
        private readonly ITransactionRepository _txRepo;

        public AccountService(IAccountRepository accountRepo, ITransactionRepository txRepo)
        {
            _accountRepo = accountRepo;
            _txRepo = txRepo;
        }

        public async Task<(bool Success, string Message, decimal NewBalance)> DepositAsync(
            string accountNumber,
            decimal amount,
            string description
        )
        {
            if (amount <= 0)
                return (false, "Deposit amount must be greater than 0", 0m);

            var account = await _accountRepo.GetByNumberAsync(accountNumber);
            if (account == null)
                return (false, "Account not found", 0m);

            account.Balance += amount;

            var tx = new Transaction
            {
                AccountId = account.AccountId,
                TransactionType = "Deposit",
                Amount = amount,
                TransactionDate = DateTime.UtcNow,
                Description = description,
            };

            await _txRepo.AddAsync(tx);
            await _accountRepo.UpdateAsync(account);
            await _txRepo.SaveChangesAsync();
            await _accountRepo.SaveChangesAsync();

            return (true, "Deposit successful", account.Balance);
        }

        public async Task<(bool Success, string Message, decimal RemainingBalance)> WithdrawAsync(
            string accountNumber,
            decimal amount,
            string description
        )
        {
            if (amount <= 0)
                return (false, "Withdraw amount must be greater than 0", 0m);

            var account = await _accountRepo.GetByNumberAsync(accountNumber);
            if (account == null)
                return (false, "Account not found", 0m);

            if (account.Balance < amount)
                return (false, "Insufficient funds", account.Balance);

            account.Balance -= amount;

            var tx = new Transaction
            {
                AccountId = account.AccountId,
                TransactionType = "Withdraw",
                Amount = amount,
                TransactionDate = DateTime.UtcNow,
                Description = description,
            };

            await _txRepo.AddAsync(tx);
            await _accountRepo.UpdateAsync(account);
            await _txRepo.SaveChangesAsync();
            await _accountRepo.SaveChangesAsync();

            return (true, "Withdrawal successful", account.Balance);
        }

        public async Task<BalanceResponse> GetBalanceAsync(string accountNumber)
        {
            var account = await _accountRepo.GetByNumberAsync(accountNumber);
            if (account == null)
                return null;

            return new BalanceResponse
            {
                AccountNumber = account.AccountNumber,
                Balance = account.Balance,
            };
        }

        public async Task<IEnumerable<MiniStatementResponse>> GetMiniStatementAsync(
            string accountNumber,
            int count = 5
        )
        {
            var account = await _accountRepo.GetByNumberAsync(accountNumber);
            if (account == null)
                return null;

            var txs = await _txRepo.GetLastTransactionsAsync(account.AccountId, count);

            return txs.Select(t => new MiniStatementResponse
            {
                TransactionId = t.TransactionId,
                TransactionType = t.TransactionType,
                Amount = t.Amount,
                TransactionDate = t.TransactionDate,
                Description = t.Description,
            });
        }
    }
}
