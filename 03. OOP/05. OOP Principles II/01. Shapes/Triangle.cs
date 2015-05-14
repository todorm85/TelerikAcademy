using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Triangle : Shape
    {
        public Triangle(double sideA, double heightA)
            : base(sideA, heightA) 
        { }

        public override double CalculateSurface()
        {
            return this.Width * this.Height / 2;
        } 
    }
}
