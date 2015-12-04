namespace _01_GoshoPesho
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Inputs
    {
        public static void SetInput(int n)
        {
            //var sb = new StringReader(input);
            var sb = new StreamReader($@"..\..\tests\test.00{n}.in.txt");

            Console.SetIn(sb);

            sb = new StreamReader($@"..\..\tests\test.00{n}.out.txt");
            var expected = sb.ReadLine();

            Console.WriteLine($"expected: {expected}");

        }

        // 7
        public static string input1 = @"18 30
1 17
11 4
1 8 15
1 9 1
1 14 100
2 4 100
2 8 10
2 9 100
3 9 100
3 10 3
3 14 1
4 9 1
4 10 3
4 11 1
5 11 6
5 16 7
6 7 1
6 11 1
6 15 7
6 16 1
7 11 3
7 15 2
7 18 1
8 18 1
10 12 4
10 13 6
11 12 5
12 13 10
12 17 100
13 14 2
15 16 10
16 17 2";

    }
}
