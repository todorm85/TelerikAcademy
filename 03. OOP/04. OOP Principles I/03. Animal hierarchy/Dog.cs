using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animal_hierarchy
{
    class Dog : Animal
    {
        public Dog()
            : base()
        { }

        public Dog(string name, string sex, int age)
            : base(name, sex, age)
        { }

        public override void MakeSound()
        {
            Console.WriteLine("Dog {0} said bark, bark!", this.Name);
        }
    }
}
