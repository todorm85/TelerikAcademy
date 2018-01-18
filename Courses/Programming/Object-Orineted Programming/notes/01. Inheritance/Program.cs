using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Inheritance
{
    class Program
    {
        static void Main()
        {
            Circle circle01 = new Circle(5);
            Dog chita = new Dog(3,"bulonka","Chita");
            chita.Sleep();
            chita.TailWig();
        }
    }
}
