namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        private static Random rand = new Random();

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (var currentItem in items)
            {
                if (currentItem.CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T searchItem)
        {
            var start = 0;
            var end = items.Count - 1;

            while (end - start >= 0)
            {
                var mid = start + (end - start + 1) / 2;
                if (searchItem.CompareTo(items[mid]) < 0)
                {
                    end = mid - 1;
                }
                else if (searchItem.CompareTo(items[mid]) > 0)
                {
                    start = mid + 1;
                }
                else if (searchItem.CompareTo(items[mid]) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public void Shuffle()
        {
            for (int i = 0; i < items.Count - 1; i++)
            {
                var randdomIndex = rand.Next(i+1, items.Count);
                var currentValue = items[i];
                items[i] = items[randdomIndex];
                items[randdomIndex] = currentValue;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
