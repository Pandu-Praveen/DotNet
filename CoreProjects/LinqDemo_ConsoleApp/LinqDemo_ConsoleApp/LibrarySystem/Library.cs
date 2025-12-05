using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LinqDemo_ConsoleApp.LibrarySystem
{
    internal class Library
    {

        private List<Book> books = new();
        private const string filePath = "books.json";

        public Library()
        {
            LoadData();
        }

        private void LoadData()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                books = JsonSerializer.Deserialize<List<Book>>(json) ?? new();
            }
        }

        private void SaveData()
        {
            string json = JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public void AddBook()
        {
            Console.Write("Book ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Author: ");
            string author = Console.ReadLine();

            books.Add(new Book { Id = id, Title = title, Author = author, IsBorrowed = false });
            SaveData();
            Console.WriteLine("✅ Book added!");
        }

        public void DisplayAvailableBooks()
        {
            var available = books.Where(b => !b.IsBorrowed);
            foreach (var b in available)
                Console.WriteLine($"{b.Id}: {b.Title} by {b.Author}");
        }

        public void BorrowBook()
        {
            Console.Write("Enter Book ID to borrow: ");
            int id = int.Parse(Console.ReadLine());
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null) { Console.WriteLine("❌ Not found!"); return; }
            if (book.IsBorrowed) { Console.WriteLine("❌ Already borrowed!"); return; }

            book.IsBorrowed = true;
            SaveData();
            Console.WriteLine("✅ Book borrowed!");
        }

        public void ReturnBook()
        {
            Console.Write("Enter Book ID to return: ");
            int id = int.Parse(Console.ReadLine());
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null) { Console.WriteLine("❌ Not found!"); return; }

            book.IsBorrowed = false;
            SaveData();
            Console.WriteLine("✅ Book returned!");
        }

        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Library System ---");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Show Available Books");
                Console.WriteLine("3. Borrow Book");
                Console.WriteLine("4. Return Book");
                Console.WriteLine("0. Exit");
                Console.Write("Select: ");

                switch (Console.ReadLine())
                {
                    case "1": AddBook(); break;
                    case "2": DisplayAvailableBooks(); break;
                    case "3": BorrowBook(); break;
                    case "4": ReturnBook(); break;
                    case "0": return;
                }
            }
        }
    }
}

