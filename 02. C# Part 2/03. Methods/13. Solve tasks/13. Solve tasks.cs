using System;
//### Problem 13. Solve tasks
//*	Write a program that can solve these tasks:
//    *	Reverses the digits of a number
//    *	Calculates the average of a sequence of integers
//    *	Solves a linear equation `a * x + b = 0`
//*	Create appropriate methods.
//*	Provide a simple text-based menu for the user to choose which task to solve.
//*	Validate the input data:
//    *	The decimal number should be non-negative
//    *	The sequence should not be empty
//    *	`a` should not be equal to `0`
class Program
{
    static void Main()
    {
        Console.WriteLine("Choose task:");
        Console.WriteLine("(1) Reverse digits of number");
        Console.WriteLine("(2) Calculates the average of a sequence of integers");
        Console.WriteLine("(3) Solve a linear equation a * x + b = 0");
        string selection = Console.ReadLine();

        switch (selection)
        {
            case "1":
                ReverseDigits();
                break;

            case "2":
                SequenceAverage();
                break;

            case "3":
                SolveLinearEquation();
                break;

            default:
                Console.WriteLine("Invalid Input");
                break;
        }
    }

    static void ReverseDigits()
    {
        Console.Write("Enter number to reverse: ");
        int num = int.Parse(Console.ReadLine());
        if (num < 0)
        {
            Console.WriteLine("Number should be positive");
            return;
        }

        char[] input = num.ToString().ToCharArray();
        Array.Reverse(input);
        Console.Write("Reversed Number: ");
        for (int i = 0; i < input.Length; i++)
        {
            Console.Write(input[i]);
        }
    }

    static void SequenceAverage()
    {
        Console.Write("Enter array (members delimited by space: ");
        string input = Console.ReadLine();
        if (input == "")
        {
            Console.WriteLine("Array should not be empty");
            return;
        }

        string[] arrStr = input.Split(' ');

        int[] arr = new int[arrStr.Length];
        double sum = 0;
        for (int i = 0; i < arrStr.Length; i++)
        {
            arr[i] = int.Parse(arrStr[i]);
            sum += arr[i];
        }

        if (arr.Length == 0)
        {
            Console.WriteLine("Sequence should not be empty");
            return;
        }

        Console.WriteLine("Average is " + arr.Length);
    }

    static void SolveLinearEquation()
    {
        Console.Write("Enter a: ");
        double a = int.Parse(Console.ReadLine());
        if (a==0)
        {
            Console.WriteLine("'a' should not be '0'");
            return;
        }

        Console.Write("Enter b: ");
        double b = int.Parse(Console.ReadLine());

        double result = (-b) / a;
        Console.WriteLine("Result: " + result);
    }
}

