using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int t = int.Parse(Console.ReadLine());

        for (int k = 0; k < t; k++)
        {
            // get first sequence of numbers
            string sequenceString = Console.ReadLine();
            long[] numbers = sequenceString.Split(' ').Select(long.Parse).ToArray();
            long[] absDiffSeq = new long[numbers.Length - 1];

            // construct absolute difference sequence
            for (int i = 1; i < numbers.Length; i++)
            {
                absDiffSeq[i - 1] = Math.Abs(numbers[i] - numbers[i - 1]);
            }

            // check if absdiffseq is decreasing
            bool isDecreasing = true;
            for (int i = 1; i < absDiffSeq.Length; i++)
            {
                if (Math.Abs(absDiffSeq[i] - absDiffSeq[i - 1]) != 0 && Math.Abs(absDiffSeq[i] - absDiffSeq[i - 1]) != 1)
                {
                    isDecreasing = false;
                    break;
                }

                if (absDiffSeq[i] > absDiffSeq[i - 1])
                {
                    isDecreasing = false;
                    break;
                }
            }

            Console.WriteLine(isDecreasing);
        }
    }
}
