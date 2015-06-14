using System;

//Problem 4. Multiplication Sign
//• Write a program that shows the sign (+, - or 0) of the product of three real numbers,
//without calculating it. ◦ Use a sequence of  if  operators.

//Examples:
//a       b       c       result
//5       2       2       + 
//-2      -2      1       + 
//-2      4       3       - 
//0       -2.5    4       0 
//-1      -0.5    -5.1    - 

class Multiplication_Sign
{
    static void Main()
    {
        Console.Write("Enter number 1 ( (+/-)5.0 x 10e-324 to (+/-)1.7 x 10e+308 ): ");
        double num1 = double.Parse(Console.ReadLine());
        Console.Write("Enter number 2 ( (+/-)5.0 x 10e-324 to (+/-)1.7 x 10e+308 ): ");
        double num2 = double.Parse(Console.ReadLine());
        Console.Write("Enter number 3 ( (+/-)5.0 x 10e-324 to (+/-)1.7 x 10e+308 ): ");
        double num3 = double.Parse(Console.ReadLine());
        char result = ' ';

        if ((num2 < 0 && num3 < 0) || (num2 > 0 && num3 > 0)) { result = '+'; }
        else { result = '-'; }

        if (num1 > 0 && result == '+' || num1 < 0 && result == '-') { result = '+'; }
        else { result = '-'; }

        if (num1 == 0 || num2 == 0 || num3 == 0) { result = '0'; }

        Console.WriteLine(result);
    }
}

