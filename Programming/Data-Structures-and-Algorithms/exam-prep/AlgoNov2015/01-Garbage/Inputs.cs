using System;
using System.IO;

namespace Problem
{
    internal class Inputs
    {
        public static string[] tests = new string[]
        {
            @"2
Drujba 7 7
1 2
2 3
3 4
3 7
4 5
5 6
6 3
Orlandovci 8 9
1 2
2 3
3 5
5 4
4 1
5 8
5 6
7 8
7 6",
            @"1
Narnia 5 5
1 3
1 4
2 4
2 5
3 5",
            @"3
Mlados 5 4
4 5
1 2
2 3
2 4
Drujba 5 5
4 5
1 2
2 3
2 4
5 3
Lulin 3 3
1 2
2 3
3 1",
            @"1
Levski 7 10
1 2
1 3
2 3
2 4
1 4
4 5
1 7
5 7
5 6
7 6",
        };

        public static string[] testsExpected = new string[]
        {
            @"Drujba Titan
Orlandovci Wolf",
            @"Narnia Wolf",
            @"Mlados Dirty
Drujba Titan
Lulin Wolf",
            @"Levski Dirty",
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