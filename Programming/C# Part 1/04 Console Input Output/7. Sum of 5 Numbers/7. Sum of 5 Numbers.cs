using System;

//Problem 7. Sum of 5 Numbers
//• Write a program that enters 5 numbers (given in a single line,
//separated by a space), calculates and prints their sum.

//Examples:
//numbers                     sum
//1 2 3 4 5                   15 
//10 10 10 10 10              50 
//1.5 3.14 8.2 -1 0           11.84 

class Sum_of_5_Numbers
{
    static void Main()
    {
        Console.Write("Enter 5 numbers, separated by space character: ");
        string input = Console.ReadLine();
        string[] numbers = input.Split(' ');
        double sum = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            sum += int.Parse(numbers[i]);
        }

        Console.WriteLine("Sum is: " + sum);
    }
}

