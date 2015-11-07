namespace _03_CombinationsWithoutDuplicates
{
    using System;
    using Common;

    public static class Startup
    {
        private static void Main()
        {
            var numbersInCombination = 2;
            var startSetNumber = 1;
            var endSetNumber = 4;

            var combinations = Combinatorics.GetAllCombinationsWithoutRepetitions(numbersInCombination, startSetNumber, endSetNumber);

            foreach (var combination in combinations)
            {
                foreach (var item in combination)
                {
                    Console.Write($"{item} ");
                }

                Console.WriteLine();
            }
        }
    }
}