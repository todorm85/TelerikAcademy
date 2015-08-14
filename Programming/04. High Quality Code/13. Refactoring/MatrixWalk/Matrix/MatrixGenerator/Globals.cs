using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WalkMatrix.MatrixGenerator
{
    internal static class Globals
    {
        internal static readonly Position defaultPosition = new Position(0, 0);
        internal static readonly Direction defaultDirection = Direction.DownRight;
        internal static readonly IList<Direction> directionsOrderClockwise = new Direction[] {
            Direction.DownRight,
            Direction.Down,
            Direction.DownLeft,
            Direction.Left,
            Direction.UpLeft,
            Direction.Up,
            Direction.UpRight,
            Direction.Right
        };
    }
}
