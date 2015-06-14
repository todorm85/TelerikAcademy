using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

////Problem 1. StringBuilder.Substring
////•	Implement an extension method Substring(int index, int length) for the class StringBuilder that returns new StringBuilder and has the same functionality as Substring in the class String.

namespace Problem1
{
    public static class Extension
    {
        public static void Substring(this StringBuilder sb, int startIndex)
        {
            sb.Remove(0, startIndex);
        }

        public static void Substring(this StringBuilder sb, int startIndex, int length)
        {
            sb.Remove(0, startIndex);
            sb.Remove(length, sb.Length - length);
        }
    }

    class TestExtension
    {
        static void Main()
        {
            StringBuilder sb = new StringBuilder("123456789");
            sb.Substring(2);
            Console.WriteLine(sb);
            sb = new StringBuilder("123456789");
            sb.Substring(2,2);
            Console.WriteLine(sb);
            sb = new StringBuilder("123456789");
            sb.Substring(3, 5);
            Console.WriteLine(sb);
        }
    }
}
