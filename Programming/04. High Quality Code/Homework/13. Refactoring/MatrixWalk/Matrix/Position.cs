using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkMatrix.Contracts;
using WalkMatrix.MatrixGenerator;

namespace WalkMatrix
{
    public class Position : IPosition
    {
        private int row;
        private int col;

        public int Col
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

        public int Row
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

        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public IPosition getNeighbourPosition(Direction dir)
        {
            IPosition newPosition = new Position(this.Row, this.Col);

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
