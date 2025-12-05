using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ConsoleAPP_Api_Testing_Assignment_2.Models;

namespace ConsoleAPP_Api_Testing_Assignment_2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Base URL of the ASP.NET Core Web API
            string apiBaseUrl = "https://localhost:7073/api/Employee";
            //initializing the httpclient object
            HttpClient client = new HttpClient();

            try
            {
                Console.WriteLine("Fetching employees from the Web API...");

                // making request for the employees
                List<Employee> employees = await client.GetFromJsonAsync<List<Employee>>(apiBaseUrl);

                if (employees != null && employees.Count > 0)
                {
                    Console.WriteLine("\nList of Employees from the API:\n");

                    foreach (var emp in employees)
                    {
                        Console.WriteLine(
                            $"ID: {emp.Id},  Name: {emp.Name},  " +
                            $"Department: {emp.Department},  Mobile: {emp.MobileNo},  Email: {emp.Email}"
                        );
                    }
                }
                else
                {
                    Console.WriteLine("No employees found.");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("API Exception: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown Exception Occurred: " + e.Message);
            }
        }
    }
}
