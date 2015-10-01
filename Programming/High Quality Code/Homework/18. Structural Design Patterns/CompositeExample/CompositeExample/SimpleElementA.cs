using System;

namespace CompositeExample
{
    internal class SimpleElementA : IComponent
    {
        public string Name { get; set; }

        public SimpleElementA(string name)
        {
            this.Name = name;
        }

        public void getDetails(int startLevelDepth)
        {
            Console.WriteLine(new String('-', startLevelDepth * 4) + this.Name);
        }
    }
}