using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousTypes
{
    class Program
    {
        static void Main()
        {
            string delimiter = new string('-', 50);

            // compiler will create a new class for this
            // it will generate its name, properties ect.
            // its fields will be readonly and properties with just get
            // actually it is not anonymous, it is created with random generated name
            // in the final assembly
            var point = new { X = 3, Y = 5 };
            var myCar = new { Color = "red", Brand = "Opel" };
            Console.WriteLine("My car is {0} and its color is {1}", myCar.Brand, myCar.Color);
            myCar = new { Color = "blue", Brand = "Opel" };
            Console.WriteLine("My car is {0} and its color is {1}", myCar.Brand, myCar.Color);

            Console.WriteLine(delimiter);

            var anon1 = new { X = 3, Y = 5 };
            var anon2 = new { X = 3, Y = 5 };
            Console.WriteLine(anon1 == anon2);  // false
            Console.WriteLine(anon1.Equals(anon2)); // true

            Console.WriteLine(delimiter);

            var arr = new[] 
            { 
                new { X = 1, Y = 2 },
                new { X = 5, Y = 3 },
                new { X = 6, Y = 7 } 
            };

            foreach (var item in arr)
            {
                Console.WriteLine("{0} {1}", item.X, item.Y);
            }

            Console.WriteLine(delimiter);

            var student = new { FirstName = "Todor", SecondName = "Mistkovski" };
            Console.WriteLine(student);
        }
    }
}
