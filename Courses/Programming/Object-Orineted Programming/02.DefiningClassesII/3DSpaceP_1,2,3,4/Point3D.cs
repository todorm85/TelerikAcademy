using System;

namespace Space3D
{
    public struct Point3D
    {
        #region Fields
        private static readonly Point3D pointO = new Point3D(0, 0, 0);

        private double x;
        private double y;
        private double z;
        #endregion
        #region Properties
        public static Point3D PointO
        {
            get
            {
                return pointO;
            }
        }

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public double Z
        {
            get { return z; }
            set { z = value; }
        }
        #endregion
        #region Constructors
        public Point3D(double x, double y, double z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return String.Format("x{0:F2} y{1:F2} z{2:F2}", X, Y, Z);
        }
        #endregion
    }


}
