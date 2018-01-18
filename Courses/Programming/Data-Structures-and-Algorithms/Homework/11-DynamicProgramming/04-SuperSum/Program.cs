// TASK
// http://bgcoder.com/Contests/Practice/DownloadResource/170

namespace SuperSumRecursiveTask
{
    using System;
    using System.IO;

    internal class Program
    {
        // expected 6
        static string test1 = @"1 3";

        // expected 10
        static string test2 = @"2 3";

        static string test0 = @"2 4";

        private static void Main()
        {
            //var sr = new StringReader(test0);
            //Console.SetIn(sr);

            var input = Console.ReadLine().Split(' ');
            var k = int.Parse(input[0]);
            var n = int.Parse(input[1]);

            Console.WriteLine(SuperSum(k, n));
        }

        private static int SuperSum(int k, int n)
        {
            if (k==0)
            {
                return n;
            }

            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += SuperSum(k-1, i);
            }

            return sum;
        }
    }
}