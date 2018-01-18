//* The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times.

// Write a program to find the majorant of given array(if exists).
//Example:
//{2, 2, 3, 3, 2, 3, 4, 3, 3} → 3

using System;
using System.Collections.Generic;

namespace _08_ArrayMajorant
{
    internal class Program
    {
        private static void Main()
        {
            var arr = new int[] { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            Console.WriteLine(string.Join(" ", arr));
            FindValueMajorants(arr);
        }

        private static void FindValueMajorants<T>(T[] numbers)
            where T : IComparable
        {
            var checkedValues = new List<T>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (checkedValues.Contains(numbers[i]))
                {
                    continue;
                }

                int timesOccurring = 1;

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i].CompareTo(numbers[j]) == 0)
                    {
                        timesOccurring++;
                    }
                }

                if (timesOccurring >= numbers.Length/2 + 1)
                {
                    Console.WriteLine($"Majorant: {numbers[i]}");
                    break;
                }

                checkedValues.Add(numbers[i]);
            }
        }
    }
}