using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind
{
    internal class NwDaoTester
    {
        internal static void TestCreateModifyDeleteCustomer()
        {
            NwDao.InsertCustomer("cus1", "myCompany1");
            NwDao.ShowCustomer("cus1");
            NwDao.UpdateCustomer("cus1", "myCompany1Edited", "myAddress1", "myCity1", "country1");
            NwDao.ShowCustomer("cus1");
            NwDao.DeleteCustomer("cus1");
            NwDao.ShowCustomer("cus1");
        }

        internal static void TestCustomerByOrderDateAndShippingAddress()
        {
            NwDao.ShowCustomersByOrderDateAndShippingCountry(new DateTime(1997, 1, 1), "Canada");
        }

        internal static void TestCustomerByOrderDateAndShippingAddressNativeSql()
        {
            NwDao.ShowCustomerByOrderDateAndShippingCountryNativeSql(1997, "Canada");
        }

        internal static void TestSalesByRegionAndPeriod()
        {
            string shipRegion = "RJ";
            DateTime startDate = new DateTime(1990, 1, 1);
            DateTime endDate = new DateTime(1999, 1, 1);

            NwDao.ShowSalesByRegionAndPeriod(shipRegion, startDate, endDate);
        }
    }
}
