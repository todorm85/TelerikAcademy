using System;
using System.Globalization;
//### Problem 16. Date difference
//*	Write a program that reads two dates in the format: `day.month.year` and calculates the number of days between them.

//_Example:_

//    Enter the first date: 27.02.2006
//    Enter the second date: 3.03.2006
//    Distance: 4 days
class Program
{
    static void Main()
    {
        DateTime date1;
        DateTime date2;

        Console.WriteLine("Enter date 1 (dd.MM.yyyy): ");
        while (!DateTime.TryParseExact(Console.ReadLine(),"dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,out date1 ))
        {
            Console.WriteLine("Invalid input!");
            Console.WriteLine("Enter date 1 (dd.MM.yyyy): ");
        }

        Console.WriteLine("Enter date 2 (dd.MM.yyyy): ");
        while (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date2))
        {
            Console.WriteLine("Invalid input!");
            Console.WriteLine("Enter date 2 (dd.MM.yyyy): ");
        }

        TimeSpan days = date2 - date1;
        Console.WriteLine("Distance: " + Math.Abs(days.Days));
    }
}

