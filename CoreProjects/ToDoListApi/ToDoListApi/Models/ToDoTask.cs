using System.ComponentModel.DataAnnotations;

namespace ToDoListApi.Models
{
    public class ToDoTask
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Priority { get; set; } = "Normal"; // e.g. Low, Normal, High

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = "Pending";
    }
}
