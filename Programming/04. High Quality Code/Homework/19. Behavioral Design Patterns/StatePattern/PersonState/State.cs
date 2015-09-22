namespace StatePattern.PersonState
{
    internal abstract class State
    {
        public State(Person person)
        {
            this.Person = person;
        }

        protected Person Person { get; private set; }

        public abstract void GiveChocolate();

        public abstract void Greet();
    }
}