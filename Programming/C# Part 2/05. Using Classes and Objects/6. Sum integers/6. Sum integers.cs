using System;
//### Problem 6. Sum integers
//*	You are given a sequence of positive integer values written into a string, separated by spaces.
//*	Write a function
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter integers: ");
        string[] input = Console.ReadLine().Split(' ');
        int sum = 0;
        for (int i = 0; i < input.Length; i++)
        {
            sum += int.Parse(input[i]);
        }

        Console.WriteLine(sum);
    }
}

