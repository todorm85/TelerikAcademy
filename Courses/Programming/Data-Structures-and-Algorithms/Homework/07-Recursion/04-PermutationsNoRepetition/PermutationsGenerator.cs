namespace _04_PermutationsNoRepetition
{
    using System.Collections.Generic;

    public static class PermutationsGenerator
    {
        private static List<int[]> allCombinations = new List<int[]>();
        private static int[] currentCombinationArray;
        private static int countOfNumbersInPermutation;
        private static int endSetNumber;
        private static int startSetNumber;

        /// <summary>
        /// Returns all combinations of countOfNumbersInCombination numbers with repetitions from a set of numbers, defined by all the integers in the range startSetNumber and endSetNumber.
        /// </summary>
        /// <param name="countOfNumbersInPermutation">The count of numbers in combinations.</param>
        /// <returns></returns>
        public static List<int[]> GetAllPermutationsWithoutRepetition(int startSetNumber, int endSetNumber)
        {
            int countOfNumbersInPermutation = endSetNumber - startSetNumber + 1;
            PermutationsGenerator.countOfNumbersInPermutation = countOfNumbersInPermutation;
            PermutationsGenerator.startSetNumber = startSetNumber;
            PermutationsGenerator.endSetNumber = endSetNumber;
            PermutationsGenerator.currentCombinationArray = new int[countOfNumbersInPermutation];

            GenerateNextPermutationWithoutRepetition(0);

            return allCombinations;
        }

        private static void GenerateNextPermutationWithoutRepetition(int currentNumberIndex)
        {
            if (currentNumberIndex == countOfNumbersInPermutation)
            {
                allCombinations.Add((int[])currentCombinationArray.Clone());
                return;
            }

            for (int currentNumber = startSetNumber; currentNumber <= endSetNumber; currentNumber++)
            {
                bool isDuplicateCombination = false;

                // If any of the previous numbers in current combination is bigger than the current number then we have duplicate combination
                for (int previousNumberIndex = currentNumberIndex - 1; previousNumberIndex >= 0; previousNumberIndex--)
                {
                    var previousNumber = currentCombinationArray[previousNumberIndex];

                    if (previousNumber == currentNumber)
                    {
                        isDuplicateCombination = true;
                        break;
                    }
                }

                if (isDuplicateCombination)
                {
                    continue;
                }

                currentCombinationArray[currentNumberIndex] = currentNumber;

                GenerateNextPermutationWithoutRepetition(currentNumberIndex + 1);
            }
        }
    }
}
