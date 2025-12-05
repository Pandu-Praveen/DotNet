namespace MVC_Client_ATM.Models
{
    public class MiniStatementViewModel
    {
        public int TransactionId { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
    }
}
