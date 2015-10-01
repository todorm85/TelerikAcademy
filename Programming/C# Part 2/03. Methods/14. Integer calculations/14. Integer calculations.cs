using System;
using System.Numerics;
//### Problem 14. Integer calculations
//*	Write methods to calculate `minimum`, `maximum`, `average`, `sum` and `product` of given set of integer numbers.
//*	Use variable number of arguments.
class Program
{
    static void Main()
    {
        Min(1, 5, -4, 10);
        Max(1, 5, -4, 10);
        Average(1, 5, -4, 10);
        Product(1, 5, -4, 10);
        Sum(1, 5, -4, 10);
    }

    static void Min(params int[] numbers)
    {
        int min = int.MaxValue;
        foreach (var item in numbers)
        {
            min = (min < item) ? min : item;
        }

        Console.WriteLine("min: " + min);
    }

    static void Max(params int[] numbers)
    {
        int max = int.MinValue;
        foreach (var item in numbers)
        {
            max = (max > item) ? max : item;
        }

        Console.WriteLine("max: " + max);
    }

    static void Average (params int[] numbers)
    {
        Decimal sum = 0;
        foreach (var item in numbers)
        {
            sum += item;
        }

        Console.WriteLine("Average: " + sum / numbers.Length);
    }

    static void Product(params int[] numbers)
    {
        BigInteger product = 1;
        foreach (var item in numbers)
        {
            product *= item;
        }

        Console.WriteLine("Product: " + product);
    }

    static void Sum(params int[] numbers)
    {
        BigInteger sum = 0;
        foreach (var item in numbers)
        {
            sum += item;
        }

        Console.WriteLine("Sum: " + sum );
    }
}

