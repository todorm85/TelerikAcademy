namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            var min = collection[0];
            for (int i = 0; i < collection.Count - 1; i++)
            {
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[i].CompareTo(collection[j]) > 0)
                    {
                        var smallerValue = collection[j];
                        collection[j] = collection[i];
                        collection[i] = smallerValue;
                    }
                }
            }
        }
    }
}