namespace Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public static class Startup
    {
        private const int ProductsCount = 500000;
        private const int PriceSearchCount = 10000;

        static void Main()
        {
            Console.WriteLine("Populating bag.");
            var orderedBag = new OrderedBag<Product>();
            var rand = new RandomGenerator();
            for (int i = 0; i < ProductsCount; i++)
            {
                orderedBag.Add(rand.GetRandomProduct());
                if (i % 1000 == 0)
                {
                    Console.Write(".");
                }
            }

            Console.WriteLine("\nSearching for products.");
            for (int i = 0; i < PriceSearchCount; i++)
            {
                var result = orderedBag.FindProductsByPrice(50, 100);
                Console.WriteLine($"Search {i} finished.");
            }

            Console.WriteLine("\nSample search result:");
            orderedBag.FindProductsByPrice(50, 100).ForEach(Console.WriteLine);

        }

        private static List<Product> FindProductsByPrice(this OrderedBag<Product> bag, decimal minPrice, decimal maxPrice)
        {
            var foundProducts = new List<Product>();
            var minPriceProduct = new Product("minPricedProduct", minPrice);
            var maxPriceProduct = new Product("maxPricedProduct", maxPrice);

            return bag.Range(minPriceProduct, true, maxPriceProduct, true).Take(20).ToList();
        }
    }
}
