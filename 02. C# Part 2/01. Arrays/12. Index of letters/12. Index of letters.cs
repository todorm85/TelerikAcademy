using System;
//### Problem 12. Index of letters
//*	Write a program that creates an array containing all letters from the alphabet (`A-Z`).
//*	Read a word from the console and print the index of each of its letters in the array.
class Program
{
    static void Main()
    {
        //first we create and populate the array with capital and lower case letters
        char[] arr = new char [52];

        for (int idx = 0; idx < 26; idx++)
            arr[idx] = (char)(idx+65);

        for (int idx = 26; idx < 52; idx++)
            arr[idx] = (char)(idx+97-26);

        //next ask for word
        Console.Write("Enter word: ");
        string input = Console.ReadLine();

        //next check indexes
        for (int idx = 0; idx < input.Length; idx++)
        {
            for (int idxArr = 0; idxArr < arr.Length; idxArr++)
            {
                if (input[idx] == arr[idxArr])
                {
                    Console.Write("(" + idxArr + ")");
                }
            }
        }
    }
}

