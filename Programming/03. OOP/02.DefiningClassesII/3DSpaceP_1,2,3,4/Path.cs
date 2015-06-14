using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space3D
{
    public class Path
    {
        private List<Point3D> pathPoints;

        public List<Point3D> PathPoints
        {
            get
            {
                return new List<Point3D>(this.pathPoints);
            }
        }

        public Path()
        {
            pathPoints = new List<Point3D>();
        }

        public void AddPoint(Point3D p)
        {
            this.pathPoints.Add(p);
        }
    }
}
