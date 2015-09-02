namespace Compare_Simple_Math
{
    using System;
    using System.Diagnostics;

    public class Start
    {
        public static void Main()
        {
            int testsCount = 10;
            int operationsPerTest = 10000000;

            Console.WriteLine("Testing System.Int32");
            TestArithmeticOperationPerformance(1, testsCount, operationsPerTest);

            Console.WriteLine("Testing System.Int64");
            TestArithmeticOperationPerformance(1L, testsCount, operationsPerTest);

            Console.WriteLine("Testing System.Float32");
            TestArithmeticOperationPerformance(1f, testsCount, operationsPerTest);

            Console.WriteLine("Testing System.Float64");
            TestArithmeticOperationPerformance(1d, testsCount, operationsPerTest);

            Console.WriteLine("Testing System.Decimal");
            TestArithmeticOperationPerformance(1m, testsCount, operationsPerTest);

        }

        private static void TestArithmeticOperationPerformance<T>(T value1, int testsCount, int operationsPerTest)
            where T : struct, IConvertible
        {
            T value2 = value1;
            T res;

            long addElapsedMiliseconds = 0;
            long subtractElapsedMiliseconds = 0;
            long multiplyElapsedMiliseconds = 0;
            long divideElapsedMiliseconds = 0;


            for (int j = 0; j < testsCount; j++)
            {
                // add
                Stopwatch sw = Stopwatch.StartNew();
                for (int i = 0; i < operationsPerTest; i++)
                {
                    res = value1 + (dynamic)value2;
                }

                addElapsedMiliseconds += sw.ElapsedMilliseconds;

                // subtract
                sw.Restart();
                for (int i = 0; i < operationsPerTest; i++)
                {
                    res = value1 - (dynamic)value2;
                }

                subtractElapsedMiliseconds += sw.ElapsedMilliseconds;

                // multiply
                sw.Restart();
                for (int i = 0; i < operationsPerTest; i++)
                {
                    res = value1 * (dynamic)value2;
                }

                multiplyElapsedMiliseconds += sw.ElapsedMilliseconds;

                // divide
                sw.Restart();
                for (int i = 0; i < operationsPerTest; i++)
                {
                    res = value1 / (dynamic)value2;
                }

                divideElapsedMiliseconds += sw.ElapsedMilliseconds;
            }

            Console.WriteLine("Tsting with {0} ops per test with average for {1} test. ", operationsPerTest, testsCount);
            Console.WriteLine("Average miliseconds for ADD: " + addElapsedMiliseconds / testsCount);
            Console.WriteLine("Average miliseconds for SUBTRACT: " + subtractElapsedMiliseconds / testsCount);
            Console.WriteLine("Average miliseconds for MULTIPLY: " + subtractElapsedMiliseconds / testsCount);
            Console.WriteLine("Average miliseconds for DIVIDE: " + subtractElapsedMiliseconds / testsCount);
        }
    }
}
