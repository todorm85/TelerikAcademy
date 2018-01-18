using System;
//### Problem 04. Sub-string in text
//*	Write a program that finds how many times a sub-string is contained in a given text (perform case insensitive search).
class Program
{
    static void Main()
    {
        Console.Write("Enter text: ");
        string input = Console.ReadLine();
        Console.Write("Enter text to search: ");
        string substring = Console.ReadLine();

        // this algo is faster than using any find methods (hint* look at line 34)
        int substringCount = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == substring[0])
            {
                int counter = 0;
                for (int j = 0; j < substring.Length && i + j < input.Length; j++)
                {
                    if (input[i + j] == substring[j])
                    {
                        counter++;
                    }
                    else break;
                }

                if (counter == substring.Length)
                {
                    substringCount++;
                }

                i = i + counter - 1;
            }
        }

        Console.WriteLine(substringCount);
    }
}

