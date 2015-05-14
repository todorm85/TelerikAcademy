using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Problem 6. Divisible by 7 and 3
//•	Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.

class Program
{
    static void Main()
    {
        Console.WriteLine("Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.\n\n");
        var ints = new[] { 4, 3, 6, 3, 6, 63, 8, 4, 7, 49, 33, 21 };
        PrintCollection(ints);
        PrintDelimiter("\nResult with Lambda:");
        var lambdaResult = ints.Where(x => x % 7 == 0 && x % 3 == 0).Select(x => x);
        PrintCollection(lambdaResult);
        PrintDelimiter("\nResult with LINQ:");
        var linqResult =
            from x in ints
            where x % 7 == 0 && x % 3 == 0
            select x;
        PrintCollection(linqResult);
    }

    static void PrintCollection<T>(IEnumerable<T> collection)
    {
        StringBuilder sb = new StringBuilder("[ ");
        foreach (var item in collection)
        {
            sb.Append(item);
            sb.Append(" ");
        }

        sb.Append("]");
        Console.WriteLine(sb.ToString());
    }

    static void PrintDelimiter(string message)
    {
        string delimiter = new string('-', 50);

        Console.WriteLine(message);
        Console.WriteLine(delimiter);
    }
}

