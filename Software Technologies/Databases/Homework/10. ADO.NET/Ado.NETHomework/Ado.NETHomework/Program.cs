using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;

namespace Ado.NETHomework
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("1 Write a program that retrieves from the Northwind sample database in MS SQL Server the number of rows in the Categories table.");
            Task1GetCategoriesCount();
            Console.WriteLine(new String('-', 50));
            Console.WriteLine("Task finished. Press a key to continue to next.");
            Console.ReadKey();

            Console.WriteLine("2 Write a program that retrieves the name and description of all categories in the Northwind DB.");
            Task2GetCategoriesNameAndDescription();
            Console.WriteLine(new String('-', 50));
            Console.WriteLine("Task finished. Press a key to continue to next.");
            Console.ReadKey();

            Console.WriteLine("3. Write a program that retrieves from the Northwind database all product categories and the names of the products in each category.");
            Task3GetCategoriesAndProducts();
            Console.WriteLine(new String('-', 50));
            Console.WriteLine("Task finished. Press a key to continue to next.");
            Console.ReadKey();

            Console.WriteLine("4 Write a method that adds a new product in the products table in the Northwind database.");
            Task4AddNewProduct();
            Console.WriteLine(new String('-', 50));
            Console.WriteLine("Task finished. Press a key to continue to next.");
            Console.ReadKey();

            Console.WriteLine("5 Write a program that retrieves the images for all categories in the Northwind database and stores them as JPG files in the file system.");
            Task5RetrieveImages();
            Console.WriteLine(new String('-', 50));
            Console.WriteLine("Task finished. Press a key to continue to next.");
            Console.ReadKey();

            Console.WriteLine("6 Read an Excel file with 2 columns: name and score");
            Task6ReadExcel();
            Console.WriteLine(new String('-', 50));
            Console.WriteLine("Task finished. Press a key to continue to next.");
            Console.ReadKey();

            Console.WriteLine("7 Implement appending new rows to the Excel file.");
            Task7InsertIntoExcel();
            Console.WriteLine(new String('-', 50));
            Console.WriteLine("Task finished. Press a key to continue to next.");
            Console.ReadKey();

            Console.WriteLine("8 Write a program that reads a string from the console and finds all products that contain this string.");
            Task8FindProductsByString();
            Console.WriteLine(new String('-', 50));
            Console.WriteLine("Task finished. Press a key to continue to next.");
            Console.ReadKey();
        }

        private static void Task8FindProductsByString()
        {
            Console.WriteLine("Enter string to search in products:");
            string key = "";
            while (key == "")
            {
                key = Console.ReadLine();
            }

            SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; " +
            "Database=Northwind; Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                SqlCommand cmdFindProductsByKey = new SqlCommand(
                    @"SELECT p.ProductName
FROM Products p
WHERE CHARINDEX(@key, p.ProductName) > 0", dbCon);

                cmdFindProductsByKey.Parameters.AddWithValue("@key", key);


                SqlDataReader reader = cmdFindProductsByKey.ExecuteReader();
                using (reader)
                {
                    Console.WriteLine("Searching for products that contain: {0}", key);
                    while (reader.Read())
                    {
                        string productName = (string)reader["ProductName"];
                        Console.WriteLine("{0}", productName);
                    }
                }
            }
        }                                   

        private static void Task7InsertIntoExcel()
        {
            // HDR - tells the provider that the source file has a header row
            string excelConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\..\\..\\source.xlsx;Extended Properties='Excel 12.0 xml;HDR=YES;'";

            OleDbConnection dbCon = new OleDbConnection(excelConnectionString);

            dbCon.Open();

            using (dbCon)
            {
                OleDbCommand cmd = new OleDbCommand(
                "INSERT INTO [Ratings$] ([Name], [Score]) VALUES (@name, @score)", dbCon);

                cmd.Parameters.AddWithValue("@name", "Ninja wannabe");
                cmd.Parameters.AddWithValue("@score", "3");

                // Execute command
                try
                {
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Row inserted successfully.");
                }
                catch (OleDbException exception)
                {
                    Console.WriteLine("Error occured: " + exception);
                }
            }
        }

        private static void Task6ReadExcel()
        {
            // HDR - tells the provider that the source file has a header row
            string excelConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\..\\..\\source.xlsx;Extended Properties='Excel 12.0 xml;HDR=YES;'";

            OleDbConnection dbCon = new OleDbConnection(excelConnectionString);

            dbCon.Open();

            using (dbCon)
            {
                OleDbCommand readCmd = new OleDbCommand("SELECT * FROM [Ratings$]", dbCon);
                var reader = readCmd.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        var name = reader["Name"];
                        var score = reader["Score"];
                        Console.WriteLine("{0}: {1}", name, score);
                    }
                }
            }

        }

        private static void Task5RetrieveImages()
        {
            SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; " +
            "Database=Northwind; Integrated Security=true");
            dbCon.Open();
            int index = 0;
            int imgMetaOffset = 78;
            using (dbCon)
            {
                SqlCommand cmdAllPics = new SqlCommand(
                    "SELECT Picture FROM Categories", dbCon);

                SqlDataReader reader = cmdAllPics.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        byte[] imgContents = (byte[])reader["Picture"];
                        string outputFile = String.Format("..\\..\\..\\{0}.jpg", index);
                        WriteBinaryFile(outputFile, imgContents, imgMetaOffset);
                        index++;
                    }
                }
            }
        }

        private static void WriteBinaryFile(string fileName,
        byte[] fileContents, int offset)
        {
            FileStream stream = File.OpenWrite(fileName);
            using (stream)
            {
                stream.Write(fileContents, offset, fileContents.Length - 78);
            }
        }

        private static void Task4AddNewProduct()
        {
            string productName = "P1 name";

            SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; " +
            "Database=Northwind; Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                SqlCommand cmdInsertProduct = new SqlCommand(
                    "INSERT INTO Products(ProductName)" +
                    "VALUES (@productName)", dbCon);
                cmdInsertProduct.Parameters.AddWithValue("@productName", productName);

                cmdInsertProduct.ExecuteNonQuery();

                SqlCommand cmdSelectIdentity = new SqlCommand("SELECT @@Identity", dbCon);
                int insertedRecordId = (int)(decimal)cmdSelectIdentity.ExecuteScalar();
                Console.WriteLine("New product added with id: {0}", insertedRecordId);
            }
        }

        private static void Task3GetCategoriesAndProducts()
        {
            SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; " +
            "Database=Northwind; Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                // GROUP BY also orders the categories and names
                SqlCommand cmdAllEmployees = new SqlCommand(
                    @"SELECT p.ProductName, c.CategoryName
                    FROM Products p
	                    INNER JOIN Categories c
	                    ON p.CategoryID = c.CategoryID
                    GROUP BY c.CategoryName, p.ProductName", dbCon);

                SqlDataReader reader = cmdAllEmployees.ExecuteReader();
                using (reader)
                {
                    string lastCategoryTitle = "";
                    while (reader.Read())
                    {
                        string categoryName = (string)reader["CategoryName"];
                        if (lastCategoryTitle != categoryName)
                        {
                            lastCategoryTitle = categoryName;
                            Console.WriteLine("{0}:", categoryName);
                        }

                        string description = (string)reader["ProductName"];
                        Console.WriteLine("    {0}", description);
                    }
                }
            }
        }

        static void Task2GetCategoriesNameAndDescription()
        {
            SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; " +
            "Database=Northwind; Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                SqlCommand cmdAllEmployees = new SqlCommand(
                    "SELECT CategoryName, Description FROM Categories", dbCon);

                SqlDataReader reader = cmdAllEmployees.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string name = (string)reader["CategoryName"];
                        string description = (string)reader["Description"];
                        Console.WriteLine("{0} - {1}", name, description);
                    }
                }
            }
        }

        static void Task1GetCategoriesCount()
        {
            SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; " +
            "Database=Northwind; Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                SqlCommand cmdCount = new SqlCommand(
                    "SELECT COUNT(*) FROM Categories", dbCon);
                int categoriesCount = (int)cmdCount.ExecuteScalar();
                Console.WriteLine("Categories count: {0} ", categoriesCount);
                Console.WriteLine();
            }
        }


    }
}
