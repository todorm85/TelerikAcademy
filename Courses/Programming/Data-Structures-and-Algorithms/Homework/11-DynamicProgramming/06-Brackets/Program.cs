using System;
using System.IO;

namespace BracketsRecursive
{
    internal class Program
    {
        // expected 2
        static string test1 = @"????(?";

        // expected 1
        static string test2 = @"()(?";

        // expected 5
        static string test3 = @"??????";

        // expected 2
        static string test0 = @"??????";

        static char[] s;
        static int sLen;

        private static void Main()
        {
            //var sr = new StringReader(test3);
            //Console.SetIn(sr);

            // s - the sequence of brackets
            // o - count of open brackets
            s = Console.ReadLine().ToCharArray();
            sLen = s.Length;

            int count = CountBrackets(0, 0); 

            Console.WriteLine(count);
        }

        /// <summary>
        /// counts possible variations given brackets condition
        /// </summary>
        /// <param name="i">the currently reached index from which to start checking</param>
        /// <param name="o">the count of open brackets</param>
        /// <returns></returns>
        private static int CountBrackets(int i, int o)
        {
            if (sLen - i < o)
            {
                return 0;
            }

            if (sLen - i == 1)
            {
                if ((s[i] == '?' || s[i] == ')') && o == 1)
                {
                    return 1;
                }

                return 0;
            }

            int count = 0;

            if (s[i] == '?')
            {
                count += CountBrackets(i+1, o + 1);

                if (o > 0)
                {
                    count += CountBrackets(i + 1, o - 1);
                }

                return count;
            }

            if (s[i] == '(')
            {
                o++;
            }
            else
            {
                o--;
            }

            if (o < 0)
            {
                return 0;
            }

            count += CountBrackets(i + 1, o);

            return count;
        }
    }
}