using System;

namespace CompositeExample
{
    internal class CompositeElementA : BaseCompositeElement
    {
        public CompositeElementA(string name)
            : base(name)
        {
        }

        public void SomeSpecificMethod()
        {
            Console.WriteLine("Specific method for Composite A type");
        }
    }
}