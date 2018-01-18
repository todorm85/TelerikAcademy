using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkMatrix.Contracts;

namespace WalkMatrix.MatrixGenerator
{
    internal static class MatrixExtensions
    {
        internal static IPosition FindFirstCellPositionWithValue(this Matrix matrix, int value)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var currentPosition = new Position(row, col);
                    if (matrix[currentPosition] == value)
                    {
                        return currentPosition;
                    }
                }
            }

            return null;
        }

        internal static bool IsPositionValid(this Matrix matrix, IPosition position)
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

            return true;
        }

        internal static bool CheckIfAnyNeighbourCellContainsValue(this Matrix matrix, IPosition position, int value)
        {
            for (int i = 0; i < Globals.directionsOrderClockwise.Count; i++)
            {
                var checkedDirection = Globals.directionsOrderClockwise[i];
                var neighbourPosition = position.getNeighbourPosition(checkedDirection);

                if (!matrix.IsPositionValid(neighbourPosition))
                {
                    continue;
                }

                if (matrix[neighbourPosition] == value)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
