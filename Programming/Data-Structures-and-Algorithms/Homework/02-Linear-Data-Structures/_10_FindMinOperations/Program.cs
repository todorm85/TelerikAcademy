//We are given numbers N and M and the following operations:

//N = N+1
//N = N+2
//N = N*2

//Write a program that finds the shortest sequence of operations from the list above that starts from N and finishes in M.

//Hint: use a queue.
//Example: N = 5, M = 16
//Sequence: 5 → 7 → 8 → 16

namespace _10_FindQuickestOperations
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main()
        {
            int start = 11;
            int end = 16;

            FindQuickestOperations(start, end);
            FindQuickestOperations(5, 16);
        }

        private static void FindQuickestOperations(int start, int end)
        {
            if (start >= end)
            {
                throw new ArgumentException("start must be smaller than end");
            }

            var path = new List<int>();
            path.Add(start);

            if (start <= end / 2)
            {
                while (start * 2 <= end / 2)
                {
                    start *= 2;
                    path.Add(start);
                }

                if (start != end / 2)
                {
                    while (start + 2 <= end / 2)
                    {
                        start += 2;
                        path.Add(start);
                    }
                }

                if (start != end / 2)
                {
                    start++;
                    path.Add(start);
                }

                start *= 2;
                path.Add(start);
                Console.WriteLine(string.Join(" ", path));
            }
            else
            {
                while (start + 2 <= end)
                {
                    start += 2;
                    path.Add(start);
                }

                if (start != end)
                {
                    start++;
                    path.Add(start);
                }

                Console.WriteLine(string.Join(" ", path));
            }
        }
    }
}