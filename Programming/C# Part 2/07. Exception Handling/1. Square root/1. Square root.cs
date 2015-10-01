using System;
//### Problem 1. Square root
//*	Write a program that reads an integer number and calculates and prints its square root.
//    *	If the number is invalid or negative, print `Invalid number`.
//    *	In all cases finally print `Good bye`.
//*	Use `try-catch-finally` block.
class Program
{
    static void Main()
    {
        Console.Write("Enter int: ");
        try
        {
            int n = int.Parse(Console.ReadLine());
            if (n<0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Console.WriteLine(Math.Sqrt(n));
        }

        catch (Exception)
        {
            Console.WriteLine("Invalid number");
        }

        finally
        {
            Console.WriteLine("Good bye");
        }

    }
}

