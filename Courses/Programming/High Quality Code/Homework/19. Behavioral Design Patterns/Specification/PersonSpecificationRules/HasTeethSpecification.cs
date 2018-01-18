using Specification.BaseLogic;

namespace Specification.PersonSPecificationRules
{
    internal class HasTeethSpecification : ISpecification<Person>
    {
        public bool IsSatisfiedBy(Person entity)
        {
            return entity.HasTeeth;
        }
    }
}