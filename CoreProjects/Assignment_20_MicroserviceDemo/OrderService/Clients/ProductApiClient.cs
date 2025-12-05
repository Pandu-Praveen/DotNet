using OrderService.DTO;

namespace OrderService.Clients
{
    public class ProductApiClient
    {
        private readonly HttpClient _client;
        private readonly ILogger<ProductApiClient> _logger;

        public ProductApiClient(HttpClient client, ILogger<ProductApiClient> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            try
            {
                // Make a GET request to the ProductService API
                var response = await _client.GetAsync($"api/products/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning(
                        "ProductService returned {Status} for id {Id}",
                        response.StatusCode,
                        id
                    );
                    return null;
                }
                // Deserialize the response content to ProductDto   
                var product = await response.Content.ReadFromJsonAsync<ProductDto>();
                return product;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error calling ProductService");
                return null;
            }
        }
    }
}
