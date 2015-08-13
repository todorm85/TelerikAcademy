using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WalkMatrix.MatrixGenerator
{
    internal class Position
    {
        private int row;
        private int col;

        internal int Col
        {
            get
            {
                return this.col;
            }

            set
            {
                this.col = value;
            }
        }


        internal int Row
        {
            get
            {
                return this.row;
            }

            set
            {
                this.row = value;
            }
        }

        internal Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        internal Position getNeighbourPosition(Direction dir)
        {
            Position newPosition = new Position(this.Row, this.Col);

            switch (dir)
            {
                case Direction.DownRight:
                    newPosition.Row++;
                    newPosition.Col++;
                    break;
                case Direction.Down:
                    newPosition.Row++;
                    break;
                case Direction.DownLeft:
                    newPosition.Row++;
                    newPosition.Col--;
                    break;
                case Direction.Left:
                    newPosition.Col--;
                    break;
                case Direction.UpLeft:
                    newPosition.Row--;
                    newPosition.Col--;
                    break;
                case Direction.Up:
                    newPosition.Row--;
                    break;
                case Direction.UpRight:
                    newPosition.Row--;
                    newPosition.Col++;
                    break;
                case Direction.Right:
                    newPosition.Col++;
                    break;
                default:
                    throw new ArgumentException("Invalid direction.");
            }

            return newPosition;
        }
    }
}
