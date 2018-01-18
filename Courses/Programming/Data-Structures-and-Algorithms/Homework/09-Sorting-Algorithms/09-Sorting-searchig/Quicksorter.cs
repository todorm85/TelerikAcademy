namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        private T[] values;

        public void Sort(IList<T> arr)
        {
            values = arr.ToArray();
            var indices = Enumerable.Range(0, arr.Count).ToArray();

            QuickSort(indices, 0, indices.Length - 1);

            for (int i = 0; i < indices.Length; i++)
            {
                arr[i] = values[indices[i]];
            }
        }

        private void QuickSort(int[] indices, int startRange, int endRange)
        {
            if (endRange - startRange < 1)
            {
                return;
            }

            var pivotIndex = Partition(indices, startRange, endRange);
            QuickSort(indices, startRange, pivotIndex - 1);
            QuickSort(indices, pivotIndex + 1, endRange);
        }

        private int Partition(int[] indices, int startRange, int endRange)
        {
            var pivotValue = values[indices[startRange]];

            var pivotInsertIndex = startRange;
            for (int i = startRange + 1; i <= endRange; i++)
            {
                var currentValue = values[indices[i]];

                if (currentValue.CompareTo(pivotValue) < 0)
                {
                    Swap(ref indices[i], ref indices[pivotInsertIndex + 1]);
                    pivotInsertIndex++;
                }
            }

            Swap(ref indices[startRange], ref indices[pivotInsertIndex]);

            return pivotInsertIndex;
        }

        private void Swap(ref int v1, ref int v2)
        {
            var firstValue = v1;
            v1 = v2;
            v2 = firstValue;
        }
    }
}