using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Clients;
using OrderService.DTO;
using OrderService.Models;
using OrderService.Repositories;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _repo;
        private readonly ProductApiClient _productClient;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IOrderRepository repo, ProductApiClient productClient, ILogger<OrdersController> logger)
        {
            _repo = repo;
            _productClient = productClient;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetAll()
        {
            return Ok(_repo.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Create([FromBody] CreateOrderRequest request)
        {
            if (request == null || request.Quantity <= 0)
                return BadRequest("Invalid request");

            // 1) fetch product from ProductService via ProductApiClient (HttpClientFactory)
            var product = await _productClient.GetProductByIdAsync(request.ProductId);
            if (product == null)
                return BadRequest($"Product with id {request.ProductId} not found or product service unavailable.");

            // 2) calculate total price
            // Digit-by-digit arithmetic: TotalPrice = Quantity * Product.Price.
            // (This is a normal multiplication, but we do it directly here.)
            double totalPrice = request.Quantity * product.Price;

            var order = new Order
            {
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                TotalPrice = totalPrice
            };

            var created = _repo.Add(order);

            return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
        }
    }
}
