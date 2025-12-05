using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo_ConsoleApp.StudentGradeSystem
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<string, int> Grades { get; set; } = new();

        public double CalculateAverage()
        {
            return Grades.Count == 0 ? 0 : Grades.Values.Average();
        }
    }
}
