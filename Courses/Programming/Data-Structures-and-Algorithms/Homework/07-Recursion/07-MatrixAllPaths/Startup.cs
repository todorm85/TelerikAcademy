namespace _07_MatrixAllPaths
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Startup
    {
        private const char DestinationCell = '*';
        private const char NonPassableCell = 'x';
        private const char PassableCell = ' ';
        private const char TraversedCell = '.';

        private static void Main()
        {
            var matrix = new char[,]
            {
                {'x', ' ', ' ', ' ' },
                {'x', ' ', ' ', ' '  },
                {' ', ' ', 'x' , ' ' },

            };

            FindPaths(matrix, new Tuple<int, int>(2, 0), new Tuple<int, int>(2, 3));

        }

        private static void FindPaths(char[,] matrix, Tuple<int, int> startCell, Tuple<int, int> endCell)
        {
            var endRow = endCell.Item1;
            var endCol = endCell.Item2;
            if (matrix[endRow, endCol] != PassableCell)
            {
                throw new ArgumentException("NonPassable cell cannot be a destination.");
            }

            matrix[endRow, endCol] = DestinationCell;

            TraverseAllPossiblePaths(matrix, startCell);
        }

        private static void TraverseAllPossiblePaths(char[,] matrix, Tuple<int, int> cell)
        {
            var row = cell.Item1;
            var col = cell.Item2;

            if (matrix[row,col] == DestinationCell)
            {
                PrintMatrix(matrix);
                Console.WriteLine();
                return;
            }

            matrix[row, col] = TraversedCell;
            var availableMoves = GetAvailableMoves(matrix, cell);
            if (availableMoves.Count <= 0)
            {
                return;
            }

            foreach (var move in availableMoves)
            {
                TraverseAllPossiblePaths((char[,])matrix.Clone(), move);
            }
        }

        private static List<Tuple<int, int>> GetAvailableMoves(char[,] matrix, Tuple<int, int> coordinates)
        {
            var row = coordinates.Item1;
            var col = coordinates.Item2;

            var rowsCount = matrix.GetLength(0);
            var colsCount = matrix.GetLength(1);

            var possibleMoves = new List<Tuple<int, int>>();

            int newRow;
            int newCol;

            // check down
            newRow = row + 1;
            if (newRow < rowsCount)
            {
                if (matrix[newRow, col] == PassableCell || matrix[newRow, col] == DestinationCell)
                {
                    possibleMoves.Add(new Tuple<int, int>(newRow, col));
                }
            }

            // check up
            newRow = row - 1;
            if (newRow >= 0)
            {
                if (matrix[newRow, col] == PassableCell || matrix[newRow, col] == DestinationCell)
                {
                    possibleMoves.Add(new Tuple<int, int>(newRow, col));
                }
            }

            // check left
            newCol = col - 1;
            if (newCol >= 0)
            {
                if (matrix[row, newCol] == PassableCell || matrix[row, newCol] == DestinationCell)
                {
                    possibleMoves.Add(new Tuple<int, int>(row, newCol));
                }
            }

            // check right
            newCol = col + 1;
            if (newCol < colsCount)
            {
                if (matrix[row, newCol] == PassableCell || matrix[row, newCol] == DestinationCell)
                {
                    possibleMoves.Add(new Tuple<int, int>(row, newCol));
                }
            }

            return possibleMoves;
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r,c] + "|");
                }

                Console.WriteLine();
                //Console.WriteLine(string.Join("-", new string[matrix.GetLength(0) + 1]));
            }
        }
    }
}
