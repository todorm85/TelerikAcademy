using System;

//Problem 1. Sum of 3 Numbers
//• Write a program that reads 3 real numbers from the console and prints their sum.
//Examples:
//a       b       c       sum
//3       4       11      18 
//-2      0       3       1 
//5.5     4.5     20.1    30.1 

class Sum_of_3_Numbers
{
    static void Main()
    {
        Console.Write("Enter three numbers ( (+/-)5.0 x 10e-324 to (+/-)1.7 x 10e+308 ): ");
        double num = double.Parse(Console.ReadLine());
        num += double.Parse(Console.ReadLine());
        num += double.Parse(Console.ReadLine());

        Console.WriteLine("sum is " + num);
    }
}

