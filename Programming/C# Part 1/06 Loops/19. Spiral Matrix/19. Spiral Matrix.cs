using System;

//Problem 19.** Spiral Matrix
//• Write a program that reads from the console a positive integer number 
//n  (1 = n = 20) and prints a matrix holding the numbers from  1  to  n*n
//in the form of square spiral like in the examples below.

//Examples:
//n = 2   matrix      n = 3   matrix      n = 4   matrix
//        1 2                 1 2 3               1  2  3  4
//        4 3                 8 9 4               12 13 14 5
//                            7 6 5               11 16 15 6
//                                                10 9  8  7

class Spiral_Matrix
{
    static void Main()
    {
    start:
        Console.Write("Enter integer: ");
        int n = int.Parse(Console.ReadLine());
        int[,] nArr = new int[n, n];    //we define a 2 dimension "square" array for all values to be printed 
        int k = 0; //this is a counter

        for (int j = 0; j <= n / 2; j++)
        //the inner 4 "for" cycles inside this for cycle actually write the perimeter values of the square to the nArr array, 
        //then the outer "for" cycle increments j, so that the 4 "for" inner cycles write the perimeter values of the next inner suqare of numbers and so on until we reach the middle of the square
        {

            for (int i = j; i < n - j; i++)   //this writes the top line of the square
            {
                k++;
                nArr[j, i] = k;
            }

            for (int i = j + 1; i < n - j; i++) //this writes the write side of the square
            {
                k++;
                nArr[i, n - 1 - j] = k;
            }

            for (int i = n - 2 - j; i >= 0 + j; i--) //this is the bottom line of numbers of the square
            {
                k++;
                nArr[n - 1 - j, i] = k;
            }

            for (int i = n - 2 - j; i > 0 + j; i--) //this is the left side of numbers of the squar
            {
                k++;
                nArr[i, j] = k;
            }
        }



        for (int i = 0; i < n; i++)  //this cycle prints the final array to the console
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0,2} ", nArr[i, j]);
            }
            Console.WriteLine();
        }
        goto start;
    }
}
