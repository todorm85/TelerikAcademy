using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Extract_students_with_two_marks
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new[]
            {
                new {FullName ="Ivo Djalov", Marks = new[] {2,5,3,6,4} },
                new {FullName ="Emilian Stanve", Marks = new[] {2,5,3,4} },
                new {FullName ="Kubrat Puliiski", Marks = new[] {2,5,6,3,6,4} },
                new {FullName ="Dimitar Berbatov", Marks = new[] {2,5,3,2,4} },
            };

            var extractedStuents = students.Where(student => student.Marks.Count(x => x == 2) == 2);
                
            // Print results
            foreach (var student in students)
            {
                Console.WriteLine("{0,-20} marks: {1}", student.FullName, student.Marks.ToString<int>());
            }

            "Students with exactly two marks 2".PrintDelimiter();
            foreach (var student in extractedStuents)
            {
                Console.WriteLine("{0,-20} marks: {1}", student.FullName, student.Marks.ToString<int>());
            }
        }
    }
}
