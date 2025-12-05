using System.ComponentModel.DataAnnotations;

namespace ManyToManyAPI_Demo.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }

        public ICollection<BookOrder> BookOrders { get; set; }
    }
}
