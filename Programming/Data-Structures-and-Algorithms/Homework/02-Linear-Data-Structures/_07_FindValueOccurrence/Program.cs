//Write a program that finds in given array of integers(all belonging to the range[0..1000]) how many times each of them occurs.

//Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
//2 → 2 times
//3 → 4 times
//4 → 3 times

namespace _07_FindValueOccurrence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            var arr = new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

            FindValueOccurrence(arr);
        }

        private static void FindValueOccurrence<T>(T[] numbers)
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

                Console.WriteLine($"{numbers[i]} : {timesOccurring}");
                checkedValues.Add(numbers[i]);
            }
        }
    }
}
