namespace Abstraction
{
    using System;

    public class Circle : Figure
    {
        private double radius;

        public Circle(double radius)
            : base(radius * 2, radius * 2)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid circle radius!");
                }

                this.radius = value;
            }
        }

        public override double Width
        {
            get
            {
                return this.Radius * 2;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid circle width!");
                }

                this.Radius = value / 2;
            }
        }

        public override double Height
        {
            get
            {
                return this.Radius * 2;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid circle heigth!");
                }

                this.Radius = value / 2;
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
