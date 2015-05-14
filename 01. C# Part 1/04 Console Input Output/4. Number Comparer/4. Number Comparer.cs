using System;

//Problem 4. Number Comparer
//• Write a program that gets two numbers from the console and prints the greater of them.
//• Try to implement this without if statements.

//Examples:
//a       b       greater
//5       6       6 
//10      5       10 
//0       0       0 
//-5      -2      -2 
//1.5     1.6     1.6 

class Number_Comparer
{
    static void Main()
    {
        Console.Write("Enter number 1 ( (+/-)5.0 x 10e-324 to (+/-)1.7 x 10e+308 ): ");
        double num1 = double.Parse(Console.ReadLine());
        Console.Write("Enter number 2 ( (+/-)5.0 x 10e-324 to (+/-)1.7 x 10e+308 ): ");
        double num2 = double.Parse(Console.ReadLine());

        Console.WriteLine((num1 > num2) ? num1 : num2);
    }
}

