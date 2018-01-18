using System.Collections;
using System.Collections.Generic;

namespace _11_LinkedList
{
    public class LinkedList<T> : IEnumerable<ListItem<T>>
    {
        public LinkedList(ListItem<T> firstItem)
        {
            this.FirstItem = firstItem;
        }

        public ListItem<T> FirstItem { get; set; }

        public IEnumerator<ListItem<T>> GetEnumerator()
        {
            var currentItem = this.FirstItem;

            while (currentItem != null)
            {
                yield return currentItem;
                currentItem = currentItem.NextItem;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}