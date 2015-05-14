using System;

//Problem 11. Random Numbers in Given Range
//• Write a program that enters  3  integers  n ,  min  and  max 
//( min != max ) and prints  n  random numbers in the range  [min...max] .

//Examples:
//n       min         max         random numbers
//5       0           1           1 0 0 1 1 
//10      10          15          12 14 12 15 10 12 14 13 13 11 

//Note: The above output is just an example. Due to randomness, your program most 
//probably will produce different results.

class Random_Numbers_in_Given_Range
{
    static void Main()
    {
    start:
        Console.Write("Enter integer n: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter integer min: ");
        int min = int.Parse(Console.ReadLine());
        Console.Write("Enter integer max: ");
        int max = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {

            if (n % (i + 1) == 0)
            {
                Console.Write(min + (max - min) / (n % (i + 1) + 1) + " ");
            }
            else
            {
                Console.Write(min + (max - min) / (n % (i + 1)) + " ");
            }

        }
        Console.WriteLine();
        goto start;
    }
}
