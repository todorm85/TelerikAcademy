using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Problem
{
    internal class Program
    {
        const string EndLine = "end";
        static string line;
        static string testName = "000.001";

        //private static void Main()
        //{
        //    Inputs.SetInput(testName);
        //    var ow = new StreamWriter($@"..\..\test.{testName}.result.txt");
        //    Console.SetOut(ow);

        //    // Solution start
        //    GetInput();
        //    //Solution end

        //    ow.Dispose();
        //}

        private static void Main()
        {
            GetInput();
        }


        private static void GetInput()
        {
            line = Console.ReadLine();
            while (line != EndLine)
            {
                ParseLine(line);
                line = Console.ReadLine();
            }
        }

        private static void ParseLine(string line)
        {
            var lineComponents = line.Split(' ');

            if (line.StartsWith("add"))
            {
                Add(lineComponents);
            }
            else if (line.StartsWith("filter by type"))
            {
                FilterByType(lineComponents);
            }
            else if (line.StartsWith("filter by price from") && lineComponents.Length == 7)
            {
                FilterByPriceRange(lineComponents);
            }
            else if (line.StartsWith("filter by price from") && lineComponents.Length == 5)
            {
                FilterByPriceFrom(lineComponents);
            }
            else if (line.StartsWith("filter by price to"))
            {
                FilterByPriceTo(lineComponents);
            }
        }

        private static void FilterByPriceTo(string[] lineComponents)
        {
            var maxPrice = double.Parse(lineComponents[4]);

            var filteredProducts = all.Where(x => x.Price <= maxPrice);
            var orderedFiltered = OrderBy(filteredProducts);
            var productList = orderedFiltered.Select(x => x.ToString()).ToList();

            PrintResult(productList);
        }

        private static void FilterByPriceFrom(string[] lineComponents)
        {
            var minPrice = double.Parse(lineComponents[4]);

            var filteredProducts = all.Where(x => x.Price >= minPrice);
            var orderedFiltered = OrderBy(filteredProducts);
            var productList = orderedFiltered.Select(x => x.ToString()).ToList();

            PrintResult(productList);
        }

        private static void FilterByPriceRange(string[] lineComponents)
        {
            var minPrice = double.Parse(lineComponents[4]);
            var maxPrice = double.Parse(lineComponents[6]);

            var filteredProducts = all.Where(x => x.Price >= minPrice && x.Price <= maxPrice);
            var orderedFiltered = OrderBy(filteredProducts);
            var productList = orderedFiltered.Select(x => x.ToString()).ToList();

            PrintResult(productList);
        }

        private static void FilterByType(string[] lineComponents)
        {
            var filterType = lineComponents[3];

            if (!byType.ContainsKey(filterType))
            {
                Console.WriteLine("Error: Type {0} does not exists", filterType);
                return;
            }

            var filteredProducts = byType[filterType];
            var orderedFiltered = OrderBy(filteredProducts);
            var productList = orderedFiltered.Select(x => x.ToString()).ToList();

            PrintResult(productList);
        }

        private static void PrintResult(List<string> productList)
        {
            // todo: spped up with StringBuilder
            //var result = string.Join(", ", productList);
            //result = "Ok: " + result;

            var sb = new StringBuilder("Ok: ");
            for (int i = 0; i < productList.Count; i++)
            {
                sb.Append(productList[i]);
                if (i == productList.Count - 1)
                {
                    continue;
                }

                sb.Append(", ");
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }

        private static IEnumerable<Product> OrderBy(IEnumerable<Product> filteredProducts)
        {
            return filteredProducts
                .OrderBy(x => x.Price)
                .ThenBy(x => x.Name)
                .ThenBy(x => x.Type)
                .Take(10);
        }

        static HashSet<Product> all = new HashSet<Product>();
        static Dictionary<string, HashSet<Product>> byType = new Dictionary<string, HashSet<Product>>();

        private static void Add(string[] lineComponents)
        {
            var name = lineComponents[1];
            var price = double.Parse(lineComponents[2]);
            var type = lineComponents[3];

            var product = new Product(name, price, type);

            if (all.Contains(product))
            {
                Console.WriteLine("Error: Product {0} already exists", product.Name);
                return;
            }

            all.Add(product);

            if (!byType.ContainsKey(type))
            {
                byType[type] = new HashSet<Product>();
            }

            byType[type].Add(product);

            Console.WriteLine("Ok: Product {0} added successfully", name);
        }

        private class Product
        {
            public Product(string name, double price, string type)
            {
                this.Name = name;
                this.Price = price;
                this.Type = type;

            }

            public string Name { get; private set; }
            public double Price { get; private set; }
            public string Type { get; private set; }

            public override int GetHashCode()
            {
                return this.Name.GetHashCode() + this.Price.GetHashCode() + this.Type.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                var other = (Product)obj;
                if (this.Name == other.Name && this.Price == other.Price && this.Type == other.Type)
                {
                    return true;
                }

                return false;
            }

            public override string ToString()
            {
                return string.Format("{0}({1})", this.Name, this.Price);
            }
        }
    }
}