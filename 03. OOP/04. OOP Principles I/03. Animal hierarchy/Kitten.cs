using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animal_hierarchy
{
    class Kitten : Cat
    {
        public Kitten(string name, int age)
            : base(name, "f", age)
        { }

        public Kitten()
            : base("Unnamed kitten", "f", 0)
        { }

        public override string Sex
        {
            get
            {
                return base.Sex;
            }
            set
            {
                if (value != "f")
                {
                    throw new ArgumentException("Kittens can only be female!");
                }

                base.Sex = value;
            }

        }

        public override void MakeSound()
        {
            Console.WriteLine("Kitten {0} said \"Meu meuu\"!", this.Name);
        }
    }
}
