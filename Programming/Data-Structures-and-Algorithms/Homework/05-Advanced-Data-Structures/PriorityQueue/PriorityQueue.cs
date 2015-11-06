namespace MyDataStructures
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T>
        where T : IComparable<T>
    {
        /// <summary>
        /// Inner list to store the binary tree values. A binary heap is essentialy a binary tree that is built on some logic.
        /// </summary>
        private List<T> innerArray = new List<T>();

        public void Add(T value)
        {
            innerArray.Add(value);
            if (innerArray.Count <= 1)
            {
                return;
            }

            var lastIndex = innerArray.Count - 1;
            var parentIndex = GetParentIndex(lastIndex);
            // todo: if index is -1?
            while (innerArray[lastIndex].CompareTo(innerArray[parentIndex]) > 0)
            {
                SwapElements(lastIndex, parentIndex);
                if (parentIndex == 0)
                {
                    break;
                }

                lastIndex = parentIndex;
                parentIndex = GetParentIndex(lastIndex);
            }
        }

        public T Pop()
        {
            if (innerArray.Count <= 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }

            var result = innerArray[0];
            innerArray[0] = innerArray[innerArray.Count - 1];
            innerArray.RemoveAt(innerArray.Count - 1);

            var parentIndex = 0;
            var childIndex = GetIndexOfBiggerChild(parentIndex);
            while (childIndex >= 0 && innerArray[parentIndex].CompareTo(innerArray[childIndex]) < 0)
            {
                SwapElements(parentIndex, childIndex);
                parentIndex = childIndex;
                childIndex = GetIndexOfBiggerChild(parentIndex);
            }

            return result;
        }

        public int Count { get { return this.innerArray.Count; } }

        private void SwapElements(int lastIndex, int parentIndex)
        {
            var lastValue = innerArray[lastIndex];
            innerArray[lastIndex] = innerArray[parentIndex];
            innerArray[parentIndex] = lastValue;
        }

        /// <summary>
        /// Gets the index of the bigger of the two childs or the index of the only child if only one exists. If no childs exist returns -1.
        /// </summary>
        private int GetIndexOfBiggerChild(int parentIndex)
        {
            if (parentIndex < 0)
            {
                throw new ArgumentOutOfRangeException("Element index cannot be negative!");
            }

            var firstChildIndex = parentIndex * 2 + 1;
            var secondChildIndex = parentIndex * 2 + 2;

            if (secondChildIndex >= this.innerArray.Count)
            {
                if (firstChildIndex >= this.innerArray.Count)
                {
                    return -1;
                }

                return firstChildIndex;
            }

            if (innerArray[firstChildIndex].CompareTo(innerArray[secondChildIndex]) < 0)
            {
                return secondChildIndex;
            }

            return firstChildIndex;
        }

        private int GetParentIndex(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Index cannot be negative.");
            }

            if (index == 0)
            {
                return -1;
            }

            int parentIndex = (index - 1) / 2;

            return parentIndex;
        }
    }
}