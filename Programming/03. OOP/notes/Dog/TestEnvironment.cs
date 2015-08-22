using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogs
{
    class TestEnvironment
    {
        static void Main()
        {
            Dog[] dogs = new Dog[3];
            for (int i = 0; i < dogs.Length; i++)
            {
                dogs[i] = new Dog();
            }

            dogs[0].Name = "Sharo";
            dogs[1].Name = "Rex";
            foreach (var dog in dogs)
            {
                dog.Bark();
            }

            dogs[1].Age = null;
            Console.WriteLine(dogs[1].Age);
            int dogAge = int.Parse(dogs[1].Age.ToString());
        }
    }
}
