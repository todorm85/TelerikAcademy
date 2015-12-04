using System;
using System.IO;

namespace Problem
{
    internal class Inputs
    {
        public static string[] tests = new string[]
        {
            @"1
1
0
0",
            @"2
2
0
0",
            @"1
1
1
1",
            @"3
2
1
1",
            @"1
2
0
1",
        };

        public static string[] testsExpected = new string[]
        {
            @"2",
            @"2",
            @"24",
            @"96",
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