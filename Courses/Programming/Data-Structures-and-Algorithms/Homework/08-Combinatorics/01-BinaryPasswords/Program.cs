using System;
using System.Linq;

namespace _01_BinaryPasswords
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var n = input.Count(x => x == '*');
            Console.WriteLine(1L << n);
        }
    }
}