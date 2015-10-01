using System;
using System.Numerics;
//### Problem 15*. Number calculations
//*	Modify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.)
//*	Use generic method (read in Internet about generic methods in C#).
class Program
{
    static void Main()
    {
        Min<int>(1, 5, -4, 10);
        Max<float>(1, 5.55f, -4, 10);
        Average<sbyte>(1, 5, -4, 10);
        Product<double>(1, 5, -4, 10.056d);
        Sum<short>(1, 5, -4, 10);
    }

    static void Min<T>(params T[] numbers) where T: IComparable
    {
        
        T min = numbers[0];
        foreach (T item in numbers)
        {
            min = (min.CompareTo(item)<0) ? min : item;
        }

        Console.WriteLine("min: " + min);
    }

    static void Max<T>(params T[] numbers) where T: IComparable
    {
        T max = numbers[0];
        foreach (var item in numbers)
        {
            max = (max.CompareTo(item) > 0) ? max : item;
        }

        Console.WriteLine("max: " + max);
    }

    static void Average<T>(params T[] numbers)
    {
        dynamic sum = 0;
        foreach (var item in numbers)
        {
            sum += item;
        }

        Console.WriteLine("Average: " + sum / numbers.Length);
    }

    static void Product<T>(params T[] numbers)
    {
        dynamic product = 1;
        foreach (var item in numbers)
        {
            product *= item;
        }

        Console.WriteLine("Product: " + product);
    }

    static void Sum<T>(params T[] numbers)
    {
        dynamic sum = 0;
        foreach (var item in numbers)
        {
            sum += item;
        }

        Console.WriteLine("Sum: " + sum);
    }
}

