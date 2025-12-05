using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OneToManyAPI_Demo.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string EmployeeName { get; set; }

        // Foreign key
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        // Navigation property
        [JsonIgnore]
        public Department Department { get; set; }
    }
}
