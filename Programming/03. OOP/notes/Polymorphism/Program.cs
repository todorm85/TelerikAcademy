using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    class Base
    {
        public virtual void IdentifyYourself()
        {
            Console.WriteLine("Based is here");
        }
    }

    class DerivedNew : Base
    {
        public new void IdentifyYourself()
        {
            Console.WriteLine("DerivedNew is here");
        }
    }

    class DerivedOverriden : Base
    {
        public override void IdentifyYourself()
        {
            Console.WriteLine("DerivedOverriden is here");
        }
    }

    class Program
    {
        static void Main()
        {
            Base derivedNewAbstract = new DerivedNew();
            Base derivedOverridenAbstract = new DerivedOverriden();

            derivedNewAbstract.IdentifyYourself();  // prints Based i here
            derivedOverridenAbstract.IdentifyYourself();    // prints DerivedOverriden is here

            DerivedNew derivedNew = new DerivedNew();
            DerivedOverriden derivedOverriden = new DerivedOverriden();

            derivedNew.IdentifyYourself();  // prints DerivedNew is here
            derivedOverriden.IdentifyYourself();    // prints DerivedOverriden is here
        }
    }
}
