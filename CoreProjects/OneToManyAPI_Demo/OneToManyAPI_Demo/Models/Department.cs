using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OneToManyAPI_Demo.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }

        [Required]
        public string DepartmentName { get; set; }

        // Navigation Property - One Department has many Employees
        [JsonIgnore]
        [ValidateNever]
        public ICollection<Employee> Employees { get; set; }
    }
}
