using System;
using System.IO;
//### Problem 05. Maximal area sum
//*	Write a program that reads a text file containing a square matrix of numbers.
//*	Find an area of size `2 x 2` in the matrix, with a maximal sum of its elements.
//    *	The first line in the input file contains the size of matrix `N`.
//    *	Each of the next `N` lines contain `N` numbers separated by space.
//    *	The output should be a single number in a separate text file.

//_Example:_

//| input | output |
//|-------|--------|
//| 4 <br> 2 3 3 4 <br> 0 2 3 4 <br> 3 7 1 2 <br> 4 3 3 2 | 17 |
class Maximal_area_sum
{
    static void Main()
    {
        int n = 0;
        // first get the size of matrix
        using (StreamReader matrixSource = new StreamReader(@"..\..\matrix.txt"))
        {
            n = int.Parse(matrixSource.ReadLine());
        }
        // initialize array to hold matrix values
        int[,] matrix = new int[n, n];
        using (StreamReader matrixSource = new StreamReader(@"..\..\matrix.txt"))
        {
            string lineSkipper = matrixSource.ReadLine(); // this is just to skip the first line
            string row = matrixSource.ReadLine();   // read row of matrix values
            int rowNum = 0;
            while (row != null)
            {
                string[] rowArr = row.Split(' ');
                for (int i = 0; i < n; i++)
                {
                    matrix[rowNum, i] = int.Parse(rowArr[i]);
                }

                rowNum++;
                row = matrixSource.ReadLine();
            }
        }

        // finally check for max sum in matrix (using slightly modified algorithm from Multidimensional Arrays homework)
        Console.WriteLine(MaxSumInMatrix(n, n, matrix, 2));
    }

    static int MaxSumInMatrix(int n, int m, int[,] matrix, int srchSize)
    {
        int maxSum = int.MinValue;

        if (srchSize > matrix.GetLength(0) || srchSize > matrix.GetLength(1))
        {
            throw new ArgumentOutOfRangeException("Square search size cannot be bigger than matrix size!");
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

        return maxSum;
    }
}

