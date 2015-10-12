using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindDB;

namespace NorthwindDB
{
    public partial class Customer
    {
        public override string ToString()
        {
            return string.Format("CustomerID: {0}, CompanyName: {10}, ContactName: {1}, ContactTitle: {2}, Address: {3}, City: {4}" +
                ", Region: {5}, PostalCode: {6}, Country: {7}, Phone: {8}, Fax:{9}", 
                this.CustomerID, 
                this.ContactName,
                this.ContactTitle, 
                this.Address,
                this.City,
                this.Region,
                this.PostalCode,
                this.Country,
                this.Phone,
                this.Fax,
                this.CompanyName
                );
        }
    }
}
