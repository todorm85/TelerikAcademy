namespace _13_ADTQueueAsLinkedList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        private static void Main()
        {
            var first = new LinkedQueueItem<int>(1);
            var sec = new LinkedQueueItem<int>(2);

            var q = new LinkedQueue<int>();

            try
            {
                Console.WriteLine(q.Dequeue());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("-----Enqueuing 1");
            q.Enqueue(first);
            Console.WriteLine("-----Dequeuing");
            Console.WriteLine(q.Dequeue().Value);
            Console.WriteLine("-----Enqueuing value 1");
            q.Enqueue(first);
            Console.WriteLine("-----Enqueuing value 2");
            q.Enqueue(sec);
            Console.WriteLine("-----Dequeuing");
            Console.WriteLine(q.Dequeue().Value);
            Console.WriteLine("-----Dequeuing");
            Console.WriteLine(q.Dequeue().Value);

            Console.WriteLine("-----Dequeuing");
            try
            {
                Console.WriteLine(q.Dequeue());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("-----Enqueuing value 1");
            q.Enqueue(first);
            try
            {
                Console.WriteLine("-----Enqueuing value 1");
                q.Enqueue(first);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine("-----Enqueuing null");
                q.Enqueue(null);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}