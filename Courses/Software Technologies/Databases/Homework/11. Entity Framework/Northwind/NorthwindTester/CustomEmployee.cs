using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindDB;


namespace Northwind
{
    class CustomEmployee : Employee
    {
        public System.Data.Linq.EntitySet<Territory> Territories
        {
            get
            {
                return this.Territories;
            }
        }

    }
}
