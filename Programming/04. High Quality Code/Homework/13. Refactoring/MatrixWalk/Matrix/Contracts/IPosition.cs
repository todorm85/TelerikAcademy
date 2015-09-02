using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkMatrix;
using WalkMatrix.MatrixGenerator;

namespace WalkMatrix.Contracts
{
    public interface IPosition
    {
        int Row {get; set;}
        int Col {get; set;}
        IPosition getNeighbourPosition(Direction direction);
    }
}
