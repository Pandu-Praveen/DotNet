using MVCCore_EmployeeManagementSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCore_EmployeeManagementSystem.Models
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }

        [Required]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        //Used to access Employee details from Attendance
        public Employee? Employee { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan? CheckInTime { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan? CheckOutTime { get; set; }

        [Required]
        // Present / Absent / On Leave for the employee
        public string Status { get; set; } 

        public string? Remarks { get; set; }
    }
}


