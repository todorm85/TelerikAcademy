namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Program
    {
        private static Random rand = new Random();

        internal static void Main(string[] args)
        {
            var randomArr = GetRandomArr(15);
            randomArr[15 / 2] = 101; 
            var collection = new SortableCollection<int>(randomArr);

            Console.WriteLine("All items before sorting:");
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            Console.WriteLine("SelectionSorter result:");
            collection.Sort(new SelectionSorter<int>());
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            collection = new SortableCollection<int>(randomArr);
            Console.WriteLine("Quicksorter result:");
            collection.Sort(new Quicksorter<int>());
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            collection = new SortableCollection<int>(randomArr);
            Console.WriteLine("MergeSorter result:");
            collection.Sort(new MergeSorter<int>());
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            Console.WriteLine("Linear search 101:");
            Console.WriteLine(collection.LinearSearch(101));
            Console.WriteLine();

            Console.WriteLine("Binary search 101:");
            Console.WriteLine(collection.BinarySearch(101));
            Console.WriteLine();

            Console.WriteLine("Binary search 301:");
            Console.WriteLine(collection.BinarySearch(301));
            Console.WriteLine();

            Console.WriteLine("Shuffle:");
            collection.Shuffle();
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            Console.WriteLine("Shuffle again:");
            collection.Shuffle();
            collection.PrintAllItemsOnConsole();
        }

        private static int[] GetRandomArr(int length)
        {
            var arr = new int[length];
            for (int i = 0; i < length; i++)
            {
                arr[i] = rand.Next(0, 200);
            }

            return arr;
        }
    }
}
