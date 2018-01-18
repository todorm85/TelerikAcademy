namespace Palindromize
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main()
        {
            // Input
            var input = Console.ReadLine();

            var answer = PalindromizeString(input);

            Console.WriteLine(answer);
        }

        private static string PalindromizeString(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                var firstIChars = str.Substring(0, i);
                string firstICharsRev = "";

                firstIChars.ToCharArray().Reverse().ToList().ForEach(x => firstICharsRev += x);
                var candidate = str + firstICharsRev;
                if (isPalindrome(candidate))
                {
                    return candidate;
                }
            }

            return "error";
        }

        private static bool isPalindrome(string input)
        {
            for (int i = 0; i < input.Length / 2; i++)
            {
                if (input[i] != input[input.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}