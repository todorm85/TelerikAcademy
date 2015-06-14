using System;

//Problem 7. Calculate N! / (K! * (N-K)!)
//• In combinatorics, the number of ways to choose  k  different members out 
//of a group of  n  different elements (also known as the number of combinations)
//is calculated by the following formula: "https://cloud.githubusercontent.com/assets/3619393/5626060/89cc780e-958e-11e4-88d2-0e1ff7229768.png"
//For example, there are 2598960 ways to withdraw 5 cards out of a standard deck 
//of 52 cards.• Your task is to write a program that calculates  n! / (k! * (n-k)!)
//for given  n  and  k  (1 < k < n < 100). Try to use only two loops.

//Examples:
//n   k   n! / (k! * (n-k)!)
//3   2   3 
//4   2   6 
//10  6   210 
//52  5   2598960 

class Calculate
{
    static void Main()
    {
        Console.Write("Enter number n ( 1 to 100 ): ");
        double n = double.Parse(Console.ReadLine());
        Console.Write("Enter number k ( 1 to 100 ): ");
        double k = double.Parse(Console.ReadLine());

        double factn = 1;
        double factk = 1;
        double factkn = 1;

        for (int i = 1; i <= n; i++)
        {
            factn *= i;

            if (i <= k)
            {
                factk *= i;
            }

            if (i <= n - k)
            {
                factkn *= i;
            }

        }
        Console.WriteLine(factn / (factk * factkn));
    }
}
