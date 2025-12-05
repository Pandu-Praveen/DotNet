using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId}");

        var syncTask = Task.Run(() => Sync());
        var asyncTask = Async();

        await Task.WhenAll(syncTask, asyncTask);
    }

    static void Sync()
    {
        Console.WriteLine($"[SYNC Start] Thread {Thread.CurrentThread.ManagedThreadId} at {DateTime.Now:HH:mm:ss.fff}");
        Thread.Sleep(5000);
        Console.WriteLine($"[SYNC End]   Thread {Thread.CurrentThread.ManagedThreadId} at {DateTime.Now:HH:mm:ss.fff}");
    }

    static async Task Async()
    {
        Console.WriteLine($"[ASYNC Start] Thread {Thread.CurrentThread.ManagedThreadId} at {DateTime.Now:HH:mm:ss.fff}");
        await Task.Delay(5000);
        Console.WriteLine($"[ASYNC End]   Thread {Thread.CurrentThread.ManagedThreadId} at {DateTime.Now:HH:mm:ss.fff}");
    }
}
