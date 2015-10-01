using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthRunner.Common
{
    public class Air : Structure
    {
        public Air(Position position) : base(position, ' ')
        {
            this.IsPenetrable = true;
        }
    }
}
