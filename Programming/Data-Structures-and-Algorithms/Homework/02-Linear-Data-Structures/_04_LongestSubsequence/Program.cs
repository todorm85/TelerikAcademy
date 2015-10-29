//Write a method that finds the longest subsequence of equal numbers in given List and returns the result as new List<int>.

//Write a program to test whether the method works correctly.

using System;
using System.Collections.Generic;
using Common;

namespace _04_LongestSubsequence
{
    public class Program
    {
        public static void Main()
        {
            var testList = new List<int>() { 1, 5, 5, 5, 5, 5, 2, 2, 3, 3, 3, 3 };
            var expected = "5 5 5 5 5";
            TestLongestSubsequence(testList, expected);

            testList = new List<int>() { 1, 5, 5, 5, 5, 5, 2, 2, 3, 3, 3, 3, 3, 3 };
            expected = "3 3 3 3 3 3";
            TestLongestSubsequence(testList, expected);

            testList = new List<int>() { 1, 1, 1, 1, 1, 5, 5, 2, 2, 3, 3 };
            expected = "1 1 1 1 1";
            TestLongestSubsequence(testList, expected);
        }

        private static void TestLongestSubsequence<T>(List<T> numbers, string expected)
            where T : IComparable
        {
            var longestSubsequence = GetLongestSubsequenceOfEqualElements<T>(numbers);

            Console.WriteLine($"Test result: { string.Join(" ", longestSubsequence) == expected}");
        }

        public static List<T> GetLongestSubsequenceOfEqualElements<T>(List<T> numbers)
            where T : IComparable
        {
            List<T> longestSequence = new List<T>();
            var currentSequence = new List<T>();
            currentSequence.Add(numbers[0]);
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i].CompareTo(numbers[i - 1]) == 0)
                {
                    currentSequence.Add(numbers[i]);
                    if (currentSequence.Count > longestSequence.Count)
                    {
                        longestSequence = new List<T>(currentSequence);
                    }
                }
                else
                {
                    currentSequence = new List<T>();
                    currentSequence.Add(numbers[i]);
                }
            }

            return longestSequence;
        }
    }
}