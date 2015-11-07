namespace _05_OrderedSubsetFromSet
{
    using System;
    using Common;

    public static class Startup
    {
        private static void Main()
        {
            // Input, just change these values, it`s easier to test than typing them in the console.
            var numbersInSubset = 2;
            var words = new string[3] { "hi", "a", "b" };

            var startIndex = 0;
            var endIndex = words.Length - 1;

            var allIndexVariations = Combinatorics.GetAllVariationsWithRepetitions(numbersInSubset, startIndex, endIndex);

            foreach (var variation in allIndexVariations)
            {
                foreach (var item in variation)
                {
                    Console.Write($"{words[item]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
