namespace PeopleGenerator
{
    using System;

    internal class Generator
    {
        public Person MakePerson(int age)
        {
            Person newPerson = new Person();
            newPerson.Age = age;
            if (age % 2 == 0)
            {
                newPerson.Name = "Thug";
                newPerson.Gender = Gender.Male;
            }
            else
            {
                newPerson.Name = "Hoe";
                newPerson.Gender = Gender.Female;
            }

            return newPerson;
        }
    }
}
