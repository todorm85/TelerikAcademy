using System;
using System.Collections.Generic;

namespace CompositeExample
{
    public abstract class BaseCompositeElement : IComponent
    {
        public string Name { get; set; }
        private IList<IComponent> components = new List<IComponent>();

        public BaseCompositeElement(string name)
        {
            this.Name = name;
        }

        public void getDetails(int startLevel)
        {
            Console.WriteLine(new String('-', startLevel * 4) + this.Name);

            foreach (var component in components)
            {
                component.getDetails(startLevel + 1);
            }
        }

        public void AddComponent(IComponent component)
        {
            this.components.Add(component);
        }
    }
}