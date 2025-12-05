using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Linq_Practice
{
    //Intermediate Level LINQ Practice in C#
    internal class Intermediate
    {
        public static void Run()
        {
            var products = new[]
            {
                new
                {
                    Id = 1,
                    Name = "Mouse",
                    Price = 400,
                },
                new
                {
                    Id = 2,
                    Name = "Laptop",
                    Price = 70000,
                },
                new
                {
                    Id = 3,
                    Name = "Keyboard",
                    Price = 2000,
                },
                new
                {
                    Id = 4,
                    Name = "Keyboard",
                    Price = 5000,
                },
            };

            var productsPriceGreaterThan500 = products.Where(p => p.Price > 500);
            Console.WriteLine(string.Join(" ", productsPriceGreaterThan500));

            var productNames = products.Select(p => p.Name).Distinct();
            Console.WriteLine(string.Join("||", productNames));

            var orderByPrice = products.OrderBy(products => products.Price);
            
            Console.WriteLine(string.Join(" ", orderByPrice));

            var sumOfProductPrices = products.Sum(p => p.Price);
            Console.WriteLine("Sum of Product Prices: " + sumOfProductPrices);

            var result = products.Skip(1).Take(2);
            Console.WriteLine(string.Join(" ", result));

            var productsPriceGreaterThan100 = products.All(p=> p.Price > 100);
            Console.WriteLine("All Products Price Greater Than 100: " + productsPriceGreaterThan100);
        }
    }
}
