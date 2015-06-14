using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Circle : Shape
    {
        public Circle(double r)
            : base(r * 2, r * 2)
        { }

        public override double CalculateSurface()
        {
            return Math.PI * (this.Width/2) * (this.Width/2);
        }
    }
}
