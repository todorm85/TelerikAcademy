using System;
using System.Linq;
using System.Collections.Generic;

namespace Problem
{
    internal class Program
    {
        private static int[] p;

        private static string[] t;

        private static int n;

        private static void Main()
        {
            // 1-3
            //Inputs.SetInput("000.002");

            GetInput();

            Solve();
        }
        static List<int> decrIndices = new List<int>();
        static List<int> incrIndices = new List<int>();
        static List<int> bestPath = new List<int>();

        private static void Solve()
        {
            var incr = FindLongestIncreasing();
            var decr = FindLongestDecreasing();
            var max = new int[incr.Length];

            var maxPath = 0;
            for (int i = 0; i < incr.Length; i++)
            {
                max[i] = incr[i] + decr[i];
                if (maxPath < max[i])
                {
                    maxPath = max[i];
                }
            }

            Console.WriteLine(maxPath - 1);
        }

        private static int[] FindLongestDecreasing()
        {
            var decr = Enumerable.Repeat(1, p.Length).ToArray();

            for (int i = p.Length-2; i >= 0; i--)
            {
                for (int j = i + 1; j < p.Length; j++)
                {
                    if (p[i] > p[j])
                    {
                        decr[i] = (decr[i] < decr[j] + 1) ? decr[j] + 1 : decr[i];
                    }
                }
            }

            return decr;
        }

        private static int[] FindLongestIncreasing()
        {
            var incr = Enumerable.Repeat(1, p.Length).ToArray();

            for (int i = 1; i < p.Length; i++)
            {
                for (int j = i-1; j >= 0; j--)
                {
                    if (p[i] > p[j])
                    {
                        incr[i] = (incr[i] < incr[j] + 1) ? incr[j] + 1 : incr[i];
                    }
                }
            }

            return incr;
        }

        private static void GetInput()
        {
            n = int.Parse(Console.ReadLine());
            p = new int[n];
            t = new string[n];

            for (int i = 0; i < n; i++)
            {
                var townInfo = Console.ReadLine().Split(' ');
                var population = int.Parse(townInfo[0]);
                p[i] = population;
                var name = townInfo[1];
                t[i] = name;
            }
        }
    }
}