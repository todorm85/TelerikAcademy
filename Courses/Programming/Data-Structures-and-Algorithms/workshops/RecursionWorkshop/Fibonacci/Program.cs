using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Program
    {
        private static BigInteger M = 1000000007;

        static void Main()
        {
            BigInteger n = ulong.Parse(Console.ReadLine());
            Console.WriteLine(Fibonacci(n) % M);
        }

        public static BigInteger Fibonacci(BigInteger n)
        {
            BigInteger a = 0;
            BigInteger b = 1;
            // In N steps compute Fibonacci sequence iteratively.
            for (ulong i = 0; i < n; i++)
            {
                BigInteger temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }
    }
}
