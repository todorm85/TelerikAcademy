// TASK
// http://bgcoder.com/Contests/Practice/DownloadResource/164

namespace _03_Tribonachi
{
    using System;
    using System.IO;

    internal class Program
    {
        private static void Main()
        {
            //GetSampleInputStream();

            var input = Console.ReadLine().Split(' ');
            var trib1 = int.Parse(input[0]);
            var trib2 = int.Parse(input[1]);
            var trib3 = int.Parse(input[2]);
            var n = int.Parse(input[3]);

            int i = 4;
            while (i <= n)
            {
                var newTrib = trib1 + trib2 + trib3;
                trib1 = trib2;
                trib2 = trib3;
                trib3 = newTrib;
                i++;
            }

            Console.WriteLine(trib3);
        }

        private static void GetSampleInputStream()
        {
            // expected 3
            string test1 = "1 1 1 4";

            // expected 16
            string test2 = "2 3 4 5";

            var sr = new StringReader(test2);

            Console.SetIn(sr);
        }
    }
}