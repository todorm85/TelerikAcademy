namespace _12_ADTStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        private static void Main()
        {
            var stack = new MyStack<int>();
            PrintStackInfo(stack);
            TryToPop(stack);

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Pushing 1");
            stack.Push(1);
            PrintStackInfo(stack);
            TryToPop(stack);
            PrintStackInfo(stack);

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Pushing 100");
            stack.Push(100);
            PrintStackInfo(stack);

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("No operation since last Peek");

            PrintStackInfo(stack);

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Adding 16 elements");

            for (int i = 0; i < 15; i++)
            {
                stack.Push(i+2);
            }

            PrintStackInfo(stack);

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Popping 16 elements");
            for (int i = 0; i < 16; i++)
            {
                TryToPop(stack);
            }

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Trying to pop one more element.");
            TryToPop(stack);

            PrintStackInfo(stack);

        }

        private static void PrintStackInfo(MyStack<int> stack)
        {
            Console.WriteLine(new string('-', 50));

            Console.WriteLine($"Capacity: {stack.Capacity}");
            Console.WriteLine($"Count: {stack.Count}");

            try
            {
                Console.Write("Peek: ");
                Console.WriteLine(stack.Peek());

            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void TryToPop(MyStack<int> stack)
        {
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Popping");
            try
            {
                Console.WriteLine($"Popped: {stack.Pop()}");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}