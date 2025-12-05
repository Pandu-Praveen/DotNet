using System;
using Serilog;

class Program
{
    static void Main(string[] args)
    {
        // Configure Serilog
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("logs/calculator.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        try
        {
            Log.Information("Calculator started.");

            // Get first number
            Console.Write("Enter first number: ");
            string input1 = Console.ReadLine();
            if (!double.TryParse(input1, out double num1))
            {
                Log.Warning("Invalid input for first number: {Input}", input1);
                Console.WriteLine("Invalid input. Exiting.");
                return;
            }
            Log.Information("First number entered: {Num1}", num1);

            // Get second number
            Console.Write("Enter second number: ");
            string input2 = Console.ReadLine();
            if (!double.TryParse(input2, out double num2))
            {
                Log.Warning("Invalid input for second number: {Input}", input2);
                Console.WriteLine("Invalid input. Exiting.");
                return;
            }
            Log.Information("Second number entered: {Num2}", num2);

            // Get operator
            Console.Write("Enter operator (+, -, *, /): ");
            string op = Console.ReadLine();
            Log.Information("Operator entered: {Operator}", op);

            double result = 0;
            switch (op)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        Log.Error("Attempted division by zero");
                        Console.WriteLine("Error: Division by zero is not allowed.");
                        return;
                    }
                    result = num1 / num2;
                    break;
                default:
                    Log.Warning("Invalid operator: {Operator}", op);
                    Console.WriteLine("Invalid operator. Exiting.");
                    return;
            }

            Console.WriteLine($"Result: {result}");
            Log.Information("Calculation result: {Result}", result);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An unexpected error occurred.");
        }
        finally
        {
            Log.Information("Calculator ended.");
            Log.CloseAndFlush();
        }
    }
}
