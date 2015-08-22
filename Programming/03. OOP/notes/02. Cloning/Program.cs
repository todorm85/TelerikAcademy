using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * MemberwiseClone() is protected method in System.Object. It returns shallow copy of objects. It returns type object which must be casted to the original instance type.
 * Serialization requires that all classes have [Serializable] attribute
 * Or we can implement ICloneable and make sure that all classes we want to clone have Clone() that makes deep copy recurisvely in all objects. If we have array of reference types we need to make cycle that recursively deep copies all array members with their Clone() method and so on until the last method Clone() copies only valuetypes.
 * Deep cloning requires serizlization or manual implementation by the programmer with ICloneable and Clone() method.
 */

namespace _02.Cloning
{
    class Point : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PointInfo Info { get; set; }

        public Point()
        {
            Info = new PointInfo();
        }

        public object Clone()
        {
            var output = new Point();
            output.X = this.X;
            output.Y = this.Y;
            output.Info = (PointInfo)this.Info.Clone();
            return output;
        }
    }

    class PointInfo : ICloneable
    {
        public int ID { get; set; }

        public object Clone()
        {
            var output = new PointInfo();
            output.ID = this.ID;
            return output;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Point();
            var p2 = p1;
            p2.Info.ID = 1;
            Console.WriteLine(p1.Info.ID);  // returns 1, p1 points to the same address as p2

            p2 = (Point)p1.Clone();
            p2.Info.ID = 2;
            Console.WriteLine(p1.Info.ID);  // returns 1, p1 points to other another address than p2
        }
    }
}
