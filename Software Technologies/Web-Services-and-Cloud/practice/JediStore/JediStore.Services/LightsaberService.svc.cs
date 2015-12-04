using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace JediStore.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LightsaberService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LightsaberService.svc or LightsaberService.svc.cs at the Solution Explorer and start debugging.
    public class LightsaberService : ILightsaberService
    {
        public void Add(Lightsaber lightsaber)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Lightsaber> GetAll()
        {
            return new List<Lightsaber>()
            {
                new Lightsaber()
                {
                    Color= Color.Blue,
                    Damage = 15,
                    Id = 1
                }
            }.AsQueryable();


        }

        public Lightsaber GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
