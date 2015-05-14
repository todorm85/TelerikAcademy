using System;
//### Problem 24. Order words
//*	Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.
class Program
{
    static void Main()
    {
        Console.Write("Enter words: ");
        string[] words = Console.ReadLine().Split(' ');

        // using simple sort algo
        for (int i = 0; i < words.Length-1; i++)
        {
            for (int j = i+1; j < words.Length; j++)
            {
                if (words[i].CompareTo(words[j]) > 0)
                {
                    string swap = words[i];
                    words[i] = words[j];
                    words[j] = swap;
                }
            }
        }

        foreach (var item in words)
        {
            Console.WriteLine(item);
        }
    }
}

