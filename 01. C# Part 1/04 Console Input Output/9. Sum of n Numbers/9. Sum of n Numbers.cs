using System;

//Problem 9. Sum of n Numbers
//• Write a program that enters a number  n  and after that enters more  n  numbers and
//calculates and prints their  sum . Note: You may need to use a for-loop. 

//Examples:
//numbers         sum
//3               90 
//20  
//60  
//10  

//5               6.5 
//2  
//-1  
//-0.5  
//4  
//2  

//1               1 
//1 

class Sum_of_n_Numbers
{
    static void Main()
    {
        Console.Write("Count of numbers to enter (0 to 4,294,967,295): ");
        uint numCount = uint.Parse(Console.ReadLine());
        double sum = 0;

        for (int i = 0; i < numCount; i++)
        {
            Console.Write("Enter number {0} ( (+/-)5.0 x 10e-324 to (+/-)1.7 x 10e+308 ): ", i + 1);
            sum += double.Parse(Console.ReadLine());
        }

        Console.WriteLine("Sum: " + sum);
    }
}

