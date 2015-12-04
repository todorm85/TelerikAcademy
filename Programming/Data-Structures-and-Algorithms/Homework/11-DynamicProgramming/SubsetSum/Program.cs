using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem
{
    internal class Program
    {
        private static void Main()
        {
            //Inputs.SetInput("000.001");
            //Inputs.SetInput(0);

            var n = new int[] { 3, 5, 1, 4, 2 };
            var s = 6;
            var o = n.Min();

            if (o < 0)
            {
                o = o * -1;
                for (int i = 0; i < n.Length; i++)
                {
                    n[i] += o;
                }

                s += o;
            }

            var maxSum = n.Sum();
            var prev = new List<int>[maxSum + 1];
            prev[0] = new List<int>();

            for (int i = 0; i < n.Length; i++)
            {
                var num = n[i];
                for (int j = prev.Length - 1; j >= 0; j--)
                {
                    if (prev[j] != null)
                    {
                        if (prev[j + num] == null)
                        {
                            prev[j + num] = new List<int>();
                        }

                        prev[j + num].Add(j);
                    }
                }
            }

            if (prev[s] != null)
            {
                var dound = FindMembers(s, prev, n.ToList());
            }
        }

        static List<int> nums = new List<int>();
        private static List<List<int>> FindMembers(int s, List<int>[] prev, List<int> av)
        {
            if (s <= 0)
            {
                var newList = new List<List<int>>();
                newList.Add(new List<int>());
                return newList;
            }

            var currentLists = new List<List<int>>();
            for (int i = 0; i < prev[s].Count; i++)
            {
                var num = s - prev[s][i];
                if (!av.Contains(num))
                {
                    continue;
                }

                var index = av.IndexOf(num);
                av.RemoveAt(index);
                var prevLists = FindMembers(prev[s][i], prev, av.ToList());
                av.Add(num);

                foreach (var prevList in prevLists)
                {
                    prevList.Add(num);
                    currentLists.Add(prevList);
                }

            }

            return currentLists;
        }
    }
}