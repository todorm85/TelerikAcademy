using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatingPatternMyTry
{
    class Program
    {
        static void MockInput()
        {
            var test1 = @"hellohellohello";
            var sr = new StringReader(test1);
            Console.SetIn(sr);
        }

        static void Main(string[] args)
        {
            MockInput();
            //NaiveSolution();
            Solution();
        }

        private static void Solution()
        {

        }

        private static void NaiveSolution()
        {
            var input = Console.ReadLine();
            var pat = "";
            for (int i = 1; i <= input.Length; i++)
            {
                pat = input.Substring(0, i);
                if (input.Length % pat.Length != 0)
                {
                    continue;
                }

                var match = input.Replace(pat, "");
                if (match.Length == 0)
                {
                    break;
                }
            }

            Console.WriteLine(pat);
        }
    }
}
