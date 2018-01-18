using System;

namespace StatePattern.PersonState
{
    internal class HappyState : State
    {
        public HappyState(Person person)
            : base(person)
        {
        }

        public override void GiveChocolate()
        {
            Console.WriteLine("{0} says: I already had chocolate and I am happy!", this.Person.Name);
        }

        public override void Greet()
        {
            Console.WriteLine("{0} says: Hello, so nice to see you!", this.Person.Name);
        }
    }
}