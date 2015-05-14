using System;

//Problem 5. Calculate 1 + 1!/X + 2!/X2 + … + N!/XN
//• Write a program that, for a given two integer numbers  n  and  x ,
//calculates the sum  S = 1 + 1!/x + 2!/x2+ … + n!/xn .
//• Use only one loop. Print the result with  5  digits after the decimal point.

//Examples:
//n   x   S
//3   2   2.75000 
//4   3   2.07407 
//5   -4  0.75781 

class Calculate
{
    static void Main()
    {
        Console.Write("Enter integer n (-2,147,483,648 to 2,147,483,647): ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter integer x (-2,147,483,648 to 2,147,483,647): ");
        int x = int.Parse(Console.ReadLine());
        double s = 1.0;
        double fact = 1.0;
        double fraction = 1.0;

        for (int i = 1; i <= n; i++)
        {
            fact = fact * i;
            fraction = fraction * x;
            s = s + (fact / fraction);
        }
        Console.WriteLine("{0:F5}", s);
    }
}
