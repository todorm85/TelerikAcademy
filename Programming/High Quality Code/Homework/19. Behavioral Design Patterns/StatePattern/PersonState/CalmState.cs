using System;

namespace StatePattern.PersonState
{
    internal class CalmState : State
    {
        public CalmState(Person person)
            : base(person)
        {
        }

        public override void GiveChocolate()
        {
            Console.WriteLine("{0} says: MMMMM tasty, that makes me happy!", this.Person.Name);
            this.Person.State = new HappyState(this.Person);
        }

        public override void Greet()
        {
            Console.WriteLine("{0} says: Hello.", this.Person.Name);
        }
    }
}