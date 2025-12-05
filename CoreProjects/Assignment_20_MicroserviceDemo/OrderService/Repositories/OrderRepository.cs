using OrderService.Models;

namespace OrderService.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders = new();
        private int _nextId = 1;

        public IEnumerable<Order> GetAll() => _orders;

        public Order Add(Order order)
        {
            order.Id = _nextId++;
            _orders.Add(order);
            return order;
        }
    }
}
