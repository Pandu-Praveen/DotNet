using System.Text.Json.Serialization;

namespace MVC_Client_ATM.Models
{
    public class BalanceViewModel
    {
        [JsonPropertyName("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonPropertyName("balance")]
        public decimal Amount { get; set; }
    }
}
