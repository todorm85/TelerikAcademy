/*
Write a program that reads N integers from the console and reverses them using a stack.

Use the Stack<int> class.
*/

namespace _02_ReverseStack
{
    using System;
    using System.Collections.Generic;
    using Common;

    public class ReverseStack
    {
        public static void Main()
        {
            //var numbers = DataProvider.GetNumbersListInput<int>();
            var numbers = DataProvider.GetRandomNumbersList<int>(5);

            var numbersStack = new Stack<int>(numbers);

            // foreach on Stack<T> gets the values in reversed order of their addition.
            Console.WriteLine("Numbers reversed:");
            foreach (var number in numbersStack)
            {
                Console.WriteLine(number.ToString());
            }
        }
    }
}