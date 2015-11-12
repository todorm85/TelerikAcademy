using System;
using System.IO;

namespace _03_Divisors
{
    internal class Program
    {
        private static Tuple<int, int> foundNumber = new Tuple<int, int>(int.MaxValue, int.MaxValue);

        private static void Main(string[] args)
        {
            //GenerateInput();
            int[] digits = ParseAnswers();
            Array.Sort(digits);

            PermuteRep(digits, 0, digits.Length);

            Console.WriteLine(foundNumber.Item1);
        }

        private static void PermuteRep(int[] arr, int start, int n)
        {
            int number = ParseNumber(arr);
            int divCount = CountDivisors(number);
            FindMinNum(number, divCount);

            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                {
                    if (arr[left] != arr[right])
                    {
                        Swap(ref arr[left], ref arr[right]);
                        PermuteRep(arr, left + 1, n);
                    }
                }

                // Undo all modifications done by the
                // previous recursive calls and swaps
                var firstElement = arr[left];
                for (int i = left; i < n - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                arr[n - 1] = firstElement;
            }
        }

        private static void FindMinNum(int number, int divCount)
        {
            var currentMinNumber = foundNumber.Item1;
            var currentMinDivCount = foundNumber.Item2;

            if (divCount < currentMinDivCount)
            {
                foundNumber = new Tuple<int, int>(number, divCount);
            }

            if (divCount == currentMinDivCount && number < currentMinNumber)
            {
                foundNumber = new Tuple<int, int>(number, divCount);
            }
        }

        private static int CountDivisors(int number)
        {
            int divCount = 0;
            for (int i = 1; i < number / 2 + 1; i++)
            {
                if (number % i == 0)
                {
                    divCount++;
                }
            }

            divCount++;
            return divCount;
        }

        private static int ParseNumber<T>(T[] arr)
        {
            var number = String.Join("", arr).TrimStart('0');
            return int.Parse(number);
        }

        private static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }

        private static int[] ParseAnswers()
        {
            var askedRabbitsCount = int.Parse(Console.ReadLine());
            var answers = new int[askedRabbitsCount];
            for (int i = 0; i < askedRabbitsCount; i++)
            {
                answers[i] = int.Parse(Console.ReadLine());
            }

            return answers;
        }

        private static void GenerateInput()
        {
            string input = @"2
1
2";
            var reader = new StringReader(input);
            Console.SetIn(reader);
        }
    }
}