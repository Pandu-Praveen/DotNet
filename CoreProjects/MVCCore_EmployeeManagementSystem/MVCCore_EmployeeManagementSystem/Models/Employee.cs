using System.ComponentModel.DataAnnotations;

namespace MVCCore_EmployeeManagementSystem.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        public string Department { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfJoining { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
