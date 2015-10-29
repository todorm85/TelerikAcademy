/*
Write a program that reads a sequence of integers (List<int>) ending with an empty line and sorts them in an increasing order.
*/

namespace _02_BruteForceSort
{
    using System;
    using System.Collections.Generic;
    using Common;

    public class BruteForceSort
    {
        public static void Main()
        {
            //var numbers = ConsoleDataProvider.GetNumbersListInput();
            var numbers = DataProvider.GetRandomNumbersList<int>(5);
            var sortedNumbers = new List<int>();

            while (numbers.Count > 0)
            {
                sortedNumbers.Add(numbers.PopMin<int>());
            }

            Console.WriteLine("Sorted:");

            foreach (var num in sortedNumbers)
            {
                Console.Write(num + " ");
            }
        }
    }
}