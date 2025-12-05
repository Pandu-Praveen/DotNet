using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo_ConsoleApp.CustomerOrders
{
    internal class OrderManager
    {
        private List<Customer> customers;
        private List<Order> orders;

        public OrderManager()
        {
            customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "John" },
                new Customer { Id = 2, Name = "Priya" },
                new Customer { Id = 3, Name = "Ravi" },
                new Customer { Id = 4, Name = "Meena" },
                new Customer { Id = 5, Name = "Karan" },
            };

            var rnd = new Random();
            orders = Enumerable
                .Range(1, 10)
                .Select(i => new Order
                {
                    Id = i,
                    CustomerId = rnd.Next(1, 6),
                    Amount = rnd.Next(2000, 10000),
                    OrderDate = DateTime.Now.AddDays(-rnd.Next(1, 60)),
                })
                .ToList();
        }

        public void JoinCustomersOrders()
        {
            var joined =
                from c in customers
                join o in orders on c.Id equals o.CustomerId
                select new
                {
                    c.Name,
                    o.Amount,
                    o.OrderDate,
                };

            Console.WriteLine("\nCustomer Orders:");
            foreach (var item in joined)
                Console.WriteLine($"{item.Name} - ₹{item.Amount} on {item.OrderDate:d}");
        }

        public void GroupCustomerSummary()
        {
            var summary =
                from o in orders
                group o by o.CustomerId into g
                join c in customers on g.Key equals c.Id
                select new
                {
                    c.Name,
                    Count = g.Count(),
                    Total = g.Sum(x => x.Amount),
                    Avg = g.Average(x => x.Amount),
                };

            Console.WriteLine("\nCustomer Summary:");
            foreach (var s in summary)
                Console.WriteLine(
                    $"{s.Name} | Orders: {s.Count} | Total: ₹{s.Total} | Avg: ₹{s.Avg:F2}"
                );
        }

        public void FilterMoreThan2Orders()
        {
            var result = orders
                .GroupBy(o => o.CustomerId)
                .Where(g => g.Count() > 2)
                .Join(
                    customers,
                    g => g.Key,
                    c => c.Id,
                    (g, c) => new { c.Name, Count = g.Count() }
                );

            Console.WriteLine("\nCustomers with > 2 Orders:");
            foreach (var r in result)
                Console.WriteLine($"{r.Name} - {r.Count} Orders");
        }

        public void OrdersLast30Days()
        {
            var recent = orders.Where(o => o.OrderDate >= DateTime.Now.AddDays(-30));
            Console.WriteLine("\nOrders in Last 30 Days:");
            foreach (var o in recent)
            {
                var cust = customers.First(c => c.Id == o.CustomerId);
                Console.WriteLine($"{cust.Name} - ₹{o.Amount} on {o.OrderDate:d}");
            }
        }

        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Customer Orders Summary ---");
                Console.WriteLine("1. Join Customers & Orders");
                Console.WriteLine("2. Summary by Customer");
                Console.WriteLine("3. Customers with > 2 Orders");
                Console.WriteLine("4. Orders in Last 30 Days");
                Console.WriteLine("0. Exit");
                Console.Write("Select: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        JoinCustomersOrders();
                        break;
                    case "2":
                        GroupCustomerSummary();
                        break;
                    case "3":
                        FilterMoreThan2Orders();
                        break;
                    case "4":
                        OrdersLast30Days();
                        break;
                    case "0":
                        return;
                }
            }
        }
    }
}
