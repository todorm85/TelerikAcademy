using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace _03_SubstringsCountService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class SubstringsCountService : ISubstringsCountService
    {
        public int GetSubstringsCount(string firstString, string secondString)
        {
            var substringsCount = 0;
            while (true)
            {
                var foundIndex = firstString.IndexOf(secondString);
                if (foundIndex < 0)
                {
                    break;
                }

                substringsCount++;
                firstString = firstString.Substring(foundIndex + secondString.Length);
            }

            return substringsCount;
        }
    }
}
