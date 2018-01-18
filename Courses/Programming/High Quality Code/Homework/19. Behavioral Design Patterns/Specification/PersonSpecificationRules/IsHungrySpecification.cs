using Specification.BaseLogic;

namespace Specification.PersonSPecificationRules
{
    internal class IsHungrySpecification : ISpecification<Person>
    {
        public bool IsSatisfiedBy(Person entity)
        {
            return entity.IsHungry;
        }
    }
}