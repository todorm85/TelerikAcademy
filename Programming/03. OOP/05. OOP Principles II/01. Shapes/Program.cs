using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Program
    {
        static void Main()
        {
            Shape[] shapes = new Shape[]
            {
                new Rectangle(5.5,3),
                new Circle(3.3),
                new Triangle(5.1,2.3)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine("{0}, bounding box width: {1}, bounding box height: {2}, shape area is {3}", shape.GetType(), shape.Width, shape.Height, shape.CalculateSurface());
            }
        }
    }
}
