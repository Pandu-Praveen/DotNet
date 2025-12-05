using System.ComponentModel.DataAnnotations;

namespace ATM_Transaction_Web_Api.DTO
{
    public class WithdrawRequest
    {
        [Required]
        public string AccountNumber { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Withdraw amount must be greater than 0.")]
        public decimal Amount { get; set; }

        public string Description { get; set; }
    }
}
