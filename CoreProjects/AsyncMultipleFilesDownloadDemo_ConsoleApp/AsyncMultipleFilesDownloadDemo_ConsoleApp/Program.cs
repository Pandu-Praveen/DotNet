using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConcurrentDownloadsDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Download Multiple Files Concurrently ===");

            // Step 1: Create a list of URLs
            List<string> urls = new List<string>
            {
                "https://picsum.photos/200/300",        // Random image
                "https://jsonplaceholder.typicode.com/posts/1",  // JSON data
                "https://jsonplaceholder.typicode.com/todos/1",  // Another JSON
                "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf" // PDF
            };

            var httpClient = new HttpClient();
            var stopwatch = Stopwatch.StartNew();

            // Step 2: Start a Task for each download
            var downloadTasks = new List<Task>();

            foreach (var url in urls)
            {
                downloadTasks.Add(Task.Run(async () =>
                {
                    await DownloadFileAsync(httpClient, url);
                }));
            }

            // Step 3: Wait for all downloads to complete
            await Task.WhenAll(downloadTasks);

            stopwatch.Stop();

            // Step 4: Display total time taken
            Console.WriteLine($"\n All downloads completed in {stopwatch.ElapsedMilliseconds} ms");
        }

        // Helper method to download file asynchronously
        static async Task DownloadFileAsync(HttpClient client, string url)
        {
            try
            {
                var fileName = Path.GetFileName(new Uri(url).AbsolutePath);
                if (string.IsNullOrEmpty(fileName)) fileName = Guid.NewGuid().ToString();

                var data = await client.GetByteArrayAsync(url);

                string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
                await File.WriteAllBytesAsync(filePath, data);

                Console.WriteLine($" Downloaded: {fileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error downloading {url}: {ex.Message}");
            }
        }
    }
}
