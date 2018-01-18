using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animal_hierarchy
{
    class Frog : Animal
    {
        public Frog()
            : base()
        { }
        public Frog(string name, string sex, int age)
            : base(name, sex, age)
        { }
        public override void MakeSound()
        {
            Console.WriteLine("Frog {0} said ribbit, ribbit!", this.Name);
        }
    }
}
