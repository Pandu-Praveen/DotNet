using System.ComponentModel.DataAnnotations;

namespace MVC_Client_ATM.Models
{
    public class WithdrawViewModel
    {
        [Required]
        public string AccountNumber { get; set; }


        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }


        public string Description { get; set; }
    }
}
