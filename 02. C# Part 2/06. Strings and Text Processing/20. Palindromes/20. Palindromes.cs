using System;
using System.Collections.Generic;
//### Problem 20. Palindromes
//*	Write a program that extracts from a given text all palindromes, e.g. `ABBA`, `lamal`, `exe`.
class Program
{
    static void Main()
    {
        string text = "Write a program that extracts from a given text all palindromes, e.g. `ABBA`, `lamal`, `exe`.";
        string[] words = text.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
        List<string> palindromes = new List<string>();

        for (int i = 0; i < words.Length; i++)
        {
            bool isPalindrome = true;
            for (int j = 0; j < words[i].Length/2; j++)
            {
                if (words[i][j]!=words[i][words[i].Length-1-j])
                {
                    isPalindrome = false;
                    break;
                }
            }

            if (isPalindrome && words[i].Length>1)
            {
		        palindromes.Add(words[i]);
	        }
        }

        foreach (var item in palindromes)
        {
            Console.WriteLine(item);
        }
    }
}

