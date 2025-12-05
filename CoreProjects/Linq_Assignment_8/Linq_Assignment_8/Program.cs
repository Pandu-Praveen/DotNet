using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeAggregationReport
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main()
        {
            // Step 1: Create Employee Collection
            List<Employee> employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Alice", Department = "HR", Salary = 35000, Age = 25 },
                new Employee { Id = 2, Name = "Bob", Department = "HR", Salary = 50000, Age = 32 },
                new Employee { Id = 3, Name = "Charlie", Department = "HR", Salary = 70000, Age = 28 },
                new Employee { Id = 4, Name = "David", Department = "IT", Salary = 90000, Age = 26 },
                new Employee { Id = 5, Name = "Eve", Department = "IT", Salary = 110000, Age = 35 },
                new Employee { Id = 6, Name = "Frank", Department = "IT", Salary = 100000, Age = 29 },
                new Employee { Id = 7, Name = "Grace", Department = "Finance", Salary = 60000, Age = 30 },
                new Employee { Id = 8, Name = "Heidi", Department = "Finance", Salary = 40000, Age = 22 },
                new Employee { Id = 9, Name = "Ivan", Department = "Finance", Salary = 90000, Age = 42 }
            };

            // Step 2: Company-wide statistics
            var totalEmployees = employees.Count();
            var totalSalary = employees.Sum(e => e.Salary);
            var avgSalary = employees.Average(e => e.Salary);
            var youngestAge = employees.Min(e => e.Age);
            var oldestAge = employees.Max(e => e.Age);

            // Step 3: Department-wise grouping
            var deptSummary = employees
                .GroupBy(e => e.Department)
                .Select(g => new
                {
                    Department = g.Key,
                    Count = g.Count(),
                    AvgSalary = g.Average(e => e.Salary),
                    MinSalary = g.Min(e => e.Salary),
                    MaxSalary = g.Max(e => e.Salary)
                });

            // Step 4: Display results
            Console.WriteLine("=== Company-wide Summary ===");
            Console.WriteLine($"Total Employees: {totalEmployees}");
            Console.WriteLine($"Total Salary Payout: ₹{totalSalary:N0}");
            Console.WriteLine($"Average Salary: ₹{avgSalary:N0}");
            Console.WriteLine($"Youngest Employee Age: {youngestAge}");
            Console.WriteLine($"Oldest Employee Age: {oldestAge}");
            Console.WriteLine();

            Console.WriteLine("=== Department-wise Summary ===");
            foreach (var dept in deptSummary)
            {
                Console.WriteLine($"{dept.Department}  Count: {dept.Count}, " +
                                  $"Avg Salary: {dept.AvgSalary:N0}, " +
                                  $"Min: {dept.MinSalary:N0}, " +
                                  $"Max: {dept.MaxSalary:N0}");
            }
        }
    }
}
