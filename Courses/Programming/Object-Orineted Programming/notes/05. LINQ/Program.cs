using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

            // google -> 101 linq examples -> vey useful

namespace _05.LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string delimiter = new string('-', 50);
            Console.WriteLine("\n\nTest1");
            Console.WriteLine(delimiter);

            int[] nums = { 4, 2, 5, 12, 5, 7, 76, 42 };

            var querySmallNums =
                from num in nums
                where num < 5
                select num;
            foreach (var item in querySmallNums)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n\nTest2");
            Console.WriteLine(delimiter);

            string[] towns = { "Sofia", "Pleven", "Burgas" };

            var townPairs =
                from t1 in towns
                from t2 in towns
                select new { T1 = t1, T2 = t2 };

            foreach (var pair in townPairs)
            {
                Console.WriteLine(pair);
            }

            Console.WriteLine("\n\nTest3");
            Console.WriteLine(delimiter);

            string[] fruits = { "cherry", "apple", "pear" };
            var sortedFruits =
                from fruit in fruits
                orderby fruit
                select fruit;
            foreach (var fruit in sortedFruits)
            {
                Console.Write(fruit + " ");
            }

            Console.WriteLine("\n\nTest4");
            Console.WriteLine(delimiter);

            var games = new string[] { "Warriors of Fate", "Cadillacs and Dinosaurs", "Art of fighting", "Metal Slug", "Americana" };
            // With extension methods in Linq
            var subset = games.Where(game => game.Length < 13).OrderBy(game => game).Select(game => game);
            foreach (var item in subset)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            // with Linq special words
            var subset2 =
                from game in games
                where game.Length < 13
                orderby game
                select game;
            foreach (var item in subset2)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n\nTest5");
            Console.WriteLine(delimiter);

            string text = "Historically the world of data data...";
            string searchWord = "data";
            string[] source = text.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            // with linq query words
            var foundMatch =
                from word in source
                where word.ToLower() == searchWord.ToLower()
                select word;
            Console.WriteLine(foundMatch.Count());
            // with linq extension methods
            var foundCount = source.Count(word => word.ToLower() == searchWord.ToLower());
            Console.WriteLine(foundCount);

            Console.WriteLine("\n\nTest6");
            Console.WriteLine(delimiter);

            var books = new[] {
                new { Title= "LINQ in Action"},
                new { Title = "LINQ for Fun"},
                new { Title = "Extreme LINQ"}
            };

            var titles =
                from book in books
                where book.Title.Contains("Action")
                select book.Title;
            foreach (var title in titles)
            {
                Console.WriteLine(title+" ");
            }

            Console.WriteLine("\n\nTest7");
            Console.WriteLine(delimiter);

            var count = "Non-letter characters in this string: 8".
                Count(c => !Char.IsLetter(c));
            Console.WriteLine(count);

            var count2 =
                (from c in "Non-letter characters in this string: 8"
                 where !Char.IsLetter(c)
                 select c).Count();
            Console.WriteLine(count2);

            Console.WriteLine("\n\nTest8");
            Console.WriteLine(delimiter);

            double[] temperature = { 28.0, 37.0, 41.3, 38.5, 36.4 };
            int highTempCount = temperature.Count(temp => temp >= 37);
            Console.WriteLine(highTempCount);

            var maxTemp = temperature.Where(temp => temp < 41).Max();
            Console.WriteLine(maxTemp);
        }
    }
}
