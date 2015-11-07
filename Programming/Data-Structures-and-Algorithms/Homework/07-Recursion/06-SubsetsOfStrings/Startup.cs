namespace _06_SubsetsOfStrings
{
    using System;
    using Common;

    public static class Startup
    {
        private static void Main()
        {
            // Input, just change these values, it`s easier to test than typing them in the console.
            var numbersInSubset = 2;
            var words = new string[3] { "test", "rock", "fun" };

            var startIndex = 0;
            var endIndex = words.Length - 1;

            var allIndexCombinations = Combinatorics.GetAllCombinationsWithoutRepetitions(numbersInSubset, startIndex, endIndex);

            foreach (var indexCombination in allIndexCombinations)
            {
                foreach (var item in indexCombination)
                {
                    Console.Write($"{words[item]} ");
                }

                Console.WriteLine();
            }
        }
    }

}
