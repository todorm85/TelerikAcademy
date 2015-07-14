using System;

namespace Size
{
    public class OrthoSize
    {
        private double width,
                       height;

        public OrthoSize(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }

                this.height = value;
            }
        }

        public OrthoSize GetRotatedSize(double rotationAngle)
        {
            double sinModule = Math.Abs(Math.Sin(rotationAngle));
            double cosModule = Math.Abs(Math.Cos(rotationAngle));

            double newWidth = cosModule * this.Width + sinModule * this.Height;
            double newHeight = sinModule * this.Width + cosModule * this.Height;

            return new OrthoSize(newWidth, newHeight);
        }
    }
}