using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Problem 3. First before last
//•	Write a method that from a given array of students finds all students whose first name is before its last name alphabetically.
//•	Use LINQ query operators.


class Program
{
    static void Main(string[] args)
    {
        var students = new[]
        {
            new {FirstName = "Ivan", LastName = "Vazov"},
            new {FirstName = "Hristo", LastName = "Botev"},
            new {FirstName = "Hristo", LastName = "Smirnenski"},
            new {FirstName = "Vasil", LastName = "Levski"},
            new {FirstName = "Delio", LastName = "Voivoda"},
        };

        foreach (var student in students)
        {
            Console.WriteLine(student.FirstName + " " + student.LastName);
        }

        Console.WriteLine("\nQuery result: \n");
        var queryResults =
            from student in students
            where student.FirstName.CompareTo(student.LastName) < 0
            select student;

        foreach (var student in queryResults)
        {
            Console.WriteLine(student.FirstName +" " + student.LastName);
        }
    }
}
