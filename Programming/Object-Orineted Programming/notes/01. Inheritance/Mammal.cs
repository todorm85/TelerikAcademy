using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Inheritance
{
    public class Mammal
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public Mammal(int age)
        {
            this.Age = age;
        }

        public void Sleep()
        {
            Console.WriteLine("{0}: ZzZzZzZzzzzz....", this.Name);
        }
    }

    public class Dog : Mammal
    {
        public string Breed { get; set; }

        public Dog(int age, string breed, string name)
            : base(age)
        {
            this.Breed = breed;
            this.Name = name;
        }

        public void TailWig()
        {
            Console.WriteLine("{0}: Tail wiggling...", this.Name);
        }
    }
}
