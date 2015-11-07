namespace _02_Articles
{
    using System;
    using Common;
    using Wintellect.PowerCollections;

    internal class Program
    {
        private const int ArticlesCount = 1000000;
        private const decimal MaxPrice = 150;
        private const decimal MinPrice = 50;

        private static void Main()
        {
            var articles = new OrderedMultiDictionary<decimal, Article>(false);
            var rand = new RandomGenerator();

            Console.WriteLine($"Populating {ArticlesCount} articles");
            for (int i = 0; i < ArticlesCount; i++)
            {
                string title = rand.GetRandomString(5, 10);
                string vendor = rand.GetRandomString(5, 10);
                decimal price = rand.GetRandomInteger(10, 2500);
                string barcode = rand.GetRandomString(10, 15);

                var article = new Article(title, barcode, vendor, price);
                articles.Add(price, article);
            }

            Console.WriteLine($"Searching for articles in price range {MinPrice} - {MaxPrice}");
            var extractedArticles = articles.Range(MinPrice, true, MaxPrice, true);

            Console.WriteLine("Finished search. Man that was fast!\nPress a key to start printing to console...");
            Console.ReadLine();

            foreach (var priceArticles in extractedArticles)
            {
                foreach (var article in priceArticles.Value)
                {
                    Console.WriteLine($"Title: {article.Title}, price: {article.Price}");
                }
            };

            Console.WriteLine($"\n\nThats all articles in price range {MinPrice} - {MaxPrice} for {ArticlesCount} articles.\n\n");
        }
    }
}