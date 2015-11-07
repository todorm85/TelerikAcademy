namespace _01_NestedLoops
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Startup
    {
        private static int iterationsCount;
        private static int loopsCount;
        private static int[] loopResults;

        private static void Main()
        {
            iterationsCount = 2;
            loopsCount = 2;
            loopResults = new int[loopsCount];

            Loop(0);
        }

        private static void Loop(int currentLoop)
        {
            if (currentLoop == loopsCount)
            {
                PrintLoopResults();
                return;
            }

            for (int currentIteration = 1; currentIteration <= iterationsCount; currentIteration++)
            {
                loopResults[currentLoop] = currentIteration;
                var nextLoop = currentLoop + 1;
                Loop(nextLoop);
            }
        }

        private static void PrintLoopResults()
        {
            for (int i = 0; i < loopResults.Length; i++)
            {
                Console.Write(loopResults[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
