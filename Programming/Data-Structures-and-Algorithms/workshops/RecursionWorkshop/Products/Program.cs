namespace Products2
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;

    class Program
    {

        private static Bag<Product> products = new Bag<Product>();
        private static Dictionary<string, Bag<Product>> productsByName = new Dictionary<string, Bag<Product>>();
        private static Dictionary<string, Bag<Product>> productsByProducer = new Dictionary<string, Bag<Product>>();

        private static void GenerateSampleInput()
        {
            var input1 = @"14
AddProduct IdeaPad Z560;1536.50;Lenovo
AddProduct ThinkPad T410;3000;Lenovo
AddProduct VAIO Z13;4099.99;Sony
AddProduct CLS 63 AMG;200000;Mercedes
FindProductsByName CLS 63 AMG
FindProductsByName CLS 63
FindProductsByName cls 63 amg
AddProduct 320i;10000;BMW
FindProductsByName 320i
AddProduct G560;999;Lenovo
FindProductsByProducer Lenovo
DeleteProducts Lenovo
FindProductsByProducer Lenovo
FindProductsByPriceRange 100000;200000";

            var inputReader = new StringReader(input1);
            Console.SetIn(inputReader);
        }

        static void Main(string[] args)
        {
            //GenerateSampleInput();

            ParseInput();
        }

        private static void ParseInput()
        {
            var linesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < linesCount; i++)
            {
                var line = Console.ReadLine();
                if (line.StartsWith("AddProduct"))
                {
                    AddProdcut(line.Substring(11));
                }

                if (line.StartsWith("FindProductsByName"))
                {
                    FindProductsByName(line.Substring(19));
                }

                if (line.StartsWith("DeleteProducts"))
                {
                    DeleteProducts(line.Substring(15));
                }

                if (line.StartsWith("FindProductsByProducer"))
                {
                    FindProductsByProducer(line.Substring(23));
                }

                if (line.StartsWith("FindProductsByPriceRange"))
                {
                    FindProductsByPriceRange(line.Substring(25));
                }
            }
        }

        private static void FindProductsByPriceRange(string input)
        {
            var inputs = input.Split(';');
            var minPrice = decimal.Parse(inputs[0]);
            var maxPrice = decimal.Parse(inputs[1]);

            var foundProducts = products
                .Where(x => minPrice <= x.Price && x.Price <= maxPrice)
                .Select(x =>
                {
                    var sb = new StringBuilder();
                    sb.Append("{");
                    sb.Append(x.Name);
                    sb.Append(";");
                    sb.Append(x.Producer);
                    sb.Append(";");
                    sb.Append(x.Price.ToString("F2"));
                    sb.Append("}");
                    return sb.ToString();
                })
                .OrderBy(x => x);

            if (foundProducts.Count() == 0)
            {
                Console.WriteLine("No products found");
            }
            else
            {
                foreach (var product in foundProducts)
                {
                    Console.WriteLine(product);
                }
            }
        }

        private static void FindProductsByProducer(string producer)
        {
            if (!productsByProducer.ContainsKey(producer))
            {
                Console.WriteLine("No products found");
                return;
            }

            var foundProducts = productsByProducer[producer]
                .Select(x =>
                {
                    var sb = new StringBuilder();
                    sb.Append("{");
                    sb.Append(x.Name);
                    sb.Append(";");
                    sb.Append(x.Producer);
                    sb.Append(";");
                    sb.Append(x.Price.ToString("F2"));
                    sb.Append("}");
                    return sb.ToString();
                })
                .OrderBy(x => x);

            foreach (var product in foundProducts)
            {
                Console.WriteLine(product);
            }
        }

        private static void DeleteProducts(string input)
        {
            var inputs = input.Split(';');
            if (inputs.Length > 1)
            {
                var name = inputs[0];
                var producer = inputs[1];

                if (!productsByName.ContainsKey(name) || productsByName[name].Count == 0)
                {
                    Console.WriteLine("No products found");
                    return;
                }

                var foundProductsCount = productsByName[name].Count;

                productsByName[name].RemoveAll(x => x.Producer == producer);
                productsByProducer[producer].RemoveAll(x => x.Name == name);
                products.RemoveAll(x => x.Name == name && x.Producer == producer);

                Console.WriteLine("{0} products deleted", foundProductsCount);
            }
            else
            {
                var producer = inputs[0];
                if (!productsByProducer.ContainsKey(producer) || productsByProducer[producer].Count == 0)
                {
                    Console.WriteLine("No products found");
                    return;
                }

                var namesOfProductsToRemove = productsByProducer[producer].Select(x => x.Name);
                var foundProductsCount = productsByProducer[producer].Count;

                productsByProducer.Remove(producer);
                products.RemoveAll(x => x.Producer == producer);

                foreach (var name in namesOfProductsToRemove)
                {
                    productsByName[name].RemoveAll(x => x.Producer == producer);
                }

                Console.WriteLine("{0} products deleted", foundProductsCount);
            }
        }

        private static void FindProductsByName(string name)
        {
            if (!productsByName.ContainsKey(name))
            {
                Console.WriteLine("No products found");
                return;
            }

            var foundProducts = productsByName[name]
                .Select(x =>
                {
                    var sb = new StringBuilder();
                    sb.Append("{");
                    sb.Append(x.Name);
                    sb.Append(";");
                    sb.Append(x.Producer);
                    sb.Append(";");
                    sb.Append(x.Price.ToString("F2"));
                    sb.Append("}");
                    return sb.ToString();
                })
                .OrderBy(x => x);

            foreach (var product in foundProducts)
            {
                Console.WriteLine(product);
            }
        }

        private static void AddProdcut(string input)
        {
            var productDetials = input.Split(';');
            var name = (productDetials[0]);
            var price = decimal.Parse(productDetials[1]);
            var producer = productDetials[2];

            var newProduct = new Product(name, price, producer);

            products.Add(newProduct);

            if (!productsByName.ContainsKey(name))
            {
                productsByName.Add(name, new Bag<Product>());
            }

            productsByName[name].Add(newProduct);

            if (!productsByProducer.ContainsKey(producer))
            {
                productsByProducer.Add(producer, new Bag<Product>());
            }

            productsByProducer[producer].Add(newProduct);

            Console.WriteLine("Product added");
        }
    }


    internal class Product
    {
        public Product(string name, decimal price, string producer)
        {
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
        }

        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Producer { get; private set; }
    }
}
