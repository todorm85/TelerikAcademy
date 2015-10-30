namespace _13_ADTQueueAsLinkedList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LinkedQueue<T>
    {
        public LinkedQueueItem<T> FirstItem { get; private set; }
        public LinkedQueueItem<T> LastItem { get; private set; }
        private List<LinkedQueueItem<T>> EnqueuedInstances { get; set; }
        public LinkedQueue()
        {
            this.FirstItem = null;
            this.LastItem = null;
            this.EnqueuedInstances = new List<LinkedQueueItem<T>>();
        }

        public void Enqueue(LinkedQueueItem<T> item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Cannot add null items.");
            }

            if (this.EnqueuedInstances.Contains(item))
            {
                throw new InvalidOperationException("Instance already added.");
            }

            if (this.FirstItem == null)
            {
                this.FirstItem = item;
                this.LastItem = item;
            }
            else
            {
                this.LastItem.NextItem = item;
            }

            this.EnqueuedInstances.Add(item);
        }

        public LinkedQueueItem<T> Dequeue()
        {
            if (this.FirstItem == null)
            {
                throw new InvalidOperationException("No items in queue.");
            }

            var dequeuedItem = this.FirstItem;
            this.EnqueuedInstances.Remove(dequeuedItem);
            this.FirstItem = this.FirstItem.NextItem;
            return dequeuedItem;
        }
    }
}
