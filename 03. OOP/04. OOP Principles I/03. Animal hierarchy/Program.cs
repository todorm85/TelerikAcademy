using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animal_hierarchy
{
    class Program
    {
        static void Main()
        {
            "Test1: var kitten1 = new Kitten();".PrintDelimiter();
            var kitten1 = new Kitten();
            Console.WriteLine("Kitten1 sex: " + kitten1.Sex);
            kitten1.MakeSound();
            //kitten1.Sex = "?";    // this will throw exception

            "Test2: Animal cat1 = new Cat();".PrintDelimiter();
            Animal cat1 = new Cat();
            Console.WriteLine("Cat1 sex: " + cat1.Sex);
            cat1.MakeSound();
            //kitten2.Sex = "?";    // this will throw an exception if we were working with override property Sex, but if the property was overloaded with the new keyword it would change it, because it will use class Animal`s property Sex, since the variable kitten2 is an instance of Animal, not kitten.

            "Test3: Tomcat tom1 = new Tomcat();".PrintDelimiter();
            Tomcat tom1 = new Tomcat();
            Console.WriteLine("Tomcat {0}, sex: {1}, age: {2}", tom1.Name, tom1.Sex, tom1.Age);
            tom1.MakeSound();

            "Test4: var kitten2 = new Kitten(\"Ziggi\",3);".PrintDelimiter();
            var kitten2 = new Kitten("Ziggi",3);
            Console.WriteLine("Kitten {0}, sex: {1}, age: {2}",kitten2.Name, kitten2.Sex, kitten2.Age);
            kitten2.MakeSound();

            "Test5: var dog1 = new Dog(\"Kona\", \"f\", 5);".PrintDelimiter();
            var dog1 = new Dog("Kona", "f", 5);
            Console.WriteLine("Dog {0}, sex: {1}, age: {2}", dog1.Name, dog1.Sex, dog1.Age);
            dog1.MakeSound();

            "Test6: var frog1 = new Frog(\"Kona\", \"f\", 5);".PrintDelimiter();
            var frog1 = new Frog("Antrazit", "m", 1);
            Console.WriteLine("Frog {0}, sex: {1}, age: {2}", frog1.Name, frog1.Sex, frog1.Age);
            frog1.MakeSound();

            "Test7: Array of generic animals average age".PrintDelimiter();
            Animal[] animals = new Animal[]
            {
                new Kitten("Kitten 1", 2),
                new Tomcat("Tomcat 1", 3),
                new Dog("Dog 1", "m", 7),
                new Frog("Frog 1", "m", 1),
                new Cat("Cat 1", "f", 5),

                new Kitten("Kitten 2", 3),
                new Tomcat("Tomcat 2", 4),
                new Dog("Dog 2", "m", 8),
                new Frog("Frog 2", "m", 2),
                new Cat("Cat 2", "f", 6),

                new Kitten("Kitten 3", 1),
                new Tomcat("Tomcat 3", 2),
                new Dog("Dog 3", "m", 6),
                new Frog("Frog 3", "m", 2),
                new Cat("Cat 3", "f", 4),
            };

            var animalAverageAge = animals.Average(x => x.Age);
            Console.WriteLine("Average animal age: {0}", animalAverageAge);

            var dogAverageAge = animals.Where(x => x.GetType() == typeof(_03.Animal_hierarchy.Dog)).Average(x => x.Age);
            Console.WriteLine("Average dog age: {0}", dogAverageAge);
        }
    }
}
