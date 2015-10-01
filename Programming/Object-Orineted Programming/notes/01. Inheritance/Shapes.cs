using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Inheritance
{
    public struct Coord
	{
		public double X { get; set; }
        public double Y { get; set; }
	}

    public class Shape
    {
        public Coord BasePoint { get; set; }

        public Shape() {}

        public Shape(Coord basePoint)
        {
            this.BasePoint = basePoint;
        }
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double r) : this(new Coord(),r) {}

        public Circle(Coord baseCoord, double r) : base(baseCoord)
        {
            this.Radius = r;
        }

    }   
}
