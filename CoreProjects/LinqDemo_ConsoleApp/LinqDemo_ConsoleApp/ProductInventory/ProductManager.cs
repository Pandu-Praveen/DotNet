using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo_ConsoleApp.ProductInventory
{
    internal class ProductManager
    {
        private List<Product> products;
        private List<(string Category, decimal Discount)> discounts;

        public ProductManager()
        {
            products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Laptop",
                    Category = "Electronics",
                    Price = 60000,
                    Quantity = 10,
                },
                new Product
                {
                    Id = 2,
                    Name = "T-shirt",
                    Category = "Clothing",
                    Price = 800,
                    Quantity = 3,
                },
                new Product
                {
                    Id = 3,
                    Name = "TV",
                    Category = "Electronics",
                    Price = 40000,
                    Quantity = 5,
                },
                new Product
                {
                    Id = 4,
                    Name = "Rice",
                    Category = "Groceries",
                    Price = 50,
                    Quantity = 100,
                },
                new Product
                {
                    Id = 5,
                    Name = "Jeans",
                    Category = "Clothing",
                    Price = 1500,
                    Quantity = 4,
                },
                new Product
                {
                    Id = 6,
                    Name = "Mobile",
                    Category = "Electronics",
                    Price = 30000,
                    Quantity = 2,
                },
                new Product
                {
                    Id = 7,
                    Name = "Sugar",
                    Category = "Groceries",
                    Price = 45,
                    Quantity = 20,
                },
                new Product
                {
                    Id = 8,
                    Name = "Shirt",
                    Category = "Clothing",
                    Price = 1000,
                    Quantity = 8,
                },
                new Product
                {
                    Id = 9,
                    Name = "Mixer",
                    Category = "Electronics",
                    Price = 4000,
                    Quantity = 1,
                },
                new Product
                {
                    Id = 10,
                    Name = "Oil",
                    Category = "Groceries",
                    Price = 120,
                    Quantity = 10,
                },
            };

            discounts = new List<(string, decimal)>
            {
                ("Electronics", 0.10m),
                ("Clothing", 0.15m),
                ("Groceries", 0.05m),
            };
        }

        public void FilterLowStock()
        {
            var lowStock = products.Where(p => p.Quantity < 5);
            Console.WriteLine("\nLow Stock Products (Qty < 5):");
            foreach (var p in lowStock)
                Console.WriteLine($"{p.Name} ({p.Quantity})");
        }

        public void SortByCategoryPrice()
        {
            var sorted = products.OrderBy(p => p.Category).ThenBy(p => p.Price);
            Console.WriteLine("\nProducts Sorted by Category, then Price:");
            foreach (var p in sorted)
                Console.WriteLine($"{p.Category} - {p.Name} - ₹{p.Price}");
        }

        public void GroupAndStockValue()
        {
            var groups = products
                .GroupBy(p => p.Category)
                .Select(g => new { g.Key, TotalValue = g.Sum(p => p.Price * p.Quantity) });
            Console.WriteLine("\nTotal Stock Value by Category:");
            foreach (var g in groups)
                Console.WriteLine($"{g.Key}: ₹{g.TotalValue}");
        }

        public void MostExpensiveCheapest()
        {
            var result = products
                .GroupBy(p => p.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    MostExpensive = g.OrderByDescending(p => p.Price).First(),
                    Cheapest = g.OrderBy(p => p.Price).First(),
                });

            Console.WriteLine("\nMost Expensive & Cheapest per Category:");
            foreach (var r in result)
            {
                Console.WriteLine(
                    $"{r.Category} -> Expensive: {r.MostExpensive.Name} (₹{r.MostExpensive.Price}), "
                        + $"Cheapest: {r.Cheapest.Name} (₹{r.Cheapest.Price})"
                );
            }
        }

        public void JoinDiscounts()
        {
            var joined =
                from p in products
                join d in discounts on p.Category equals d.Category
                select new
                {
                    p.Name,
                    p.Category,
                    Original = p.Price,
                    Discounted = p.Price - p.Price * d.Discount,
                };

            Console.WriteLine("\nDiscounted Prices:");
            foreach (var j in joined)
                Console.WriteLine($"{j.Category} - {j.Name}: ₹{j.Original} → ₹{j.Discounted}");
        }

        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Product Inventory ---");
                Console.WriteLine("1. Filter Low Stock");
                Console.WriteLine("2. Sort by Category/Price");
                Console.WriteLine("3. Group & Stock Value");
                Console.WriteLine("4. Most Expensive & Cheapest");
                Console.WriteLine("5. Apply Discounts");
                Console.WriteLine("0. Exit");
                Console.Write("Select: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        FilterLowStock();
                        break;
                    case "2":
                        SortByCategoryPrice();
                        break;
                    case "3":
                        GroupAndStockValue();
                        break;
                    case "4":
                        MostExpensiveCheapest();
                        break;
                    case "5":
                        JoinDiscounts();
                        break;
                    case "0":
                        return;
                }
            }
        }
    }
}
