using System;
using System.Numerics;
using System.Linq;

class Program
{
    static void Main()
    {
        int rowSize = int.Parse(Console.ReadLine());
        int colSize = int.Parse(Console.ReadLine());
        Console.ReadLine();
        BigInteger[] codes = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToArray();
        int coefficient = Math.Max(rowSize, colSize);
        BigInteger[] rowCoordinates = codes.Select(x => x / coefficient).ToArray();
        BigInteger[] colCoordinates = codes.Select(x => x / coefficient).ToArray();

        // generate matrix
        BigInteger[,] matrix = GenerateMatrix(rowSize, colSize);

        BigInteger sum = 0;
        bool[,] mask = new bool[rowSize, colSize];
        int startRow = rowSize - 1;
        int nextRow = (int)rowCoordinates[0];
        int startCol = 0;
        int nextCol = (int)colCoordinates[0];
        for (int i = 1; i < codes.Length; i++)
        {
            if (startRow > nextRow)
            {
                for (int row = startRow; row >= nextRow; row--)
                {
                    if (mask[row, startCol] == false)
                    {
                        mask[row, startCol] = true;
                        sum += matrix[row, startCol];
                    }

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
                }
            }

            startRow = (int)rowCoordinates[i - 1];
            nextRow = (int)rowCoordinates[i];
            startCol = (int)colCoordinates[i - 1];
            nextCol = (int)colCoordinates[i];
        }

        Console.WriteLine(sum);
    }

    private static BigInteger[,] GenerateMatrix(int rowSize, int colSize)
    {
        BigInteger[,] matrix = new BigInteger[rowSize, colSize];
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
        return matrix;
    }
}
