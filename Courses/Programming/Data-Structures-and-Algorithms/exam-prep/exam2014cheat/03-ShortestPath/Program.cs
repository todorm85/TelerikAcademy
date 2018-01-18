using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Problem
{
    internal class Program
    {
        private static void Main()
        {
            //var sw = MockInput("3");

            var input = GetInput();
            Solve(input);

            //sw.Dispose();
        }

        //private static StreamWriter MockInput(string n)
        //{
        //    Inputs.SetInput("000.00" + n);
        //    var sw = new StreamWriter(@"..\..\test."+n+".out.txt");
        //    Console.SetOut(sw);
        //    return sw;
        //}

        private static void Solve(char[] input)
        {
            var n = input.Count(x => x == '*');
            var vars = Combinatorics.GetAllVariationsWithRepetitions(n, 0, 2);

            var res = new List<string>();
            foreach (var var in vars)
            {
                string dir = "";
                int j = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == '*')
                    {
                        dir += dirs[var[j++]];
                    }
                    else
                    {
                        dir += input[i];
                    }
                }

                res.Add(dir);
            }

            res.Sort();

            Console.WriteLine(res.Count());
            foreach (var r in res)
            {
                Console.WriteLine(r);
            }
        }

        static string dirs = "LRS";

        private static char[] GetInput()
        {
            var input = Console.ReadLine().ToArray();
            return input;
        }
    }

    public static class Combinatorics
    {
        private static List<int[]> allSubsets;
        private static int[] currentSubsetArray;
        private static int countOfNumbersInSubset;
        private static int endSetNumber;

        private static int startSetNumber;

        private static Func<int, int, bool> isSubsetDuplicate;

        public static List<int[]> GetAllVariationsWithRepetitions(int countOfNumbersInVariation, int startNumber, int endNumber)
        {
            isSubsetDuplicate = (previousNumber, currentNumber) => { return false; };

            return GetAllSubsets(countOfNumbersInVariation, startNumber, endNumber);
        }

        public static List<int[]> GetAllVariationsWithoutRepetitions(int countOfNumbersInVariation, int startNumber, int endNumber)
        {
            isSubsetDuplicate = (previousNumber, currentNumber) => { return previousNumber == currentNumber; };

            return GetAllSubsets(countOfNumbersInVariation, startNumber, endNumber);
        }

        public static List<int[]> GetAllCombinationsWithRepetitions(int countOfNumbersInCombination, int startNumber, int endNumber)
        {
            if (endNumber <= startNumber)
            {
                throw new ArgumentException("Invalid set start - end range. Set start number must be smaller than set end number.");
            }

            isSubsetDuplicate = (previousNumber, currentNumber) => { return previousNumber > currentNumber; };

            return GetAllSubsets(countOfNumbersInCombination, startNumber, endNumber);
        }

        public static List<int[]> GetAllCombinationsWithoutRepetitions(int countOfNumbersInCombination, int startNumber, int endNumber)
        {
            isSubsetDuplicate = (previousNumber, currentNumber) => { return previousNumber >= currentNumber; };

            return GetAllSubsets(countOfNumbersInCombination, startNumber, endNumber);
        }

        public static List<int[]> GetAllPermutationsWithoutRepetitions(int startNumber, int endNumber)
        {
            isSubsetDuplicate = (previousNumber, currentNumber) => { return previousNumber == currentNumber; };

            int countOfNumbersInCombination = endNumber - startNumber + 1;
            return GetAllSubsets(countOfNumbersInCombination, startNumber, endNumber);
        }

        /// <summary>
        /// Returns all subsets of countOfNumbersInSubset numbers from a set of numbers, defined by all the integers in the range startSetNumber and endSetNumber inclusive. Uses the isSubsetDuplicate delegate to filter the subsets.
        /// </summary>
        /// <param name="countOfNumbersInSubset">The count of numbers in each subset.</param>
        /// <returns></returns>
        private static List<int[]> GetAllSubsets(int countOfNumbersInSubset, int startNumber, int endNumber)
        {
            Combinatorics.countOfNumbersInSubset = countOfNumbersInSubset;
            startSetNumber = startNumber;
            endSetNumber = endNumber;
            currentSubsetArray = new int[countOfNumbersInSubset];
            allSubsets = new List<int[]>();

            GenerateSubsets(0);
            return allSubsets;
        }

        private static void GenerateSubsets(int currentSubsetIndex)
        {
            if (currentSubsetIndex == countOfNumbersInSubset)
            {
                allSubsets.Add((int[])currentSubsetArray.Clone());
                return;
            }

            for (int currentNumber = startSetNumber; currentNumber <= endSetNumber; currentNumber++)
            {
                bool isDuplicateSubset = false;

                for (int previousNumberIndex = currentSubsetIndex - 1; previousNumberIndex >= 0; previousNumberIndex--)
                {
                    var previousNumber = currentSubsetArray[previousNumberIndex];

                    if (isSubsetDuplicate(previousNumber, currentNumber))
                    {
                        isDuplicateSubset = true;
                        break;
                    }
                }

                if (isDuplicateSubset)
                {
                    continue;
                }

                currentSubsetArray[currentSubsetIndex] = currentNumber;

                GenerateSubsets(currentSubsetIndex + 1);
            }
        }
    }
}