using System.ComponentModel.DataAnnotations;

namespace ManyToManyAPI_Demo.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

        public ICollection<BookOrder> BookOrders { get; set; }
    }
}
