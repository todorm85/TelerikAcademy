using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem
{
    internal class Program
    {
        private static int totalCount = 0;

        //static int[] initial;
        private static List<List<int>> vars = new List<List<int>>();
        private static Dictionary<string, long> memo;
        static long varsCount = 0;
        private static void Main()
        {
            //Inputs.SetInput("000.001");
            Inputs.SetInput(3);

            var t = GetInput();
            Solve(t);
        }

        private static void Solve(int[] t)
        {
            //initial = t.ToArray();

            var tCopy = t.ToArray();
            for (int i = 0; i < tCopy.Length; i++)
            {
                totalCount += tCopy[i];
            }

            memo = new Dictionary<string, long>();

            FindVars(t.ToArray(), new List<int>());
            Console.WriteLine(vars.Count);
        }

        private static void FindVars(int[] treesCount, List<int> c)
        {
            if (c.Count == totalCount
                //|| (treesCount[0] < ((initial[0] == 0) ? 1 : initial[0])
                //&& treesCount[1] < ((initial[1] == 0) ? 1 : initial[1])
                //&& treesCount[2] < ((initial[2] == 0) ? 1 : initial[2])
                //&& treesCount[3] < ((initial[3] == 0) ? 1 : initial[3]))
                )
            {
                vars.Add(c);
                varsCount++;
            }

            if (c.Count == totalCount)
            {
                return;
            }

            for (int t = 0; t < 4; t++)
            {
                if (treesCount[t] == 0)
                {
                    continue;
                }

                if (c.Count == 0)
                {
                    treesCount[t]--;
                    c.Add(t);
                    FindVars(treesCount.ToArray(), c.ToList());
                    treesCount[t]++;
                    c.RemoveAt(c.Count - 1);
                    continue;
                }

                if (c[c.Count - 1] != t)
                {

                    //string hash = c[c.Count - 1] + " " + string.Join("", treesCount);
                    //if (!memo.ContainsKey(hash))
                    //{

                    //}


                    treesCount[t]--;
                    c.Add(t);

                    FindVars(treesCount.ToArray(), c.ToList());

                    treesCount[t]++;
                    c.RemoveAt(c.Count - 1);

                    //memo.Add(hash);
                }
            }
        }

        private static int[] GetInput()
        {
            var t = new int[4];
            t[0] = int.Parse(Console.ReadLine());
            t[1] = int.Parse(Console.ReadLine());
            t[2] = int.Parse(Console.ReadLine());
            t[3] = int.Parse(Console.ReadLine());
            return t;
        }
    }
}