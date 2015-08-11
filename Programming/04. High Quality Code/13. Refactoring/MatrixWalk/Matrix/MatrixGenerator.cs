using System;

namespace WalkMatrix
{
    public class MatrixGenerator
    {
        private static int[] rowDirections = { 1, 1, 1, 0, -1, -1, -1, 0 };
        private static int[] colDirections = { 1, 0, -1, -1, -1, 0, 1, 1 };

        private static int currentDirectionIndex = 0;

        public static int[,] Generate(int matrixSize)
        {
            int[,] matrix = new int[matrixSize, matrixSize];
            int stepCount = 0,
                row = 0,
                col = 0,
                rowDirection,
                colDirection;

            while (row != -1 && col != -1)
            {
                stepCount++;
                rowDirection = rowDirections[currentDirectionIndex];
                colDirection = colDirections[currentDirectionIndex];
                matrix[row, col] = stepCount;

                while (CheckIfFreeNeighbourCellExists(matrix, row, col))
                {
                    if (row + rowDirection >= matrixSize || row + rowDirection < 0 || col + colDirection >= matrixSize || col + colDirection < 0 || matrix[row + rowDirection, col + colDirection] != 0)
                    {
                        while (row + rowDirection >= matrixSize || row + rowDirection < 0 || col + colDirection >= matrixSize || col + colDirection < 0 || matrix[row + rowDirection, col + colDirection] != 0)
                        {
                            GetNextDirection(ref rowDirection, ref colDirection);
                        }
                    }

                    row += rowDirection;
                    col += colDirection;
                    stepCount++;
                    matrix[row, col] = stepCount;
                }

                FindFirstFreeCell(matrix, ref row, ref col);
            }

            return matrix;
        }

        internal static void GetNextDirection(ref int currentRowDirection, ref int currentColDirection)
        {
            currentDirectionIndex++;
            if (currentDirectionIndex >= 8)
            {
                currentDirectionIndex = 0;
            }

            currentRowDirection = rowDirections[currentDirectionIndex];
            currentColDirection = colDirections[currentDirectionIndex];
        }

        internal static bool CheckIfFreeNeighbourCellExists(int[,] arr, int currentRow, int currentCol)
        {
            for (int i = 0; i < 8; i++)
            {
                var rowDirection = rowDirections[i];
                var colDirection = colDirections[i];

                if (currentRow + rowDirection >= arr.GetLength(0) || currentRow + rowDirection < 0)
                {
                    continue;
                }

                if (currentCol + colDirection >= arr.GetLength(1) || currentCol + colDirection < 0)
                {
                    continue;
                }

                if (arr[currentRow + rowDirection, currentCol + colDirection] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        internal static void FindFirstFreeCell(int[,] arr, ref int row, ref int col)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == 0)
                    {
                        row = i;
                        col = j;
                        return;
                    }
                }
            }

            row = -1;
            col = -1;
        }
    }
}
