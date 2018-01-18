using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem
{
    internal class Program
    {
        private static int n;
        private static int[] numsInput;
        private static int k;
        private static int minDepth = int.MaxValue;
        private static HashSet<string> permutationsFound = new HashSet<string>();

        private static void Main()
        {
            //Inputs.SetInput("000.002");

            //Inputs.SetInput("001");
            GetInput();
            Solve();
        }

        private static void Solve()
        {
            FindSorting(numsInput, 0);
            if (minDepth != int.MaxValue)
            {
                Console.WriteLine(minDepth - 1);
            }
            else
            {
                Console.WriteLine(-1);
            }
        }

        private static void FindSorting(int[] nums, int depth)
        {
            depth++;
            if (permutationsFound.Contains(string.Join("", nums)))
            {
                return;
            }

            permutationsFound.Add(string.Join("", nums));

            if (CheckIfSorted(nums))
            {
                if (minDepth > depth)
                {
                    minDepth = depth;
                }

                return;
            }

            for (int i = 0; i <= nums.Length - k; i++)
            {
                var first = nums.Take(i).ToArray();
                var last = nums.Skip(i + k).ToArray();
                var middle = nums.Take(i + k).Skip(i).ToArray();
                var permutedNums = middle.Reverse();
                var newSeq = first.Concat(permutedNums).Concat(last).ToArray();
                q.Enqueue(new Tuple<int[], int>(newSeq, depth));
            }

            while (q.Count > 0)
            {
                var next = q.Dequeue();
                FindSorting(next.Item1, next.Item2);
            }
        }

        static Queue<Tuple<int[], int>> q = new Queue<Tuple<int[], int>>();

        private static bool CheckIfSorted(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < nums[i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        private static void GetInput()
        {
            n = int.Parse(Console.ReadLine());
            numsInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            k = int.Parse(Console.ReadLine());
        }
    }
}