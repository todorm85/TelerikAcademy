using System;

namespace Specification
{
    internal class Person
    {
        public Person(string name)
        {
            this.Name = name;
            this.IsHungry = false;
            this.HasTeeth = true;
        }

        public bool HasTeeth { get; set; }
        public bool IsHungry { get; set; }
        public string Name { get; private set; }

        public void Eat(string food)
        {
            Console.WriteLine("{0} is eating {1}", this.Name, food);
        }
    }
}