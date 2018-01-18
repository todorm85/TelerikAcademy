using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person_class
{
    class Test
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Someone");
            Console.WriteLine(p1.Age);
            Console.WriteLine(p1);
            p1.Age = 15;
            Console.WriteLine(p1.Age);
            Console.WriteLine(p1);
            Console.WriteLine("Enter age: ");
            p1.Age = byte.Parse(Console.ReadLine());
            Console.WriteLine(p1.Age);

        }
    }
}
