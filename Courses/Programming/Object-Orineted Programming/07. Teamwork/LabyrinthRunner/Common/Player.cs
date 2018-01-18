using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using LabyrinthRunner.UI;

namespace LabyrinthRunner.Common
{
    public abstract class Player : WorldObject, IMovable
    {

        public Player(WorldObjectType type, Position position, char skin)
            : base(type, position, skin)
        {
        }


        protected bool Move(Direction direction)
        {
            int rowOffset = 0;
            int colOffest = 0;

            if (direction == Direction.Left) colOffest = -1;
            if (direction == Direction.Right) colOffest = 1;
            if (direction == Direction.Up) rowOffset = -1;
            if (direction == Direction.Down) rowOffset = 1;

            Position newPosition = new Position(this.Position.Row + rowOffset, this.Position.Col + colOffest);

            if(Collision.ManageCollision(this, newPosition) == true)
            {
                this.Position = newPosition;
                return true;
            }

            return false;
        }

        public abstract void OnMove();
    }
}
