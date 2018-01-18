using System;
using System.Collections;

namespace _11_LinkedList
{
    public class ListItem<T>
    {
        public ListItem(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }
        public ListItem<T> NextItem { get; set; }
    }
}