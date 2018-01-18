namespace _13_ADTQueueAsLinkedList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LinkedQueueItem<T>
    {
        public T Value { get; set; }
        public LinkedQueueItem<T> NextItem { get; set; }
        public LinkedQueueItem(T value)
        {
            this.Value = value;
        }
    }
}
