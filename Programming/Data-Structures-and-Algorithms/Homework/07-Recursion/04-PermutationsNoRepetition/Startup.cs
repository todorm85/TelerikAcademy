namespace _04_PermutationsNoRepetition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    public static class Startup
    {
        private static void Main()
        {
            var startSetNumber = 1;
            var endSetNumber = 3;

            var permutations = Combinatorics.GetAllPermutationsWithoutRepetitions(startSetNumber, endSetNumber);

            foreach (var permutation in permutations)
            {
                foreach (var item in permutation)
                {
                    Console.Write($"{item} ");
                }

                Console.WriteLine();
            }
        }
    }
}
