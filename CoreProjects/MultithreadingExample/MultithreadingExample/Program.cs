Console.WriteLine("Main Thread Started\n");

// Create thread objects
Thread thread1 = new Thread(PrintNumbers);
Thread thread2 = new Thread(PrintAlphabets);

// Start both threads
thread1.Start();
thread2.Start();

// Wait for both threads to complete
thread1.Join();
thread2.Join();

Console.WriteLine("\nMain Thread Completed");
        

        // Method for Thread 1
        static void PrintNumbers()
{
    for (int i = 1; i <= 5; i++)
    {
        Console.WriteLine($"[Thread 1] Number: {i}");
        Thread.Sleep(500); // Pause for half a second
    }
}

// Method for Thread 2
static void PrintAlphabets()
{
    for (char ch = 'A'; ch <= 'E'; ch++)
    {
        Console.WriteLine($"[Thread 2] Alphabet: {ch}");
        Thread.Sleep(500); // Pause for half a second
    }
}