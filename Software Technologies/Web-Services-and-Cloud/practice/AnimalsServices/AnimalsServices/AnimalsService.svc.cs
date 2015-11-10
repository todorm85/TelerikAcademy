namespace AnimalsServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AnimalsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AnimalsService.svc or AnimalsService.svc.cs at the Solution Explorer and start debugging.
    public class AnimalsService : IAnimalsService
    {
        public static List<Animal> animals = new List<Animal>();

        public void Add(Animal animal)
        {
            animals.Add(animal);
        }

        public IQueryable<Animal> GetAll()
        {
            return animals.AsQueryable();
        }
    }
}
