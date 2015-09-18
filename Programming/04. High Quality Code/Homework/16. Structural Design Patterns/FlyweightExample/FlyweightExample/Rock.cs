using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightExample
{
    public abstract class Rock
    {
        public string Shape { get; private set; }

        protected Rock(string shape)
        {
            this.Shape = shape;
        }

        public void Display(int size)
        {
            Console.WriteLine(this.Shape + " " + size);
        }
    }
}
