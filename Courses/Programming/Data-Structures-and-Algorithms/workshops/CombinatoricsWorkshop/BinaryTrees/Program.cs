namespace BinaryTrees
{
    using System;
    using System.IO;
    using System.Numerics;

    public class Program
    {
        public static BigInteger[] memo;

        public static BigInteger Trees(int n)
        {
            if (n == 2)
            {
                return 2;
            }

            //if (memo[n] != 0)
            //{
            //    return memo[n];
            //}

            BigInteger result = 0;
            for (int i = 2; i < n; i++)
            {
                result += Trees(i);
            }

            //memo[n] = result;
            return result * 2 + 1;
        }

        public static void Main()
        {
            //GetSampleInput();
            var input = Console.ReadLine();

            var groups = new int[26];
            foreach (var ball in input)
            {
                groups[ball - 'A']++;
            }

            int n = input.Length;

            memo = new BigInteger[n + 1];

            var factorials = new long[n + 1];
            factorials[0] = 1;
            for (int i = 0; i < n; i++)
            {
                factorials[i + 1] = factorials[i] * (i + 1);
            }

            long result = factorials[n];

            foreach (var x in groups)
            {
                result /= factorials[x];
            }

            Console.WriteLine(result * Trees(n));
        }

        public static void GetSampleInput()
        {
            var input = @"YBB";
            var reader = new StringReader(input);
            Console.SetIn(reader);
        }
    }
}