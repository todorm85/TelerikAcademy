using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindDB;

namespace Northwind
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Task2: Testing Creating, Modification and Deletion of Northwind Customer");
            NwDaoTester.TestCreateModifyDeleteCustomer();
            Console.WriteLine(new String('-', 50));
            Console.ReadKey();

            Console.WriteLine("Task3: Write a method that finds all customers who have orders made in 1997 and shipped to Canada.");
            NwDaoTester.TestCustomerByOrderDateAndShippingAddress();
            Console.WriteLine(new String('-', 50));
            Console.ReadKey();

            Console.WriteLine("Task4: Implement previous by using native SQL query and executing it through the DbContext.");
            NwDaoTester.TestCustomerByOrderDateAndShippingAddressNativeSql();
            Console.WriteLine(new String('-', 50));
            Console.ReadKey();

            Console.WriteLine("Task5: Write a method that finds all the sales by specified region and period (start / end dates).");
            NwDaoTester.TestSalesByRegionAndPeriod();
            Console.WriteLine(new String('-', 50));
            Console.ReadKey();

            Console.WriteLine("Task6: Create a database called NorthwindTwin with the same structure as Northwind using the features from DbContext.");
            GenerateNorthwindTwin();
            Console.WriteLine(new String('-', 50));
            Console.ReadKey();

            Console.WriteLine("Task7: Try to open two different data contexts and perform concurrent changes on the same records.");
            ParallelUpdate();
            Console.WriteLine(new String('-', 50));
            Console.ReadKey();
        }

        private static void ParallelUpdate()
        {
            // every time we run this method we`ll get different final result for
            // company name. To correct this behaviour we need to implement transactions
            // or use somekind of locking mechanism inside c# code
            NwDao.DeleteCustomer("Par1");
            NwDao.InsertCustomer("Par1", "par1");

            Parallel.For(0, 20, x => NwDao.UpdateCustomer("Par1", "par1update " + x, "", "", ""));

            Console.WriteLine("Result after simultaneous updating customer with id='Par1' with new company name = 'old name' + [1-20]");
            NwDao.ShowCustomer("Par1");
            NwDao.DeleteCustomer("Par1");
        }

        private static void GenerateNorthwindTwin()
        {
            using (var db = new NorthwindEntities())
            {
                // You can modify your model`s db name to NorthwindTwin in appconfig
                var result = db.Database.CreateIfNotExists();
                Console.WriteLine(result);
            }
        }
    }
}
