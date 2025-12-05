namespace ATM_Transaction_Web_Api.DTO
{
    public class MiniStatementResponse
    {
        public int TransactionId { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
    }
}
