using System;
//### Problem 1. Allocate array
//*	Write a program that allocates array of `20` integers and initializes each element by its index multiplied by `5`.
//*	Print the obtained array on the console.
class Program
{
    static void Main()
    {
        int[] myArr = new int [20];

        for (int indx = 0; indx < 20; indx++)
        {
            myArr[indx] = indx * 5;
            Console.WriteLine("myArr[{0,2}] = {1}", indx, myArr[indx]);
        }
    }
}

