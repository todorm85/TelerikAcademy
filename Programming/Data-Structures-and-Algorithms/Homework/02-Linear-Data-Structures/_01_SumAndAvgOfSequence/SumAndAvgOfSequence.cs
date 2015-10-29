/*
Write a program that reads from the console a sequence of positive integer numbers.

The sequence ends when empty line is entered.
Calculate and print the sum and average of the elements of the sequence.
Keep the sequence in List<int>.
*/

namespace _01_SumAndAvgOfSequence
{
    using System;
    using System.Collections.Generic;
    using Common;
    using System.Linq;

    public class SumAndAvgOfSequence
    {
        private const string NumberOutOfRangeErrorMessage = "The sum exceeds the maximum possible allowed number 18,446,744,073,709,551,615.";

        public static void Main()
        {
            var numbers = DataProvider.GetNumbersListInput<uint>(breakLine: string.Empty);
            //var numbers = DataProvider.GetRandomNumbersList<uint>(5);

            var sum = CalculateSum(numbers);

            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Average: {sum / (double)numbers.Count}");
        }

        private static ulong CalculateSum(ICollection<uint> numbers)
        {
            ulong sum = 0;

            foreach (var number in numbers)
            {
                sum += number;
                if (sum < 0)
                {
                    Console.WriteLine(NumberOutOfRangeErrorMessage);
                }
            }

            return sum;
        }
    }
}