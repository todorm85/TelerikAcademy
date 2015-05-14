using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    abstract class Shape
    {
        private double width;
        private double height;

        protected Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get { return width; }
            set 
            {
                if (value<=0)
                {
                    throw new ArgumentException("Invalid width value, must be > 0");
                }

                width = value;
            }
        }

        public double Height
        {
            get { return height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid height value, must be > 0");
                } 
                
                height = value;
            }
        }

        public abstract double CalculateSurface();
    }
}
