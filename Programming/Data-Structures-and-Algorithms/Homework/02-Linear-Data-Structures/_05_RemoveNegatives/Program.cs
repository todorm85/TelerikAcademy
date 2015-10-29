//Write a program that removes from given sequence all negative numbers.

namespace _05_RemoveNegatives
{
    using System;
    using System.Collections.Generic;
    using Common;

    internal class Program
    {
        private static void Main()
        {
            var numbers = DataProvider.GetRandomNumbersList<int>(10);

            RemoveNegatives(numbers);

            System.Console.WriteLine(string.Join(" ", numbers));
        }

        private static void RemoveNegatives<T>(List<T> numbers)
            where T : IComparable
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i].CompareTo(0) < 0)
                {
                    numbers.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}