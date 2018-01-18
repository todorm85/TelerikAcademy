using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace _01_DayOfWeekService
{
    [ServiceContract]
    public interface IDayOfWeek
    {

        [OperationContract]
        string GetDayOWeek(DateTime date);
    }
}
