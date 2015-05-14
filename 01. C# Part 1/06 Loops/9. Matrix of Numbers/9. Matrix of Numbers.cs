using System;

//Problem 9. Matrix of Numbers
//• Write a program that reads from the console a positive integer number 
//n  (1 = n = 20) and prints a matrix like in the examples below. Use two nested loops.

//Examples:
//n = 2   matrix      n = 3   matrix      n = 4   matrix
//        1 2                 1 2 3               1 2 3 4
//        2 3                 2 3 4               2 3 4 5
//                            3 4 5               3 4 5 6
//                                                4 5 6 7

class Matrix_of_Numbers
{
    static void Main()
    {
        Console.Write("Enter integer (0 to 20): ");
        byte n = byte.Parse(Console.ReadLine());

        for (byte i = 1; i <= n; i++)
        {
            for (byte j = i; j <= i+n-1; j++)
            {
                Console.Write(j + " ");
            }
            Console.WriteLine();
        }
    }
}
