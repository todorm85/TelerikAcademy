//We are given the following sequence:

//S1 = N;
//S2 = S1 + 1;
//S3 = 2* S1 + 1;
//S4 = S1 + 2;
//S5 = S2 + 1;
//S6 = 2* S2 + 1;
//S7 = S2 + 2;
//...
//Using the Queue<T> class write a program to print its first 50 members for given N.
//Example: N= 2 → 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...

namespace _09_QueueSequence
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main()
        {
            var elementsToCalculate = 50;
            var initialValue = 2;

            CalculateSequence(initialValue, elementsToCalculate);
        }

        private static void CalculateSequence(int initialValue, int elementsToCalculate)
        {
            var baseValuesQueue = new Queue<int>();
            baseValuesQueue.Enqueue(initialValue);

            var sequence = new List<int>();
            sequence.Add(initialValue);

            while (sequence.Count < elementsToCalculate)
            {
                var baseValue = baseValuesQueue.Dequeue();

                baseValuesQueue.Enqueue(baseValue + 1);
                baseValuesQueue.Enqueue(2 * baseValue + 1);
                baseValuesQueue.Enqueue(baseValue + 2);

                sequence.Add(baseValue + 1);
                sequence.Add(2 * baseValue + 1);
                sequence.Add(baseValue + 2);
            }

            Console.WriteLine(string.Join(" ", sequence));
        }
    }
}