using OrderService.Models;

namespace OrderService.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order Add(Order order);
    }
}
