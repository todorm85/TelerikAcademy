using System;
using System.Collections.Generic;

namespace Problem
{
    internal class Program
    {
        public static int count = 0;

        private static int k;

        private static int n;

        private static int[] p;

        private static int[] arr;

        private static void Main()
        {
            //Inputs.SetInput("003");
            GetInput();
            Solve();
        }

        private static void Solve()
        {
            for (int i = 1; i <= p.Length; i++)
            {
                arr = new int[i];
                numsInCom = i;
                GenerateCombinationsNoRepetitions(0, 0);
            }

            Console.WriteLine(count);
        }

        static int numsInCom;
        private static void GenerateCombinationsNoRepetitions(int index, int start)
        {
            if (index >= numsInCom)
            {
                ProcessCombination(arr);
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    arr[index] = i;
                    GenerateCombinationsNoRepetitions(index + 1, i + 1);
                }
            }
        }

        private static void ProcessCombination(int[] subset)
        {
            var sum = 0;
            for (int i = 0; i < subset.Length; i++)
            {
                sum += p[subset[i]];
            }

            if (sum >= k)
            {
                count++;
            }
        }

        private static void GetInput()
        {
            k = int.Parse(Console.ReadLine());
            n = int.Parse(Console.ReadLine());
            p = new int[n];
            for (int i = 0; i < n; i++)
            {
                p[i] = int.Parse(Console.ReadLine());
            }
        }
    }
}