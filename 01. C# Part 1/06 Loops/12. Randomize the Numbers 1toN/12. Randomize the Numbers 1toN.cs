using System;

//Problem 12.* Randomize the Numbers 1…N
//• Write a program that enters in integer  n  and prints the numbers 
//1, 2, …, n  in random order.

//Examples:
//n       randomized numbers 1…n
//3       2 1 3 
//10      3 4 8 2 6 7 9 1 10 5 

//Note: The above output is just an example. Due to randomness, 
//your program most probably will produce different results. 
//You might need to use arrays.

class Randomize_the_Numbers_1_N
{
    static void Main()
    {
        start:
        Console.Write("Enter an integer (0 to 4,294,967,295): ");
        uint n = uint.Parse(Console.ReadLine());

        n = n % 10;

        for (uint i = 1; i <= n; i++)
        {
            if ( n % (i+1) == 0)
            {
                Console.Write(i+" ");
            }
        }

        for (int i = 1; i <= n; i++)
        {
            if ( n % (i+1) != 0)
            {
                Console.Write(i + " ");
            }
        }
        goto start;
    }
}
