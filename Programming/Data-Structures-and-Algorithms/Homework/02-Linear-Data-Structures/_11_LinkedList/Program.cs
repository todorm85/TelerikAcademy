using System;

namespace _11_LinkedList
{
    internal class Program
    {
        private static void Main()
        {
            LinkedList<int> linkedList = GetLinkedList();

            foreach (var item in linkedList)
            {
                Console.WriteLine(item.Value);
            }
        }

        private static LinkedList<int> GetLinkedList()
        {
            var firstItem = new ListItem<int>(1);
            var secondItem = new ListItem<int>(2);
            var thirdItem = new ListItem<int>(3);
            var lastItem = new ListItem<int>(4);

            firstItem.NextItem = secondItem;
            secondItem.NextItem = thirdItem;
            thirdItem.NextItem = lastItem;

            var linkedList = new LinkedList<int>(firstItem);
            return linkedList;
        }
    }
}