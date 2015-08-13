using System;
using System.Collections.Generic;
using System.Collections;

namespace WalkMatrix.MatrixGenerator
{
    internal static class Generator
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

        internal static Matrix Generate(int matrixSize)
        {
            var matrix = new Matrix(matrixSize, matrixSize);
            int stepCount = 0;
            Position position = defaultPosition;

            while (position != null)
            {
                stepCount++;
                matrix[position] = stepCount;
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
                    matrix[position] = stepCount;
                }

                position = FindFirstFreeCellPosition(matrix);
            }

            return matrix;
        }

        internal static bool IsPositionValid(Matrix matrix, Position position)
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

            if (matrix[position] != 0)
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

        internal static bool CheckIfFreeNeighbourCellExists(Matrix matrix, Position position)
        {
            for (int i = 0; i < directionsOrderClockwise.Count; i++)
            {
                var checkedDirection = directionsOrderClockwise[i];
                var neighbourPosition = position.getNeighbourPosition(checkedDirection);

                if (!IsPositionValid(matrix, neighbourPosition))
                {
                    continue;
                }

                if (matrix[neighbourPosition] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        internal static Position FindFirstFreeCellPosition(Matrix matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var currentPosition = new Position(row, col);
                    if (matrix[currentPosition] == 0)
                    {
                        return currentPosition;
                    }
                }
            }

            return null;
        }
    }
}
