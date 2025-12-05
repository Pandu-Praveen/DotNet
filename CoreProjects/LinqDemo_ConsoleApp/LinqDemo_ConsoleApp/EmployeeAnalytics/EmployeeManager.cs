using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo_ConsoleApp.EmployeeAnalytics
{
    internal class EmployeeManager
    {
        private List<Employee> employees = new();

        public EmployeeManager()
        {
            // Seed Data
            employees = new List<Employee>
            {
                new Employee{ Id=1, Name="John", Department="IT", Salary=75000, Experience=5},
                new Employee{ Id=2, Name="Priya", Department="HR", Salary=52000, Experience=3},
                new Employee{ Id=3, Name="Karan", Department="Finance", Salary=48000, Experience=4},
                new Employee{ Id=4, Name="Meena", Department="IT", Salary=90000, Experience=8},
                new Employee{ Id=5, Name="Amit", Department="Sales", Salary=45000, Experience=2},
                new Employee{ Id=6, Name="Ravi", Department="Sales", Salary=65000, Experience=6},
                new Employee{ Id=7, Name="Sita", Department="Finance", Salary=70000, Experience=7},
                new Employee{ Id=8, Name="Lina", Department="IT", Salary=55000, Experience=3},
                new Employee{ Id=9, Name="Raj", Department="HR", Salary=48000, Experience=2},
                new Employee{ Id=10, Name="Tara", Department="Finance", Salary=62000, Experience=5}
            };
        }

        public void ShowHighSalary()
        {
            var highSalary = employees.Where(e => e.Salary > 50000);
            Console.WriteLine("\nEmployees with Salary > 50,000:");
            foreach (var e in highSalary)
                Console.WriteLine($"{e.Name} - {e.Salary:C}");
        }

        public void SortByExperience()
        {
            var sorted = employees.OrderByDescending(e => e.Experience);
            Console.WriteLine("\nEmployees by Experience:");
            foreach (var e in sorted)
                Console.WriteLine($"{e.Name} - {e.Experience} yrs");
        }

        public void GroupByDepartment()
        {
            var groups = employees.GroupBy(e => e.Department);
            Console.WriteLine("\nEmployees by Department:");
            foreach (var g in groups)
                Console.WriteLine($"{g.Key}: {g.Count()} employees");
        }

        public void ShowSalaryStats()
        {
            Console.WriteLine($"\nHighest: {employees.Max(e => e.Salary):C}");
            Console.WriteLine($"Lowest: {employees.Min(e => e.Salary):C}");
            Console.WriteLine($"Average: {employees.Average(e => e.Salary):C}");
        }

        public void ProjectNameAndDept()
        {
            var projection = employees.Select(e => new { e.Name, e.Department });
            Console.WriteLine("\nName and Department:");
            foreach (var e in projection)
                Console.WriteLine($"{e.Name} - {e.Department}");
        }

        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Employee Analytics ---");
                Console.WriteLine("1. Filter High Salary");
                Console.WriteLine("2. Sort by Experience");
                Console.WriteLine("3. Group by Department");
                Console.WriteLine("4. Salary Statistics");
                Console.WriteLine("5. Name & Department Projection");
                Console.WriteLine("0. Exit");
                Console.Write("Select: ");
                switch (Console.ReadLine())
                {
                    case "1": ShowHighSalary(); break;
                    case "2": SortByExperience(); break;
                    case "3": GroupByDepartment(); break;
                    case "4": ShowSalaryStats(); break;
                    case "5": ProjectNameAndDept(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid!"); break;
                }
            }
        }
    }
}

