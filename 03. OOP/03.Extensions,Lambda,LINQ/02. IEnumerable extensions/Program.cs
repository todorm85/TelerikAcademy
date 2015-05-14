using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Extensions
{
    public static string ToString<T>(this IEnumerable<T> collection)
    {
        StringBuilder sb = new StringBuilder("[ ");
        foreach (var item in collection)
        {
            sb.Append(item);
            sb.Append(" ");
        }

        sb.Append("]");
        return sb.ToString();
    }

    public static decimal Sum<T>(this IEnumerable<T> collection)
    {
        decimal sum = 0;
        foreach (var item in collection)
        {
            sum += Convert.ToDecimal(item);
        }

        return sum;
    }

    public static decimal Product<T>(this IEnumerable<T> collection)
    {
        decimal product = 1;
        foreach (var item in collection)
        {
            product *= Convert.ToDecimal(item);
        }

        return (decimal)product;
    }

    public static decimal Min<T>(this IEnumerable<T> collection)
    {
        dynamic min = decimal.MaxValue;
        foreach (var item in collection)
        {
            if (Convert.ToDecimal(item) < min)
            {
                min = Convert.ToDecimal(item);
            }
        }

        return min;
    }

    public static decimal Max<T>(this IEnumerable<T> collection)
    {
        dynamic max = decimal.MinValue;
        foreach (var item in collection)
        {
            if (Convert.ToDecimal(item) > max)
            {
                max = Convert.ToDecimal(item);
            }
        }

        return max;
    }

    public static decimal Average<T>(this IEnumerable<T> collection)
    {
        decimal avr = 0;
        int count = 0;
        foreach (var item in collection)
        {
            avr += Convert.ToDecimal(item);
            count++;
        }

        return avr / count;
    }

    public static void PrintDelimiter(this string message)
    {
        string delimiter = new string('-', 50);
        Console.WriteLine();
        Console.WriteLine(message);
        Console.WriteLine(delimiter);
    }
}

class Test
{  
    static void Main(string[] args)
    {
        string delimiter = new string('-', 50);

        Console.WriteLine("\n\nTest1 Sum<T>");
        Console.WriteLine(delimiter);
        var doubles = new[] { 2.3, 4.5, 1, 45, 23, 12 };
        Console.WriteLine(doubles.ToString<double>());
        Console.WriteLine(doubles.Sum());

        Console.WriteLine("\n\nTest2 Product<T>");
        Console.WriteLine(delimiter);
        var ints = new[] { 2, 4, 1, 45, 1000000, 12 };
        Console.WriteLine(ints.ToString<int>());
        Console.WriteLine(ints.Product());

        Console.WriteLine("\n\nTest3 Average<T> with ints");
        Console.WriteLine(delimiter);
        Console.WriteLine(ints.ToString<int>());
        Console.WriteLine(ints.Average());

        Console.WriteLine("\n\nTest4 Average<T> with doubles");
        Console.WriteLine(delimiter);
        Console.WriteLine(doubles.ToString<double>());
        Console.WriteLine(doubles.Average());

        Console.WriteLine("\n\nTest5 Max<T> with doubles");
        Console.WriteLine(delimiter);
        Console.WriteLine(doubles.ToString<double>());
        Console.WriteLine(doubles.Max());

        Console.WriteLine("\n\nTest6 Min<T> with doubles");
        Console.WriteLine(delimiter);
        Console.WriteLine(doubles.ToString<double>());
        Console.WriteLine(doubles.Min());
    }
}

