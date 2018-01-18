// TASK
// http://bgcoder.com/Contests/Practice/DownloadResource/170

namespace SuperSymDynamic
{
    using System;
    using System.IO;

    internal class Program
    {
        // expected 6
        static string test1 = @"1 3";

        // expected 10
        static string test2 = @"2 3";

        private static void Main()
        {
            //var sr = new StringReader(test2);
            //Console.SetIn(sr);

            var input = Console.ReadLine().Split(' ');
            var k = int.Parse(input[0]);
            var n = int.Parse(input[1]);

            Console.WriteLine(SuperSum(k, n));
        }

        private static int SuperSum(int k, int n)
        {
            // s[i,j] is the superSum for k=i, n=j.
            var s = new int[k + 1, n + 1];

            // for all j: s[0,j] = j from the problem description
            for (int j = 0; j <= n; j++)
            {
                s[0, j] = j;
            }

            for (int i = 1; i <= k; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    // we know that S[k,n] = S[k-1,1] + S[k-1,2] ... S[k-1,n-1] + S[k-1, n]
                    // which can be written also: S[k,n] = S[k,n-1] + S[k-1,n], which we already calculated in the table s
                    s[i, j] = s[i, j - 1] + s[i - 1, j];
                }
            }

            return s[k, n];
        }
    }
}