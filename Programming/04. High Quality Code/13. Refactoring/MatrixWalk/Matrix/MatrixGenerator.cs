using System;

namespace WalkMatrix
{
    public class MatrixGenerator
    {
        private static int[][] directions = {
                                     new int[]{1,1},
                                     new int[]{1,0},
                                     new int[]{1,-1},
                                     new int[]{0,-1},
                                     new int[]{-1,-1},
                                     new int[]{-1,0},
                                     new int[]{-1,1},
                                     new int[]{0,1}
                                 };

        internal static void GetNextDirection(ref int currentRowDirection, ref int currentColDirection)
        {
            int currentDirectionIndex = 0;
            for (int i = 0; i < 8; i++)
            {
                var rowDirection = directions[i][0];
                var colDirection = directions[i][1];
                if (rowDirection == currentRowDirection && colDirection == currentColDirection)
                {
                    currentDirectionIndex = i;
                    break;
                }
            }

            if (currentDirectionIndex == 7)
            {
                currentDirectionIndex = -1;
            }

            currentRowDirection = directions[currentDirectionIndex + 1][0];
            currentColDirection = directions[currentDirectionIndex + 1][1];
        }

        internal static bool CheckIfFreeNeighbourCellExists(int[,] arr, int currentRow, int currentCol)
        {
            for (int i = 0; i < 8; i++)
            {
                var rowDirection = directions[i][0];
                var colDirection = directions[i][1];

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

        public static int[,] Generate(int n)
        {
            int[,] matrix = new int[n, n];
            int stepCount = 0,
                row = 0,
                col = 0,
                rowDirection = 1,
                colDirection = 1;

            while (row != -1 && col != -1)
            {
                stepCount++;
                rowDirection = 1;
                colDirection = 1;
                matrix[row, col] = stepCount;

                while (CheckIfFreeNeighbourCellExists(matrix, row, col))
                {
                    if (row + rowDirection >= n || row + rowDirection < 0 || col + colDirection >= n || col + colDirection < 0 || matrix[row + rowDirection, col + colDirection] != 0)
                    {
                        while ((row + rowDirection >= n || row + rowDirection < 0 || col + colDirection >= n || col + colDirection < 0 || matrix[row + rowDirection, col + colDirection] != 0))
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
    }
}
