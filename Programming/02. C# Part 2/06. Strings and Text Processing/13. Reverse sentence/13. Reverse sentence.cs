using System;
using System.Text;
using System.Collections.Generic;

//Problem 13. Reverse sentence• Write a program that reverses the words in given sentence.

class Program
{
    static void Main()
    {
        string sentence = "C# is not C++, not PHP and not Delphi!";

        // get sentence ending char
        char lastChar = sentence[sentence.Length - 1];
        sentence = sentence.Substring(0, sentence.Length - 1);

        string[] words = sentence.Split(' ');

        // get all comma positions and remove from words
        List<int> commas = new List<int>();
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Contains(","))
            {
                commas.Add(i);
                words[i] = words[i].Substring(0, words[i].Length - 1);
            }
        }

        // reverse words
        Array.Reverse(words);

        // insert commas at original positions into reversed array
        if (commas.Count > 0)
        {
            for (int i = 0; i < commas.Count; i++)
            {
                words[commas[i]] += ',';
            }
        }
                
        // join reversed words back into sentence
        string reversedSentence = String.Join(" ", words) + lastChar;
        Console.WriteLine(reversedSentence);
    }
}
