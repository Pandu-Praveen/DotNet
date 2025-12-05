using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_AtmApp.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Customer))]
        [StringLength(20)]
        public string AccountNumber { get; set; }   

        public TransactionType Type { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "decimal(18,2)")]
        public decimal BalanceAfter { get; set; }

        public string Notes { get; set; }

        // Navigation property
        public Customer Customer { get; set; }
    }
}
