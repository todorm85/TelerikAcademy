namespace CohesionAndCoupling
{
    using System;

    internal class OrthogonalSpace3D
    {
        /// <summary>
        /// Define orthogonal 3D space by three dimensions. Forms a 3D box.
        /// </summary>
        /// <param name="width">The size along X axis.</param>
        /// <param name="height">The size along Y axis.</param>
        /// <param name="depth">The size along Z axis.</param>
        internal OrthogonalSpace3D(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        internal double Width
        {
            get;
            set;
        }

        internal double Height
        {
            get;
            set;
        }

        internal double Depth
        {
            get;
            set;
        }

        internal double CalcVolume()
        {
            double volume = this.Width * this.Height * this.Depth;
            return volume;
        }

        internal double CalcDiagonalXYZ()
        {
            double distance = CalcDistance3D(new Point(0, 0, 0), new Point(this.Width, this.Height, this.Depth));
            return distance;
        }

        internal double CalcDiagonalXY()
        {
            double distance = CalcDistance3D(new Point(0, 0, 0), new Point(this.Width, this.Height, 0));
            return distance;
        }

        internal double CalcDiagonalXZ()
        {
            double distance = CalcDistance3D(new Point(0, 0, 0), new Point(this.Width, 0, this.Depth));
            return distance;
        }

        internal double CalcDiagonalYZ()
        {
            double distance = CalcDistance3D(new Point(0, 0, 0), new Point(0, this.Height, this.Depth));
            return distance;
        }

        internal static double CalcDistance3D(Point p1, Point p2)
        {
            double distance = Math.Sqrt(((p2.X - p1.X) * (p2.X - p1.X)) + ((p2.Y - p1.Y) * (p2.Y - p1.Y)) + ((p2.Z - p1.Z) * (p2.Z - p1.Z)));
            return distance;
        }

        internal struct Point
        {
            internal double X, Y, Z;

            internal Point(double xCoord, double yCoord, double zCoord)
            {
                this.X = xCoord;
                this.Y = yCoord;
                this.Z = zCoord;
            }
        }
    }
}
