using System;

//Problem 1. Exchange If Greater
//• Write an if-statement that takes two double variables a and b and
//exchanges their values if the first one is greater than the second one.
//As a result print the values a and b, separated by a space.

//Examples:
//a       b       result
//5       2       2 5 
//3       4       3 4 
//5.5     4.5     4.5 5.5 

class Exchange_If_Greater
{
    static void Main()
    {
        Console.Write("Enter number 1 ( (+/-)5.0 x 10e-324 to (+/-)1.7 x 10e+308 ): ");
        double num1 = double.Parse(Console.ReadLine());
        Console.Write("Enter number 2 ( (+/-)5.0 x 10e-324 to (+/-)1.7 x 10e+308 ): ");
        double num2 = double.Parse(Console.ReadLine());

        if (num1 > num2)
        {
            num1 += num2;
            num2 = num1 - num2;
            num1 -= num2;
        }
        Console.WriteLine("num1 = {0}, num2 = {1}", num1, num2);
    }
}

