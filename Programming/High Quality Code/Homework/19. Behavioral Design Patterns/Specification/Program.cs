namespace Specification
{
    using Specification.BaseLogic;
    using Specification.PersonSPecificationRules;
    using System;

    public static class Program
    {
        public static void Main()
        {
            var me = new Person("Myself");
            Feed(me);

            Console.WriteLine(new String('-', 50));

            var gosho = new Person("Gosho");
            gosho.IsHungry = true;
            Feed(gosho);
        }

        private static void Feed(Person person)
        {
            var shouldIEat = new IsHungrySpecification().And(new HasTeethSpecification());
            if (shouldIEat.IsSatisfiedBy(person))
            {
                person.Eat("Snacks");
            }
            else
            {
                Console.WriteLine("{0} is not hungry", person.Name);
            }
        }
    }
}