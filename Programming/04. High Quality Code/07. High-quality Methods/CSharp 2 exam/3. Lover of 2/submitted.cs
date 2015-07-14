using System;
using System.Numerics;
using System.Linq;

class Program
{
    static void Main()
    {
        int rowSize = int.Parse(Console.ReadLine());
        int colSize = int.Parse(Console.ReadLine());
        int coef = Math.Max(rowSize, colSize);

        int n = int.Parse(Console.ReadLine());
        BigInteger[] codes = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToArray();

        BigInteger[,] matrix = new BigInteger[rowSize, colSize];
        bool[,] mask = new bool[rowSize, colSize];
        // generate matrix
        matrix[rowSize - 1, 0] = 1;
        for (int col = 1; col < colSize; col++)
        {
            matrix[rowSize - 1, col] = matrix[rowSize - 1, col - 1] * 2;
        }

        for (int col = 0; col < colSize; col++)
        {
            for (int row = rowSize - 2; row >= 0; row--)
            {
                matrix[row, col] = matrix[row + 1, col] * 2;
            }
        }

        //// print matrix
        //for (int i = 0; i < rowSize; i++)
        //{
        //    for (int j = 0; j < colSize; j++)
        //    {
        //        Console.Write(matrix[i,j] + " ");
        //    }

        //    Console.WriteLine();
        //}

        BigInteger sum = 0;
        int startRow = rowSize - 1;
        int startCol = 0;

        for (int i = 0; i < codes.Length; i++)
        {
            int nextRow = (int)(codes[i] / coef);
            int nextCol = (int)(codes[i] % coef);

            if (startRow > nextRow)
            {
                for (int row = startRow; row >= nextRow; row--)
                {
                    if (mask[row, startCol] == false)
                    {
                        mask[row, startCol] = true;
                        sum += matrix[row, startCol];
                    }

                    startRow = row;
                }
            }
            else if (startRow < nextRow)
            {

                for (int row = startRow; row <= nextRow; row++)
                {
                    if (mask[row, startCol] == false)
                    {
                        mask[row, startCol] = true;
                        sum += matrix[row, startCol];
                    }

                    startRow = row;
                }
            }

            if (startCol > nextCol)
            {
                for (int col = startCol; col >= nextCol; col--)
                {
                    if (mask[startRow, col] == false)
                    {
                        mask[startRow, col] = true;
                        sum += matrix[startRow, col];
                    }

                    startCol = col;
                }
            }
            else if (startCol < nextCol)
            {
                for (int col = startCol; col <= nextCol; col++)
                {
                    if (mask[startRow, col] == false)
                    {
                        mask[startRow, col] = true;
                        sum += matrix[startRow, col];
                    }

                    startCol = col;
                }
            }
        }

        Console.WriteLine(sum);
    }
}
