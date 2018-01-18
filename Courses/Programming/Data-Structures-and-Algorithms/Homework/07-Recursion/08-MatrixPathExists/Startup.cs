﻿namespace _08_MatrixPathExists
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
        private static Queue<Tuple<int, int>> movesQueue = new Queue<Tuple<int, int>>();

        private static void Main()
        {
            int n = 100;
            var matrix = GenerateLargeEmptyMatrix(n);

            CheckIfPathExists(matrix, new Tuple<int, int>(0, 0), new Tuple<int, int>(n - 1, n - 1));
        }

        private static char[,] GenerateLargeEmptyMatrix(int n)
        {
            var matrix = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = PassableCell;
                }
            }

            return matrix;
        }

        private static void CheckIfPathExists(char[,] matrix, Tuple<int, int> startCell, Tuple<int, int> endCell)
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

            var firstMove = new Tuple<int, int>(startRow, startCol);
            SearchForDestination(firstMove, matrix);
        }

        private static void SearchForDestination(Tuple<int, int> move, char[,] matrix)
        {
            var startRow = move.Item1;
            var startCol = move.Item2;
            matrix[startRow, startCol] = TraversedCell;

            while (true)
            {
                var row = move.Item1;
                var col = move.Item2;


                if (matrix[row, col] == DestinationCell)
                {
                    Console.WriteLine("Path exists");
                    return;
                }

                var availableCells = GetAvailableNeighbourCells(move, matrix);
                foreach (var availableCell in availableCells)
                {
                    var newMove = new Tuple<int, int>(availableCell.Item1, availableCell.Item2);
                    movesQueue.Enqueue(newMove);
                }

                if (movesQueue.Count == 0)
                {
                    Console.WriteLine("Path does not exists.");
                }

                move = movesQueue.Dequeue();
            }
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
                if (matrix[newRow, col] == PassableCell || matrix[newRow, col] == DestinationCell)
                {
                    if (matrix[newRow, col] != DestinationCell)
                    {
                        matrix[newRow, col] = TraversedCell;
                    }

                    possibleMoves.Add(new Tuple<int, int>(newRow, col));
                }
            }

            // check up
            newRow = row - 1;
            if (newRow >= 0)
            {
                if (matrix[newRow, col] == PassableCell || matrix[newRow, col] == DestinationCell)
                {
                    if (matrix[newRow, col] != DestinationCell)
                    {
                        matrix[newRow, col] = TraversedCell;
                    }

                    possibleMoves.Add(new Tuple<int, int>(newRow, col));
                }
            }

            // check left
            newCol = col - 1;
            if (newCol >= 0)
            {
                if (matrix[row, newCol] == PassableCell || matrix[row, newCol] == DestinationCell)
                {
                    if (matrix[row, newCol] != DestinationCell)
                    {
                        matrix[row, newCol] = TraversedCell;
                    }

                    possibleMoves.Add(new Tuple<int, int>(row, newCol));
                }
            }

            // check right
            newCol = col + 1;
            if (newCol < colsCount)
            {
                if (matrix[row, newCol] == PassableCell || matrix[row, newCol] == DestinationCell)
                {
                    if (matrix[row, newCol] != DestinationCell)
                    {
                        matrix[row, newCol] = TraversedCell;
                    }

                    possibleMoves.Add(new Tuple<int, int>(row, newCol));
                }
            }

            return possibleMoves;
        }
    }
}
