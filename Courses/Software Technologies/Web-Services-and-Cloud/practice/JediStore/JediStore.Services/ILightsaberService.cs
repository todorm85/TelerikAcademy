using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace JediStore.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILightsaberService" in both code and config file together.
    [ServiceContract]
    public interface ILightsaberService
    {
        [OperationContract]
        IQueryable<Lightsaber> GetAll();

        [OperationContract]
        Lightsaber GetById(string id);

        [OperationContract]
        void Add(Lightsaber lightsaber);
    }
}
