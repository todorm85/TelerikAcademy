using System;

namespace WalkMatrix
{
    public class MatrixGenerator
    {
        public static void GetNextDirection(ref int currentDirectionRow, ref int currentDirectionCol)
        {
            int[][] directions = {
                                     new int[]{1,1},
                                     new int[]{1,0},
                                     new int[]{1,-1},
                                     new int[]{0,-1},
                                     new int[]{-1,-1},
                                     new int[]{-1,0},
                                     new int[]{-1,1},
                                     new int[]{0,1}
                                 };

            int currentDirectionIndex = 0;
            for (int i = 0; i < 8; i++)
            {
                var rowDirection = directions[i][0];
                var colDirection = directions[i][1];
                if (rowDirection == currentDirectionRow && colDirection == currentDirectionCol)
                {
                    currentDirectionIndex = i;
                    break;
                }
            }

            if (currentDirectionIndex == 7)
            {
                currentDirectionIndex = -1;
            }

            currentDirectionRow = directions[currentDirectionIndex + 1][0];
            currentDirectionCol = directions[currentDirectionIndex + 1][1];
        }

        public static bool CheckIfFreeNeighbourCellExists(int[,] arr, int currentRow, int currentCol)
        {
            int[] rowDirections = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] colDirections = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < 8; i++)
            {
                if (currentRow + rowDirections[i] >= arr.GetLength(0) || currentRow + rowDirections[i] < 0)
                {
                    rowDirections[i] = 0;
                }

                if (currentCol + colDirections[i] >= arr.GetLength(0) || currentCol + colDirections[i] < 0)
                {
                    colDirections[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (arr[currentRow + rowDirections[i], currentCol + colDirections[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool FindFirstFreeCell(int[,] arr, ref int row, ref int col)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == 0)
                    {
                        row = i;
                        col = j;
                        return true;
                    }
                }
            }

            return false;
        }

        public static int[,] Generate(int n)
        {
            int[,] matrix = new int[n, n];
            int stepCount = 0,
                row = 0,
                col = 0,
                rowDirection = 1,
                colDirection = 1;

            while (FindFirstFreeCell(matrix, ref row, ref col))
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
            }

            return matrix;
        }        
    }
}
