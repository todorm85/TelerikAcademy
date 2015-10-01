using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animal_hierarchy
{
    class Cat : Animal
    {
        public Cat()
            : base("Unnamed cat","?",0)
        { }
        public Cat(string name, string sex, int age)
            : base(name, sex, age)
        { }

        public override void MakeSound()
        {
            Console.WriteLine("Cat {0} said \"Meauuuuuu\"!",this.Name);
        }
    }
}
