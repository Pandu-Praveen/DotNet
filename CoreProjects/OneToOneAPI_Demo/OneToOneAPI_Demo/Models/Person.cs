using System.ComponentModel.DataAnnotations;

namespace OneToOneAPI_Demo.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [Required]
        public string Name { get; set; }

        // Navigation Property
        public Passport Passport { get; set; }
    }
}
