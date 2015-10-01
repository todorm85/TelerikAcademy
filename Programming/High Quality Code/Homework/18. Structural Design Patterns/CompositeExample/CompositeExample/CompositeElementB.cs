using System;

namespace CompositeExample
{
    internal class CompositeElementB : BaseCompositeElement
    {
        public CompositeElementB(string name)
            : base(name)
        {
        }

        public void SomeSpecificMethod()
        {
            Console.WriteLine("Specific method for Composite B type");
        }
    }
}