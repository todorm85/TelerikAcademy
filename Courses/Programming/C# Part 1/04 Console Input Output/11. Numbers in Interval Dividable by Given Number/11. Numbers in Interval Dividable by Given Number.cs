using System;

//Problem 11.* Numbers in Interval Dividable by Given Number
//• Write a program that reads two positive integer numbers and prints how many numbers  p
//exist between them such that the reminder of the division by  5  is  0 .

//Examples:
//start       end     p       comments
//17          25      2       20, 25 
//5           30      6       5, 10, 15, 20, 25, 30 
//3           33      6       5, 10, 15, 20, 25, 30 
//3           4       0       - 
//99          120     5       100, 105, 110, 115, 120 
//107         196     18      110, 115, 120, 125, 130, 135, 140, 145, 150, 155, 160, 165, 170, 175, 180, 185, 190, 195 

class Numbers_in_Interval_Dividable_by_Given_Number
{
    static void Main()
    {
        Console.Write("Enter first integer (0 to 4,294,967,295): ");
        uint num1 = uint.Parse(Console.ReadLine());
        Console.Write("Enter second integer (0 to 4,294,967,295): ");
        uint num2 = uint.Parse(Console.ReadLine());
        int p = 0;

        for (uint i = Math.Min(num1,num2); i <= Math.Max(num1,num2); i++)
        {
            p = (i % 5 == 0) ? p + 1 : p;    
        }
        Console.WriteLine("P= " + p);
    }
}

