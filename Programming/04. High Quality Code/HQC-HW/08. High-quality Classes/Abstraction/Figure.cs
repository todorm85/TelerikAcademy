namespace Abstraction
{
    using System;

    public abstract class Figure
    {
        private double width;
        private double height;

        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public virtual double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid figure width");
                }

                this.width = value;
            }
        }

        public virtual double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid figure width");
                }

                this.height = value;
            }
        }

        public abstract double CalcPerimeter();

        public abstract double CalcSurface();
    }
}
