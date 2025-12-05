using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneToManyAPI_Demo.Models;

namespace OneToManyAPI_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders
                                 .Include(o => o.BookOrders)
                                 .ThenInclude(bo => bo.Book)
                                 .ToListAsync();
        }

        // POST: api/orders
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrders), new { id = order.OrderId }, order);
        }

        // POST: api/orders/addbook
        [HttpPost("addbook")]
        public async Task<IActionResult> AddBookToOrder(int orderId, int bookId)
        {
            var exists = await _context.BookOrders
                .AnyAsync(bo => bo.OrderId == orderId && bo.BookId == bookId);

            if (exists)
                return BadRequest("Book already added to this order.");

            _context.BookOrders.Add(new BookOrder { OrderId = orderId, BookId = bookId });
            await _context.SaveChangesAsync();

            return Ok("Book added to order successfully.");
        }
    }
}
