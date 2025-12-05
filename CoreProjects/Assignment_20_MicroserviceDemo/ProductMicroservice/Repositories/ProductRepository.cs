using ProductService.Models;

namespace ProductService.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new();
        private int _nextId = 1;

        public ProductRepository()
        {
            // seed with example
            Add(new Product { Name = "Keyboard", Price = 25.5 });
            Add(new Product { Name = "Mouse", Price = 12.0 });
            Add(new Product { Name = "Monitor", Price = 199.99 });
        }

        public Product Add(Product product)
        {
            product.Id = _nextId++;
            _products.Add(product);
            return product;
        }

        public IEnumerable<Product> GetAll() => _products;

        public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);
    }
}
