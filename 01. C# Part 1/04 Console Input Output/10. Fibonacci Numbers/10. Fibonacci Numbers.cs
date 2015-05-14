using System;

//Problem 10. Fibonacci Numbers
//• Write a program that reads a number  n  and prints on the console the first
//n  members of the Fibonacci sequence (at a single line, separated by comma and
//space -  , ) :  0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, … .

//Note: You may need to learn how to use loops.

//Examples:
//n           comments
//1           0 
//3           0 1 1 
//10          0 1 1 2 3 5 8 13 21 34 

class Fibonacci_Numbers
{
    static void Main()
    {
        Console.Write("Enter n (0 to 4,294,967,295): ");
        uint n = uint.Parse(Console.ReadLine());
        int num1 = 0;
        int num2 = 1;

        //We will print two numbers per cycle. problem is if n is odd then we need to skip the second number in the last cycle. 
        //We limit the cycle to i < n/2 + n%2. This way when n is even we get n/2 cycles (0 to n/2-1). 
        //If n is odd we get n/2 + 1 (from 0 to n/2) cycles and during the last cycle (i=n/2) we print only the first number num1.

        for (int i = 0; i < (n / 2) + (n % 2); i++)
        {
            Console.Write("{0}, ", num1);

            if (n % 2 != 0 && i == n / 2)   break;

            Console.Write("{0}, ", num2);
            num1 += num2;
            num2 += num1;
        }
        Console.WriteLine("...");
    }
}

