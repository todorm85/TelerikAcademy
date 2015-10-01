using System;
using System.Text;
//### Problem 23. Series of letters
//*	Write a program that reads a string from the console and replaces all series of consecutive identical letters with a single one.

//_Example:_

//|          input          |  output  |
//|:-----------------------:|:--------:|
//| aaaaabbbbbcdddeeeedssaa | abcdedsa |
class Program
{
    static void Main()
    {
        string text = "aaaaabbbbbcdddeeeedssaa";
        StringBuilder sb = new StringBuilder();
        sb.Append(text);
        for (int i = 0; i < sb.Length; i++)
        {
            char letter = sb[i];
            for (int j = i+1; j < sb.Length; j++)
            {
                if (sb[j]==letter)
                {
                    sb.Remove(j, 1);
                    j--;
                }
                else
                {
                    break;
                }
            }
        }
        Console.WriteLine(sb);
    }
}

