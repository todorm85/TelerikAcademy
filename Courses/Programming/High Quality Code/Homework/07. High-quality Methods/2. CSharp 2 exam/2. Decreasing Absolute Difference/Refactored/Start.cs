namespace Decreasing
{
    using System;
    using System.Linq;

    public class Start
    {
        public static void Main()
        {
            int inputLinesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputLinesCount; i++)
            {
                string currentInput = Console.ReadLine();
                long[] currentSequence = currentInput.Split(' ').Select(long.Parse).ToArray();

                long[] absoluteDifferenceSequence = new long[currentSequence.Length - 1];
                for (int j = 1; j < currentSequence.Length; j++)
                {
                    absoluteDifferenceSequence[j - 1] = Math.Abs(currentSequence[j] - currentSequence[j - 1]);
                }

                bool isDecreasing = true;
                for (int j = 1; j < absoluteDifferenceSequence.Length; j++)
                {
                    if (!(absoluteDifferenceSequence[j] - absoluteDifferenceSequence[j - 1] == 0
                        || absoluteDifferenceSequence[j] - absoluteDifferenceSequence[j - 1] == 1))
                    {
                        isDecreasing = false;
                        break;
                    }
                }

                Console.WriteLine(isDecreasing);
            }
        }
    }
}
