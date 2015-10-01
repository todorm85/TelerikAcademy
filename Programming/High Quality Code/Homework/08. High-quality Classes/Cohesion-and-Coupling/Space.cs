namespace CohesionAndCoupling
{
    using System;

    internal class Space
    {
        internal Space(double width, double height, double depth)
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
            double distance = Point3D.CalcDistance3D(new Point3D(0, 0, 0), new Point3D(this.Width, this.Height, this.Depth));
            return distance;
        }

        internal double CalcDiagonalXY()
        {
            double distance = Point3D.CalcDistance2D(new Point3D(0, 0, 0), new Point3D(this.Width, this.Height, 0));
            return distance;
        }

        internal double CalcDiagonalXZ()
        {
            double distance = Point3D.CalcDistance2D(new Point3D(0, 0, 0), new Point3D(this.Width, 0, this.Depth));
            return distance;
        }

        internal double CalcDiagonalYZ()
        {
            double distance = Point3D.CalcDistance2D(new Point3D(0, 0, 0), new Point3D(0, this.Height, this.Depth));
            return distance;
        }

        private struct Point3D
        {
            public double X, Y, Z;

            internal Point3D(double xCoord, double yCoord, double zCoord)
            {
                this.X = xCoord;
                this.Y = yCoord;
                this.Z = zCoord;
            }

            /// <summary>
            /// Calculates the distance between points in XY plane
            /// </summary>
            internal static double CalcDistance2D(Point3D p1, Point3D p2)
            {
                double distance = Math.Sqrt(((p2.X - p1.X) * (p2.X - p1.X)) + ((p2.Y - p1.Y) * (p2.Y - p1.Y)));
                return distance;
            }

            internal static double CalcDistance3D(Point3D p1, Point3D p2)
            {
                double distance = Math.Sqrt(((p2.X - p1.X) * (p2.X - p1.X)) + ((p2.Y - p1.Y) * (p2.Y - p1.Y)) + ((p2.Z - p1.Z) * (p2.Z - p1.Z)));
                return distance;
            }
        }
    }
}
