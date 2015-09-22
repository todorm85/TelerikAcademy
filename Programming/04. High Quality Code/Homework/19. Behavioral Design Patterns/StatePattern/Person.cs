using StatePattern.PersonState;

namespace StatePattern
{
    internal class Person
    {
        public Person(string name)
        {
            this.Name = name;
            this.State = new CalmState(this);
        }

        public string Name { get; private set; }
        public State State { get; set; }

        public void GiveChocolate()
        {
            System.Console.WriteLine("Giving chocolate to {0}", this.Name);
            this.State.GiveChocolate();
        }

        public void Greet()
        {
            System.Console.WriteLine("Greeting {0}", this.Name);
            this.State.Greet();
        }
    }
}