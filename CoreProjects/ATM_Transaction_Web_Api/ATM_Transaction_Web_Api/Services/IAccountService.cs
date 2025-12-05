using ATM_Transaction_Web_Api.DTO;

namespace ATM_Transaction_Web_Api.Services
{
    public interface IAccountService
    {
        Task<(bool Success, string Message, decimal NewBalance)> DepositAsync(
            string accountNumber,
            decimal amount,
            string description
        );
        Task<(bool Success, string Message, decimal RemainingBalance)> WithdrawAsync(
            string accountNumber,
            decimal amount,
            string description
        );
        Task<BalanceResponse> GetBalanceAsync(string accountNumber);
        Task<IEnumerable<MiniStatementResponse>> GetMiniStatementAsync(
            string accountNumber,
            int count = 5
        );
    }
}
