using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AnimalsServices
{
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        IEnumerable<string> GetAll();

        [OperationContract]
        void Add(string name);
    }
}
