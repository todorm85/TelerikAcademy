using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabyrinthRunner.Common
{
    public class BrickWall : Structure
    {
        public BrickWall(Position position) : base(position, '█')
        {
            this.IsPenetrable = false;
        }
    }
}
