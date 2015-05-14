using System;
//### Problem 02. Reverse string
//*	Write a program that reads a string, reverses it and prints the result at the console.
class Program
{
    static void Main()
    {
        Console.Write("Enter string: ");
        string input = Console.ReadLine();
        char[] reverseInput = input.ToCharArray();
        Array.Reverse(reverseInput);
        input = new string(reverseInput);
        Console.WriteLine(input);
    }
}

