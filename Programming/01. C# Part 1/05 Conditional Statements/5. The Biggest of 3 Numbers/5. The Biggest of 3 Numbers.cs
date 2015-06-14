using System;

//Problem 5. The Biggest of 3 Numbers
//• Write a program that finds the biggest of three numbers.

//Examples:
//a       b       c       biggest
//5       2       2       5 
//-2      -2      1       1 
//-2      4       3       4 
//0       -2.5    5       5 
//-0.1    -0.5    -1.1    -0.1 

class The_Biggest_of_3_Numbers
{
    static void Main()
    {
        Console.Write("Enter number 1 ( (+/-)5.0 x 10e-324 to (+/-)1.7 x 10e+308 ): ");
        double num1 = double.Parse(Console.ReadLine());
        Console.Write("Enter number 2 ( (+/-)5.0 x 10e-324 to (+/-)1.7 x 10e+308 ): ");
        double num2 = double.Parse(Console.ReadLine());
        Console.Write("Enter number 3 ( (+/-)5.0 x 10e-324 to (+/-)1.7 x 10e+308 ): ");
        double num3 = double.Parse(Console.ReadLine());

        double max = num1;
        max = (num2 > max) ? num2 : max;
        max = (num3 > max) ? num3 : max;

        Console.WriteLine("Max: " + max);
    }
}

