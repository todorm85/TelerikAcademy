using System;
using System.IO;

namespace Problem
{
    public static class Inputs
    {
        public static string[] tests = new string[]
        {
            @"5 5
0 3
2 1
1 4
1 3
4 3",
            @"8 3
0 7
0 4
7 4",
                   @"5 3
4 1
3 0
4 0",
                                  @"8 3
7 3
5 3
3 0"
        };

        public static string[] testsExpected = new string[]
        {
            @"0
2
1
4
3",
            @"0
1
2
3
5
6
7
4",
            @"",
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