namespace _12_ADTStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MyStack<T>
    {
        private const int InitialCapacity = 16;

        private T[] arr;

        public MyStack()
        {
            this.Capacity = InitialCapacity;
            this.arr = new T[this.Capacity];
            this.Count = 0;
        }

        public int Capacity { get; private set; }

        public int Count { get; private set; }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("No elements in stack.");
            }

            return this.arr[(this.Count--) - 1];
        }

        public void Push(T item)
        {
            this.arr[this.Count] = item;
            this.Count++;
            if (this.Count == arr.Length)
            {
                GrowCapacity();
            }
        }

        private void GrowCapacity()
        {
            this.arr.Concat(new T[this.Capacity]);
            this.Capacity *= 2;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("No elements in stack");
            }
            return this.arr[this.Count - 1];
        }
    }
}
