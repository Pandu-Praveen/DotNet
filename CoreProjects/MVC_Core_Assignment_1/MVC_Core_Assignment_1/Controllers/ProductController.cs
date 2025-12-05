using Microsoft.AspNetCore.Mvc;
using MVC_Core_Assignment_1.Models;

namespace ProductMVCApp.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>()
        {
            new Product
            {
                Id = 1,
                Name = "Rolex Watch",
                Price = 55659.00m,
            },
            new Product
            {
                Id = 2,
                Name = "IPhone 17 Pro Max",
                Price = 18000,
            },
            new Product
            {
                Id = 3,
                Name = "Washing Machine",
                Price = 39999,
            },
        };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DisplayAllProducts()
        {
            return View(products);
        }

        [HttpGet]
        public IActionResult DisplayProductById()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DisplayProductById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                ViewBag.Message = "Product not found!";
                return View();
            }

            return View(product);
        }

        [HttpGet]
        public IActionResult AddNewProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewProduct(Product product)
        {
            products.Add(product);
            return RedirectToAction("DisplayAllProducts");
        }

        [HttpGet]
        public IActionResult UpdateProductPrice(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost]
        public IActionResult UpdateProductPrice(int id, decimal price)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
                product.Price = price;

            return RedirectToAction("DisplayAllProducts");
        }

        public IActionResult DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
                products.Remove(product);

            return RedirectToAction("DisplayAllProducts");
        }
    }
}
