namespace _09_MatrixLargestEmptyArea
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Startup
    {
        private const char NonPassableCell = 'x';
        private const char PassableCell = ' ';
        private const char TraversedCell = '.';
        private static Queue<Tuple<int, int>> movesQueue = new Queue<Tuple<int, int>>();

        private static void Main()
        {
            var matrix = new char[,]
            {
                {'x', ' ', 'x', ' ' },
                {'x', ' ', 'x', ' ' },
                {' ', ' ', 'x', ' ' },
                {'x', 'x', 'x', 'x' },
                {' ', ' ', 'x', 'x' },
                {' ', ' ', 'x', ' ' },
                {' ', ' ', 'x', ' ' },
                {' ', ' ', 'x', ' ' },
            };

            FindLargestEmptyArea(matrix);
        }

        private static void FindLargestEmptyArea(char[,] matrix)
        {
            var resultMatrix = (char[,])matrix.Clone();
            List<Tuple<int, int>> largestEmptyArea = new List<Tuple<int, int>>();

            while (true)
            {
                var firstEmptyCell = GetFirstEmptyCell(matrix);
                if (firstEmptyCell == null)
                {
                    break;
                }

                var emptyArea = CalculateEmptyArea(matrix, firstEmptyCell);
                if (emptyArea.Count > largestEmptyArea.Count)
                {
                    largestEmptyArea = emptyArea;
                }
            }

            PrintMatrixArea(resultMatrix, largestEmptyArea);
        }

        private static Tuple<int, int> GetFirstEmptyCell(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == PassableCell)
                    {
                        return new Tuple<int, int>(i, j);
                    }
                }
            }

            return null;
        }

        private static List<Tuple<int, int>> CalculateEmptyArea(char[,] matrix, Tuple<int, int> move)
        {
            var emptyArea = new List<Tuple<int, int>>();
            while (true)
            {
                var availableCells = GetAvailableNeighbourCells(move, matrix);
                foreach (var availableCell in availableCells)
                {
                    var newMove = new Tuple<int, int>(availableCell.Item1, availableCell.Item2);
                    emptyArea.Add(new Tuple<int, int>(availableCell.Item1, availableCell.Item2));
                    matrix[availableCell.Item1, availableCell.Item2] = TraversedCell;
                    movesQueue.Enqueue(newMove);
                }

                if (movesQueue.Count == 0)
                {
                    break;
                }

                move = movesQueue.Dequeue();
            }

            return emptyArea;
        }

        private static List<Tuple<int, int>> GetAvailableNeighbourCells(Tuple<int, int> move, char[,] matrix)
        {
            var row = move.Item1;
            var col = move.Item2;

            var rowsCount = matrix.GetLength(0);
            var colsCount = matrix.GetLength(1);

            var possibleMoves = new List<Tuple<int, int>>();

            int newRow;
            int newCol;

            // check down
            newRow = row + 1;
            if (newRow < rowsCount)
            {
                if (matrix[newRow, col] == PassableCell)
                {
                    //matrix[newRow, col] = TraversedCell;
                    possibleMoves.Add(new Tuple<int, int>(newRow, col));
                }
            }

            // check up
            newRow = row - 1;
            if (newRow >= 0)
            {
                if (matrix[newRow, col] == PassableCell)
                {
                    //matrix[newRow, col] = TraversedCell;
                    possibleMoves.Add(new Tuple<int, int>(newRow, col));
                }
            }

            // check left
            newCol = col - 1;
            if (newCol >= 0)
            {
                if (matrix[row, newCol] == PassableCell)
                {
                    //matrix[row, newCol] = TraversedCell;
                    possibleMoves.Add(new Tuple<int, int>(row, newCol));
                }
            }

            // check right
            newCol = col + 1;
            if (newCol < colsCount)
            {
                if (matrix[row, newCol] == PassableCell)
                {
                    //matrix[row, newCol] = TraversedCell;
                    possibleMoves.Add(new Tuple<int, int>(row, newCol));
                }
            }

            return possibleMoves;
        }

        private static void PrintMatrixArea(char[,] resultMatrix, List<Tuple<int, int>> largestEmptyArea)
        {
            foreach (var tuple in largestEmptyArea)
            {
                resultMatrix[tuple.Item1, tuple.Item2] = TraversedCell;
            }

            PrintMatrix(resultMatrix);
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
            Console.WriteLine();
            //Console.ReadLine();
        }
    }
}
