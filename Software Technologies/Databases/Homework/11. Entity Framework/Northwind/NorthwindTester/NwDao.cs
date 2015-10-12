using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindDB;

namespace Northwind
{
    public static class NwDao
    {
        /// <summary>
        /// Creates and inserts a new customer to Northwind database.
        /// </summary>
        public static void InsertCustomer(string id, string companyName)
        {
            using (var db = new NorthwindEntities())
            {
                var newCustomer = new Customer()
                {
                    CustomerID = id,
                    CompanyName = companyName
                };

                db.Customers.Add(newCustomer);
                db.SaveChanges();
                Console.WriteLine("Customer with id={0} created!", id);
            }
        }

        /// <summary>
        /// Updates the Northwind database customer information by given customer id.
        /// </summary>
        public static void UpdateCustomer(string id, string companyName, string address, string city, string country)
        {
            using (var db = new NorthwindEntities())
            {
                var customer = db.Customers
                    .FirstOrDefault(c => c.CustomerID == id);

                if (customer == null)
                {
                    Console.WriteLine("No such customer to update!");
                    return;
                }

                customer.CompanyName = companyName;
                customer.Address = address;
                customer.City = city;
                customer.Country = country;
                db.SaveChanges();
                Console.WriteLine("Customer with id={0} updated!", id);
            }
        }

        /// <summary>
        /// Deletes a customer by given id from Northwind database.
        /// </summary>
        public static void DeleteCustomer(string id)
        {
            using (var db = new NorthwindEntities())
            {
                var customer = db.Customers
                    .FirstOrDefault(c => c.CustomerID == id);

                if (customer == null)
                {
                    Console.WriteLine("No such customer to delete!");
                    return;
                }

                db.Customers.Remove(customer);
                db.SaveChanges();
                Console.WriteLine("Customer with id={0} deleted!", id);
            }
        }

        /// <summary>
        /// Gets info about customer by given id.
        /// </summary>
        public static void ShowCustomer(string id)
        {
            using (var db = new NorthwindEntities())
            {
                var customer = db.Customers
                    .FirstOrDefault(c => c.CustomerID == id);

                if (customer == null)
                {
                    Console.WriteLine("No such customer to show!");
                    return;
                }

                Console.WriteLine(customer);
            }
        }

        public static void ShowCustomersByOrderDateAndShippingCountry(DateTime date, string shippingCountry)
        {
            using (var db = new NorthwindEntities())
            {
                var customersAndOrders = db.Customers
                    .Join(db.Orders, c => c.CustomerID, o => o.CustomerID,
                    (c, o) => new
                    {
                        Customer = c,
                        Order = o
                    })
                    .Where(co => co.Order.OrderDate.Value.Year == date.Year
                        && co.Order.ShipCountry == shippingCountry)
                    .Select(co => new
                    {
                        co.Customer,
                        co.Order
                    });

                foreach (var co in customersAndOrders)
                {
                    Console.WriteLine("Company name: {0}, Ship country: {1}, Order year: {2}, Order ID: {3}",co.Customer.CompanyName, co.Order.ShipCountry, co.Order.ShippedDate.Value.Year, co.Order.OrderID);
                }
            }
        }

        public static void ShowCustomerByOrderDateAndShippingCountryNativeSql(int year, string country)
        {
            string query = String.Format(@"
                SELECT CONCAT(c.CompanyName, ' ', o.OrderDate, ' ', o.ShipCountry, o.OrderID)
                FROM dbo.Orders o
                    INNER JOIN dbo.Customers c
                    ON o.CustomerID = c.CustomerID
                WHERE YEAR(o.OrderDate) = {0} AND o.ShipCountry = '{1}'",
                year, country);

            using (var db = new NorthwindDB.NorthwindEntities())
            {
                var queryResult = db.Database.SqlQuery<string>(query).ToList();

                foreach (var foundResult in queryResult)
                {
                    Console.WriteLine(foundResult);
                }
            }
        }

        public static void ShowSalesByRegionAndPeriod(string shipRegion, DateTime startDate, DateTime endDate)
        {
            using (var db = new NorthwindDB.NorthwindEntities())
            {
                var orders = db.Orders
                    .Where(o => o.ShipRegion == shipRegion
                    && o.OrderDate >= startDate
                    && o.OrderDate <= endDate)
                    .Select(o => o.OrderID + " " + o.OrderDate + " " + o.ShipRegion);

                foreach (var order in orders)
                {
                    Console.WriteLine(order);
                }
            }
        }
    }
}
