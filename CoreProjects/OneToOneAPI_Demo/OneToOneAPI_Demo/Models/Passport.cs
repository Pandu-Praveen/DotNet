using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OneToOneAPI_Demo.Models
{
    public class Passport
    {
        [Key, ForeignKey("Person")]
        public int PersonId { get; set; }

        [Required]
        public string PassportNumber { get; set; }

        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        [JsonIgnore]                // prevents serialization loop
        [ValidateNever]             //tells MVC not to validate this field
        public Person Person { get; set; }
    }
}
