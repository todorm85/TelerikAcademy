//Write a program that removes from given sequence all numbers that occur odd number of times.

//Example:
//{ 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} → {5, 3, 3, 5}

namespace _06_RemoveOddRecurring
{
    using System;
    using System.Collections.Generic;
    using Common;

    internal class Program
    {
        private static void Main()
        {
            //var numbers = DataProvider.GetNumbersListInput<int>();

            var numbers = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

            RemoveOddReccurringValues(numbers);

            System.Console.WriteLine(string.Join(" ", numbers));
        }

        private static void RemoveOddReccurringValues<T>(List<T> numbers)
            where T : IComparable
        {
            var checkedValues = new List<T>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (checkedValues.Contains(numbers[i]))
                {
                    continue;
                }

                int timesOccurring = 1;

                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[i].CompareTo(numbers[j]) == 0)
                    {
                        timesOccurring++;
                    }
                }

                if (timesOccurring % 2 == 1)
                {
                    T valueToRemove = numbers[i];
                    numbers.RemoveAll(x => x.CompareTo(valueToRemove) == 0);
                    i--;
                }
                else
                {
                    checkedValues.Add(numbers[i]);
                }
            }
        }
    }
}