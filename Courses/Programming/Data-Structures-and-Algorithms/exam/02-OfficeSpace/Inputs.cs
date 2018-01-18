using System;
using System.IO;

namespace Problem
{
    internal class Inputs
    {
        public static string[] tests = new string[]
        {
            @"6
5 2 8 7 3 10
6
0
0
0
0
2 3 4 5",
        };

        public static string[] testsExpected = new string[]
        {
            @"",
        };

        internal static void SetInput(string testNum)
        {
            var ar = new StreamReader(File.Open($@"..\..\tests\test.{testNum}.out.txt", FileMode.Open));
            Console.WriteLine($"Expected: {ar.ReadLine()}");
            var tr = new StreamReader(File.Open($@"..\..\tests\test.{testNum}.in.txt", FileMode.Open));

            Console.SetIn(tr);
        }

        internal static void SetInput(int testNum)
        {
            Console.WriteLine($"Expected:\n{testsExpected[testNum]}\n");
            var tr = new StringReader(tests[testNum]);

            Console.SetIn(tr);
        }
    }
}