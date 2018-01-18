using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

class Program
{
    static void Main()
    {
        string[] words = Console.ReadLine().Split(' ');
        var decoded = new StringBuilder();
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];
            BigInteger num10 = Word17to10Based(word);
            string output = Base10ToWord26(num10);
            decoded.Append(output);
            if (i != words.Length - 1)
            {
                decoded.Append(" ");
            }
        }

        Console.WriteLine(decoded);
    }

    static BigInteger Word17to10Based(string rawInput)
    {
        var letter17AsDecimal = new List<int>();
        for (int i = 0; i < rawInput.Length; i++)
        {
            char letter = Char.ToLower(rawInput[i]);
            letter17AsDecimal.Add(letter - 'a');
        }

        // convert to base10
        BigInteger numeralBase = 17;
        BigInteger decimalNumber = 0;
        for (int i = 0; i < letter17AsDecimal.Count; i++)
        {
            decimalNumber *= numeralBase;
            decimalNumber += (BigInteger)letter17AsDecimal[i];
        }

        return decimalNumber;
    }

    static string Base10ToWord26(BigInteger num)
    {
        // from 10 to other system
        var result = new StringBuilder();
        do
        {
            int remainder = (int)(num % 26);
            num /= 26;
            result.Insert(0, (char)(remainder + 'a'));
        }
        while ((num != 0));
        return result.ToString();
    }
}
