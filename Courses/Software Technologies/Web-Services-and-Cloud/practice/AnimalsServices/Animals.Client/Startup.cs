namespace Animals.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AnimalServices;

    public class Startup
    {
        private static void Main()
        {
            var client = new AnimalsServiceClient();
            client.Add(new Animal()
            {
                animalName = "Stama"
            });

            client.GetAll().ToList().ForEach(Console.WriteLine);

            client.GetAll().Select(x => x.animalName == "Stama").First();
        }
    }
}
