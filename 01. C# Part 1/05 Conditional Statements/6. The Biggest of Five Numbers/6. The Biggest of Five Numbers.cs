using System;

//Problem 6. The Biggest of Five Numbers
//• Write a program that finds the biggest of five numbers by using only five if statements.

//Examples:
//a       b       c       d       e       biggest
//5       2       2       4       1       5 
//-2      -22     1       0       0       1 
//-2      4       3       2       0       4 
//0       -2.5    0       5       5       5 
//-3      -0.5    -1.1    -2      -0.1    -0.1 

class The_Biggest_of_Five_Numbers
{
    static void Main()
    {
        Console.Write("Enter number 1 ( (+/-)5.0 x 10e-324 to (+/-)1.7 x 10e+308 ): ");
        double num1 = double.Parse(Console.ReadLine());
        Console.Write("Enter number 2 ( (+/-)5.0 x 10e-324 to (+/-)1.7 x 10e+308 ): ");
        double num2 = double.Parse(Console.ReadLine());
        Console.Write("Enter number 3 ( (+/-)5.0 x 10e-324 to (+/-)1.7 x 10e+308 ): ");
        double num3 = double.Parse(Console.ReadLine());
        Console.Write("Enter number 4 ( (+/-)5.0 x 10e-324 to (+/-)1.7 x 10e+308 ): ");
        double num4 = double.Parse(Console.ReadLine());
        Console.Write("Enter number 5 ( (+/-)5.0 x 10e-324 to (+/-)1.7 x 10e+308 ): ");
        double num5 = double.Parse(Console.ReadLine());

        double max = num1;
        max = (num2 > max) ? num2 : max;
        max = (num3 > max) ? num3 : max;
        max = (num4 > max) ? num4 : max;
        max = (num5 > max) ? num5 : max;

        Console.WriteLine("Max: " + max);

        //to my mind this is the best algorithm, it doesn`t use extra variables and is very very simple.
        //it works, as i wrote in the forum, because if the first number is bigger than the second, 
        //and if the third is bigger than the first, the second cannot be bigger than the third. So there u go,
        //the max variable will be sure to store the biggest of fives, after 4 sequential checks.
    }
}

