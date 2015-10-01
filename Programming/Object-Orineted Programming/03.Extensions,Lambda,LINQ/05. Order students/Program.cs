using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Problem 5. Order students
//•	Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name in descending order.
//•	Rewrite the same with LINQ.

class Program
{
    static void Main(string[] args)
    {
        var students = new[]
        {
            new {FirstName = "Vasil", LastName = "Levski", Age = 23},
            new {FirstName = "Hristo", LastName = "Smirnenski", Age = 21},
            new {FirstName = "Ivan", LastName = "Vazov", Age = 40},
            new {FirstName = "Hristo", LastName = "Botev", Age = 35},
            new {FirstName = "Delio", LastName = "Voivoda", Age = 28},
        };


        Console.WriteLine("\n Unsorted students: \n");
        foreach (var student in students)
        {
            Console.WriteLine("{0} {1} {2}", student.FirstName, student.LastName, student.Age);
        }

        Console.WriteLine("\n Sorted DESCENDING with Lambda: \n");
        var sortedWithLambda = students.OrderByDescending(student => student.FirstName).ThenByDescending(student => student.LastName);
        foreach (var student in sortedWithLambda)
        {
            Console.WriteLine("{0} {1} {2}", student.FirstName, student.LastName, student.Age);
        }

        Console.WriteLine("\n Sorted DESCENDING with LINQ queries: \n");
        var sortedWithLINQ =
            from student in students
            orderby student.FirstName descending, student.LastName descending
            select student;

        foreach (var student in sortedWithLINQ)
        {
            Console.WriteLine("{0} {1} {2}", student.FirstName, student.LastName, student.Age);
        }
    }
}
