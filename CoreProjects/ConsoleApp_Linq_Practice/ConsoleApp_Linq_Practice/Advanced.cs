using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Linq_Practice
{
    internal class Advanced
    {
        public static void Run()
        {
            var employees = new[]
            {
                new
                {
                    Id = 1,
                    Name = "Sam",
                    Dept = "IT",
                },
                new
                {
                    Id = 2,
                    Name = "Rajesh",
                    Dept = "IT",
                },
                new
                {
                    Id = 3,
                    Name = "Kamal",
                    Dept = "HR",
                },
            };
            var countEmployee = employees
                .GroupBy(p => p.Dept)
                .Select(g => new { Department = g.Key, Count = g.Count() });

            Console.WriteLine(string.Join("", countEmployee));

            var students = new[]
            {
                new
                {
                    Id = 1,
                    Name = "Alice",
                    Dept = "IT",
                },
                new
                {
                    Id = 2,
                    Name = "Bob",
                    Dept = "Finance",
                },
                new
                {
                    Id = 3,
                    Name = "Charlie",
                    Dept = "HR",
                },
            };

            var marks = new[]
            {
                new
                {
                    StudentId = 1,
                    Subject = "Math",
                    Score = 85,
                },
                new
                {
                    StudentId = 1,
                    Subject = "Science",
                    Score = 90,
                },
                new
                {
                    StudentId = 2,
                    Subject = "Math",
                    Score = 78,
                },
            };

            var studentMarks = students.Join(
                marks,
                student => student.Id,
                mark => mark.StudentId,
                (student, mark) =>
                    new
                    {
                        StudentName = student.Name,
                        mark.Subject,
                        mark.Score,
                    }
            );

            Console.WriteLine(string.Join(" ", studentMarks));

            var top3Marks = marks.OrderByDescending(m => m.Score).Take(3);
            Console.WriteLine(string.Join(" ", top3Marks));

            var departments = new[]
            {
                new { Name = "IT", Skills = new[] { "C#", "Java", "SQL" } },
                new { Name = "HR", Skills = new[] { "Communication", "Recruitment" } },
            };

            var allSkills = departments.SelectMany(d => d.Skills).Distinct();
            Console.WriteLine(string.Join(", ", allSkills));

        }
    }
}
