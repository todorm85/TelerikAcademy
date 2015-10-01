using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

////These are actually standard static methods in standart static classes that can be called on
////instances of already predefined classes (types).
////s.ExtensionMethod1(); 
////is the same as
////Extensions.ExtensionMethod1(s);

namespace Extension_methods
{
    public static class Extensions
    {
        public static int WordCount(this string input)
        {
            return input.Split(new char[] { ' ', '.', '?', '!', ':' },
                StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static void IncreaseWidth(
            this IList<int> list, int amount)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] += amount;
            }
        }

        public static string ToString<T>(this IEnumerable<T> input)
        {
            StringBuilder result = new StringBuilder();
            result.Append("[ ");
            foreach (var item in input)
            {
                result.Append(item.ToString());
                result.Append(" ");
            }
            result.Append("]");
            return result.ToString();
        }
    }
    
    class Program
    {
        static void Main()
        {
            string delimiter = new string('-', 50);

            // word count test
            string stringSentence = "There is something in here.";
            int wordCount = stringSentence.WordCount();
            Console.WriteLine(wordCount);
            wordCount = Extensions.WordCount(stringSentence);
            Console.WriteLine(wordCount);

            Console.WriteLine(delimiter);

            // list increase width test
            List<int> testIntList = new List<int>() { 1, 4, 3, 2, 7 };
            Console.WriteLine(testIntList.ToString<int>());
            testIntList.IncreaseWidth(5);
            Console.WriteLine(testIntList.ToString<int>());


        }
    }
}
