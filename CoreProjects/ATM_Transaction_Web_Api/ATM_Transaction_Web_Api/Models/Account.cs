using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace ATM_Transaction_Web_Api.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }

        [Required]
        [MaxLength(20)]
        public string AccountNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string AccountHolderName { get; set; }

        [Required]
        public decimal Balance { get; set; }

        public DateTime CreatedDate { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
