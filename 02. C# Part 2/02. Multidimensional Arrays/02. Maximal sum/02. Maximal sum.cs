using System;
using System.Collections.Generic;

// ### Problem 02. Maximal sum
// * Write a program that reads a rectangular matrix of size `N x M` and finds in it the square `3 x 3` that has maximal sum of its elements.
class MaximalSumMatrix
{
    static void Main()
    {
        int n = 6;      // YOUR INPUT HERE!!!!!!!!!!!!!!!!
        int m = 6;

        int[,] matrix = new int[n, m];
        Random randmNum = new Random();

        Console.WriteLine("Source matrix is:\n");

        for (int idA = 0; idA < matrix.GetLength(0); idA++)
        {
            for (int idB = 0; idB < matrix.GetLength(1); idB++)
            {
                matrix[idA, idB] = randmNum.Next(1, 100);
                Console.Write("{0,2} ", matrix[idA, idB]);
            }

            Console.WriteLine();
        }

        int srchSize = 3;   // you can change this value to search for bigger squate Ex. 4x4, 5x5
        int maxSum = int.MinValue;

        if (srchSize > matrix.GetLength(0) || srchSize > matrix.GetLength(1))
        {
            Console.WriteLine("\nSquare search size cannot be bigger than matrix size!\n");
            return;
        }

        // find maxSum
        for (int idA = 0; idA < matrix.GetLength(0) - (srchSize - 1); idA++)
        {
            for (int idB = 0; idB < matrix.GetLength(1) - (srchSize - 1); idB++)
            {
                int sum = 0;
                for (int srchIdA = idA; srchIdA < idA + srchSize; srchIdA++)
                {
                    for (int srchIdB = idB; srchIdB < idB + srchSize; srchIdB++)
                    {
                        sum += matrix[srchIdA, srchIdB];
                    }
                }

                maxSum = (sum > maxSum) ? sum : maxSum;
            }
        }

        List<int> results = new List<int>();

        // find all squares of search size with maxSum in matrix
        for (int idA = 0; idA < matrix.GetLength(0) - (srchSize - 1); idA++)
        {
            for (int idB = 0; idB < matrix.GetLength(1) - (srchSize - 1); idB++)
            {
                int sum = 0;
                for (int srchIdA = idA; srchIdA < idA + srchSize; srchIdA++)
                {
                    for (int srchIdB = idB; srchIdB < idB + srchSize; srchIdB++)
                    {
                        sum += matrix[srchIdA, srchIdB];
                    }
                }

                if (sum == maxSum)
                {
                    results.Add(idA);   // results indexA is written to odd indexes
                    results.Add(idB);   // results indexB is written to even indexes
                }
            }
        }

        Console.WriteLine("\nThe matrixes with max sum ({0}) are: ", maxSum);

        // get results indexes: resIdx is row index, resIdx+1 is column index of current result
        for (int resIdx = 0; resIdx < results.Count; resIdx += 2)   
        {
            Console.WriteLine();
            for (int offsetA = 0; offsetA < srchSize; offsetA++)
            {
                for (int offsetB = 0; offsetB < srchSize; offsetB++)
                {
                    Console.Write("{0,2} ", matrix[results[resIdx] + offsetA, results[resIdx + 1] + offsetB]);
                }

                Console.WriteLine();
            }
        }
    }
}
