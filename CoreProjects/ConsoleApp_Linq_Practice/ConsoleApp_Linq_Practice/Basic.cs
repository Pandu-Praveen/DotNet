using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Linq_Practice
{
    //Basic Level LINQ Practice in C#
    internal class Basic
    {
        public static void Run()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var even = numbers.Where(n => n % 2 == 0);
            Console.WriteLine("Even Numbers: " + string.Join(", ", even));

            string[] names = { "Alice", "Bob", "aharlie", "David", null };
            // Find names starting with 'a' or 'A' and null values also handled
            var namesStartingWithA = names.Where(name =>
                name?.StartsWith("a", StringComparison.OrdinalIgnoreCase) == true
            );
            Console.WriteLine(string.Join(" ", namesStartingWithA));

            var upperCaseNames = names
                .Where(name => !string.IsNullOrEmpty(name))
                .Select(name => name.ToUpper());
            Console.WriteLine(string.Join(" ", upperCaseNames));

            var descendingNumbers = numbers.OrderByDescending(n => n);
            Console.WriteLine(
                "Numbers in Descending Order: " + string.Join(", ", descendingNumbers)
            );

            var totalNumbers = numbers.Count();
            Console.WriteLine("Total Numbers: " + totalNumbers);

            var numbersGreaterThan50 = numbers.Where(n => n > 50).Count();
            var numberGreaterThan50 = numbers.Any(n => n > 50);
            Console.WriteLine("Numbers Greater Than 50 are (TOTAL): " + numbersGreaterThan50);
            Console.WriteLine("Any Number Greater Than 50: " + numberGreaterThan50);

            var multipliedByTen = numbers.Select(n => n * 10);
            Console.WriteLine("Numbers Multiplied by 10: " + string.Join(", ", multipliedByTen));
        }
    }
}
