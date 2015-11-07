namespace _08_MatrixShortestPath
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
        private static bool pathIsFound = false;
        private static Queue<Tuple<int, int, char[,]>> movesQueue = new Queue<Tuple<int, int, char[,]>>();

        private static void Main()
        {
            var matrix = new char[,]
            {
                {'x', ' ', ' ', ' ' },
                {'x', ' ', ' ', ' '  },
                {' ', ' ', 'x' , ' ' },
                {' ', ' ', 'x' , ' ' },
                {' ', ' ', 'x' , ' ' },
                {' ', ' ', 'x' , ' ' },
                {' ', ' ', ' ' , ' ' },

            };

            FindShortestPath(matrix, new Tuple<int, int>(4, 0), new Tuple<int, int>(2, 3));
        }

        private static void FindShortestPath(char[,] matrix, Tuple<int, int> startCell, Tuple<int, int> endCell)
        {
            var endRow = endCell.Item1;
            var endCol = endCell.Item2;
            if (matrix[endRow, endCol] != PassableCell)
            {
                throw new ArgumentException("NonPassable cell cannot be a destination.");
            }

            matrix[endRow, endCol] = DestinationCell;

            var startRow = startCell.Item1;
            var startCol = startCell.Item2;

            var firstMove = new Tuple<int, int, char[,]> (startRow, startCol, matrix);
            TraverseShortestPath(firstMove);
        }

        private static void TraverseShortestPath(Tuple<int, int, char[,]> move)
        {
            var row = move.Item1;
            var col = move.Item2;
            var matrixState = move.Item3;

            if (pathIsFound)
            {
                return;
            }

            if (matrixState[row, col] == DestinationCell)
            {
                PrintMatrix(matrixState);
                Console.WriteLine();
                pathIsFound = true;
                return;
            }

            matrixState[row, col] = TraversedCell;
            var availableCells = GetAvailableNeighbourCells(move);
            if (availableCells.Count <= 0)
            {
                return;
            }

            foreach (var availableCell in availableCells)
            {
                var newMove = new Tuple<int, int, char[,]>(availableCell.Item1, availableCell.Item2, (char[,])matrixState.Clone());
                movesQueue.Enqueue(newMove);
            }

            while (movesQueue.Count > 0)
            {
                TraverseShortestPath(movesQueue.Dequeue());
            }
        }

        private static List<Tuple<int, int>> GetAvailableNeighbourCells(Tuple<int, int, char[,]> move)
        {
            var row = move.Item1;
            var col = move.Item2;
            var matrix = move.Item3;

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
                    Console.Write(matrix[r, c] + "|");
                }

                Console.WriteLine();
                //Console.WriteLine(string.Join("-", new string[matrix.GetLength(0) + 1]));
            }
        }
    }
}
