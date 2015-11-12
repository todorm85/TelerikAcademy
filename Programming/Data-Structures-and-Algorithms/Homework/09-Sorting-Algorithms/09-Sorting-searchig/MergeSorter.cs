namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        private T[] values;

        public void Sort(IList<T> arr)
        {
            values = arr.ToArray();
            var indices = Enumerable.Range(0, values.Length).ToArray();

            MergeSort(indices, 0, indices.Length - 1);

            for (int i = 0; i < indices.Length; i++)
            {
                arr[i] = values[indices[i]];
            }
        }

        private void MergeSort(int[] indices, int startRange, int endRange)
        {
            if (endRange - startRange < 1)
            {
                return;
            }

            var midRange = startRange + (endRange - startRange) / 2;
            MergeSort(indices, startRange, midRange);
            MergeSort(indices, midRange + 1, endRange);

            var sortedIndices = new List<int>();
            var leftSubrangeIndex = startRange;
            var rightSubrangeIndex = midRange + 1;
            var rangeLength = endRange - startRange + 1;
            for (int i = 0; i < rangeLength; i++)
            {
                if (rightSubrangeIndex > endRange)
                {
                    sortedIndices.Add(indices[leftSubrangeIndex]);
                    leftSubrangeIndex++;
                    continue;
                }

                if (leftSubrangeIndex > midRange)
                {
                    sortedIndices.Add(indices[rightSubrangeIndex]);
                    rightSubrangeIndex++;
                    continue;
                }

                if (values[indices[leftSubrangeIndex]].CompareTo(values[indices[rightSubrangeIndex]]) < 0)
                {
                    sortedIndices.Add(indices[leftSubrangeIndex]);
                    leftSubrangeIndex++;
                }
                else
                {
                    sortedIndices.Add(indices[rightSubrangeIndex]);
                    rightSubrangeIndex++;
                }
            }

            for (int i = startRange; i < startRange + rangeLength; i++)
            {
                indices[i] = sortedIndices[i - startRange];
            }
        }
    }
}