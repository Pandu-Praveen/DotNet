using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqAggregationDemo
{
    // ==============================
    // Data Models
    // ==============================
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public int PersonId { get; set; }
        public decimal Amount { get; set; }
        public DateTime OrderDate { get; set; }
    }

    // ==============================
    // Program Logic
    // ==============================
    class Program
    {
        static void Main()
        {
            // --------------------------------
            // Step 1: Sample Data
            // --------------------------------
            List<Person> people = new List<Person>
            {
                new Person { Id = 1, Name = "Alice", Age = 30, Email = "alice@example.com" },
                new Person { Id = 2, Name = "Bob", Age = 25, Email = "" },
                new Person { Id = 3, Name = "Charlie", Age = 35, Email = "charlie@example.com" },
                new Person { Id = 4, Name = "Diana", Age = 40, Email = "diana@example.com" }
            };

            List<Order> orders = new List<Order>
            {
                new Order { OrderId = 1, PersonId = 1, Amount = 100, OrderDate = new DateTime(2025, 1, 15) },
                new Order { OrderId = 2, PersonId = 2, Amount = 50,  OrderDate = new DateTime(2025, 2, 20) },
                new Order { OrderId = 3, PersonId = 1, Amount = 75,  OrderDate = new DateTime(2025, 3, 5) },
                new Order { OrderId = 4, PersonId = 3, Amount = 120, OrderDate = new DateTime(2025, 3, 15) },
                new Order { OrderId = 5, PersonId = 4, Amount = 200, OrderDate = new DateTime(2025, 4, 10) }
            };

            // --------------------------------
            // 1. Aggregation Operations
            // --------------------------------
            Console.WriteLine("=== Aggregation Operations ===");

            var personOrderStats = people
                .GroupJoin(
                    orders,
                    p => p.Id,
                    o => o.PersonId,
                    (p, os) => new
                    {
                        PersonName = p.Name,
                        TotalOrders = os.Count(),
                        TotalAmount = os.Sum(o => o.Amount)
                    });

            foreach (var stat in personOrderStats)
            {
                Console.WriteLine($"{stat.PersonName} - Orders: {stat.TotalOrders}, Total Amount: {stat.TotalAmount}");
            }

            // Average order amount for people older than 30
            var avgOlderThan30 = orders
                .Join(people, o => o.PersonId, p => p.Id, (o, p) => new { o.Amount, p.Age })
                .Where(x => x.Age > 30)
                .Average(x => x.Amount);

            Console.WriteLine($"\nAverage Order Amount (Age > 30): {avgOlderThan30}");

            // Min, Max, and Average order amount for each person
            var orderStats = people
                .GroupJoin(
                    orders,
                    p => p.Id,
                    o => o.PersonId,
                    (p, os) => new
                    {
                        p.Name,
                        Min = os.Any() ? os.Min(o => o.Amount) : 0,
                        Max = os.Any() ? os.Max(o => o.Amount) : 0,
                        Avg = os.Any() ? os.Average(o => o.Amount) : 0
                    });

            Console.WriteLine("\nMin, Max, Avg Order Amount Per Person:");
            foreach (var s in orderStats)
            {
                Console.WriteLine($"{s.Name} - Min: {s.Min}, Max: {s.Max}, Avg: {s.Avg}");
            }

            // --------------------------------
            // 2. Element Operators
            // --------------------------------
            Console.WriteLine("\n=== Element Operators ===");

            var specificDate = new DateTime(2025, 3, 5);
            var orderOnDate = orders.SingleOrDefault(o => o.OrderDate == specificDate);

            Console.WriteLine("Order on March 5, 2025:");
            if (orderOnDate != null)
                Console.WriteLine($"OrderId: {orderOnDate.OrderId}, Amount: {orderOnDate.Amount}");
            else
                Console.WriteLine("No order found on that date.");

            var highOrder = orders.FirstOrDefault(o => o.Amount > 150);
            Console.WriteLine("\nFirst order with amount > 150:");
            if (highOrder != null)
                Console.WriteLine($"OrderId: {highOrder.OrderId}, Amount: {highOrder.Amount}");
            else
                Console.WriteLine("No order with amount > 150 found.");

            // --------------------------------
            // 3. Quantifier Operators
            // --------------------------------
            Console.WriteLine("\n=== Quantifier Operators ===");

            bool allHaveOrders = people.All(p => orders.Any(o => o.PersonId == p.Id));
            Console.WriteLine($"All people have placed at least one order: {allHaveOrders}");

            bool anyLargeOrder = orders.Any(o => o.Amount > 250);
            Console.WriteLine($"Any order amount greater than 250: {anyLargeOrder}");

            // --------------------------------
            // 4. Collection Conversion
            // --------------------------------
            Console.WriteLine("\n=== Collection Conversion ===");

            var orderDictionary = people
                .GroupJoin(
                    orders,
                    p => p.Id,
                    o => o.PersonId,
                    (p, os) => new { p.Name, Orders = os.ToList() })
                .ToDictionary(x => x.Name, x => x.Orders);

            foreach (var entry in orderDictionary)
            {
                Console.WriteLine($"{entry.Key} has {entry.Value.Count} order(s).");
            }

            Console.WriteLine("\nProgram complete!");
        }
    }
}