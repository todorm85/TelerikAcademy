using System;
//### Problem 01. Fill the matrix
//*	Write a program that fills and prints a matrix of size (n, n) 
class Program
{
    static void Main()
    {
        int n = 5;  // YOUR INPUT HERE!!!!!!!!!!!!!!!!
        int[,] matrix = new int[n, n];
        Random randomNumber = new Random();

        for (int idA = 0; idA < matrix.GetLength(0); idA++)
        {
            for (int idB = 0; idB < matrix.GetLength(1); idB++)
            {
                matrix[idA, idB] = randomNumber.Next(1, 100);
                Console.Write("{0,2} ", matrix[idA,idB]);
            }
            Console.WriteLine();
        }


    }
}

