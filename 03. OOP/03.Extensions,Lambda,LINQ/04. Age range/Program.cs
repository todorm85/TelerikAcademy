using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Problem 4. Age range
//•	Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.

class Program
{
    static void Main()
    {
        var students = new[]
        {
            new {FirstName = "Ivan", LastName = "Vazov", Age = 40},
            new {FirstName = "Hristo", LastName = "Botev", Age = 35},
            new {FirstName = "Hristo", LastName = "Smirnenski", Age = 21},
            new {FirstName = "Vasil", LastName = "Levski", Age = 23},
            new {FirstName = "Delio", LastName = "Voivoda", Age = 28},
        };

        foreach (var student in students)
        {
            Console.WriteLine("{0} {1} {2}",student.FirstName, student.LastName, student.Age);
        }

        Console.WriteLine("\nQuery result (Students with age between 18 and 24: \n");
        var queryResults =
            from student in students
            where student.Age>=18 && student.Age<=24
            select student;

        foreach (var student in queryResults)
        {
            Console.WriteLine("{0} {1} {2}", student.FirstName, student.LastName, student.Age);
        }
    }
}

