using System;
using LinqDemo_ConsoleApp.StudentGradeSystem;
using LinqDemo_ConsoleApp.LibrarySystem;
using LinqDemo_ConsoleApp.EmployeeAnalytics;
using LinqDemo_ConsoleApp.ProductInventory;
using LinqDemo_ConsoleApp.CustomerOrders;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== MAIN MENU =====");
            Console.WriteLine("1. Student Grade Management");
            Console.WriteLine("2. Library Book System");
            Console.WriteLine("3. Employee Analytics");
            Console.WriteLine("4. Product Inventory");
            Console.WriteLine("5. Customer Orders Summary");
            Console.WriteLine("0. Exit");
            Console.Write("Select a system: ");

            switch (Console.ReadLine())
            {
                case "1": new StudentManager().Menu(); break;
                case "2": new Library().Menu(); break;
                case "3": new EmployeeManager().Menu(); break;
                case "4": new ProductManager().Menu(); break;
                case "5": new OrderManager().Menu(); break;
                case "0": return;
                default: Console.WriteLine("Invalid choice!"); break;
            }
        }
    }
}
