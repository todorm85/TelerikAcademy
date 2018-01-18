using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AsIs_operators
{
    class Base
    {

    }

    class Derived : Base
    {
        private int x;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var b = new Base();
            var d = new Derived();

            var r1 = b as Derived;
            var r2 = d as Base;

            var r3 = b is Derived;
            var r4 = d is Base;
        }
    }
}
