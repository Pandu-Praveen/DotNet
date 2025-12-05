using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo_ConsoleApp.StudentGradeSystem
{
    internal class StudentManager
    {
        private List<Student> students = new();

        public void AddStudent()
        {
            Console.Write("Enter Student ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            students.Add(new Student { Id = id, Name = name });
            Console.WriteLine("✅ Student added successfully!");
        }

        public void AddOrUpdateGrade()
        {
            Console.Write("Enter Student ID: ");
            int id = int.Parse(Console.ReadLine());
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null) { Console.WriteLine("❌ Student not found!"); return; }

            Console.Write("Enter Subject: ");
            string subject = Console.ReadLine();
            Console.Write("Enter Marks: ");
            int marks = int.Parse(Console.ReadLine());
            student.Grades[subject] = marks;
            Console.WriteLine("✅ Grade added/updated!");
        }

        public void ViewAllStudents()
        {
            foreach (var s in students)
            {
                Console.WriteLine($"ID: {s.Id}, Name: {s.Name}, Average: {s.CalculateAverage():F2}");
            }
        }

        public void DisplayTop3Students()
        {
            var top3 = students.OrderByDescending(s => s.CalculateAverage()).Take(3);
            Console.WriteLine("\n🏆 Top 3 Students:");
            foreach (var s in top3)
            {
                Console.WriteLine($"{s.Name} - Avg: {s.CalculateAverage():F2}");
            }
        }

        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Student Grade System ---");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add/Update Grade");
                Console.WriteLine("3. View All Students");
                Console.WriteLine("4. Top 3 Students");
                Console.WriteLine("0. Exit");
                Console.Write("Select: ");

                switch (Console.ReadLine())
                {
                    case "1": AddStudent(); break;
                    case "2": AddOrUpdateGrade(); break;
                    case "3": ViewAllStudents(); break;
                    case "4": DisplayTop3Students(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid!"); break;
                }
            }
        }
    }
}

