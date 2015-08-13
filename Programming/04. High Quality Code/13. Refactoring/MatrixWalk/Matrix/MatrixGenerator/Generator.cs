using System;
using System.Collections.Generic;
using System.Collections;

namespace WalkMatrix.MatrixGenerator
{
    public static class Generator
    {
        private static readonly Position defaultPosition = new Position(0, 0);
        private static readonly Direction defaultDirection = Direction.DownRight;
        private static readonly IList<Direction> directionsOrderClockwise = new Direction[] {
            Direction.DownRight,
            Direction.Down,
            Direction.DownLeft,
            Direction.Left,
            Direction.UpLeft,
            Direction.Up,
            Direction.UpRight,
            Direction.Right
        };

        public static int[,] Generate(int matrixSize)
        {
            int[,] matrix = new int[matrixSize, matrixSize];
            int stepCount = 0;
            Position position = defaultPosition;

            while (position != null)
            {
                stepCount++;
                matrix[position.Row, position.Col] = stepCount;
                var direction = defaultDirection;

                while (CheckIfFreeNeighbourCellExists(matrix, position))
                {
                    Position newPosition = position.getNeighbourPosition(direction);

                    while (!IsPositionValid(matrix, newPosition))
                    {
                        direction = GetNextDirection(direction);
                        newPosition = position.getNeighbourPosition(direction);
                    }

                    position = newPosition;
                    stepCount++;
                    matrix[position.Row, position.Col] = stepCount;
                }

                position = FindFirstFreeCellPosition(matrix);
            }

            return matrix;
        }

        internal static bool IsPositionValid(int[,] matrix, Position position)
        {
            var posRow = position.Row;
            var posCol = position.Col;
            var matrixRowLen = matrix.GetLength(0);
            var matrixColLen = matrix.GetLength(1);

            if (posRow >= matrixRowLen || posRow < 0)
            {
                return false;
            }

            if (posCol >= matrixColLen || posCol < 0)
            {
                return false;
            }

            if (matrix[posRow, posCol] != 0)
            {
                return false;
            }

            return true;
        }

        internal static Direction GetNextDirection(Direction currentDirection)
        {
            var directionIndex = directionsOrderClockwise.IndexOf(currentDirection);
            directionIndex++;
            if (directionIndex >= directionsOrderClockwise.Count)
            {
                directionIndex = 0;
            }

            return directionsOrderClockwise[directionIndex];
        }

        internal static bool CheckIfFreeNeighbourCellExists(int[,] matrix, Position position)
        {
            for (int i = 0; i < directionsOrderClockwise.Count; i++)
            {
                var checkedDirection = directionsOrderClockwise[i];
                var neighbourPosition = position.getNeighbourPosition(checkedDirection);

                if (!IsPositionValid(matrix, neighbourPosition))
                {
                    continue;
                }

                if (matrix[neighbourPosition.Row, neighbourPosition.Col] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        internal static Position FindFirstFreeCellPosition(int[,] matrix)
        {
            int row;
            int col;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        row = i;
                        col = j;
                        return new Position(row, col);
                    }
                }
            }

            return null;
        }
    }
}
