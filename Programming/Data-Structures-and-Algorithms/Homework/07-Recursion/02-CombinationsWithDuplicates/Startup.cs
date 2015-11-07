namespace _02_CombinationsWithDuplicates
{
    using System;
    using Common;

    public static class Startup
    {
        private static void Main()
        {
            var numbersInCombination = 2;
            var startSetNumber = 1;
            var endSetNumber = 3;

            //var combinations = CombinationsGenerator.GetAllCombinationsWithRepetition(numbersInCombination, startSetNumber, endSetNumber);

            var combinations = Combinatorics.GetAllCombinationsWithRepetitions(numbersInCombination, startSetNumber, endSetNumber);

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