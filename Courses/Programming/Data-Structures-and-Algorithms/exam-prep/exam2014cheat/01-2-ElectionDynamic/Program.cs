using System;
using System.Numerics;

namespace Problem
{
    internal class Program
    {
        public static int count = 0;

        private static int k;

        private static int n;

        private static int[] p;

        private static BigInteger[] arr;

        private static void Main()
        {
            //Inputs.SetInput("010");

            //Inputs.SetInput("001");
            GetInput();
            Solve();
        }

        private static void Solve()
        {
            BigInteger sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += p[i];
            }

            arr = new BigInteger[(int)sum + 1];
            arr[0] = 1;
            for (int i = 0; i < n; i++)
            {
                var num = p[i];
                for (int j = arr.Length - 1; j >= 0; j--)
                {
                    if (arr[j] > 0)
                    {
                        arr[j + num] += arr[j];
                    }
                }
            }

            sum = 0;
            for (int i = k; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            Console.WriteLine(sum);
        }

        private static void GetInput()
        {
            k = int.Parse(Console.ReadLine());
            n = int.Parse(Console.ReadLine());
            p = new int[n];
            for (int i = 0; i < n; i++)
            {
                p[i] = int.Parse(Console.ReadLine());
            }
        }
    }
}