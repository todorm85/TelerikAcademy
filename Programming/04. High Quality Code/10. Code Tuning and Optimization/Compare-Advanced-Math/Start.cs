namespace Compare_Advanced_Math
{
    using System;
    using System.Diagnostics;

    public class Start
    {
        public static void Main()
        {
            int testsCount = 10;
            int operationsPerTest = 10000000;

            Console.WriteLine("Testing System.Float32");
            TestArithmeticOperationPerformance(1f, testsCount, operationsPerTest);

            Console.WriteLine("Testing System.Float64");
            TestArithmeticOperationPerformance(1d, testsCount, operationsPerTest);

            Console.WriteLine("Testing System.Decimal");
            TestArithmeticOperationPerformance(1m, testsCount, operationsPerTest);
        }

        private static void TestArithmeticOperationPerformance(dynamic value, int testsCount, int operationsPerTest)
            //where T : struct, IConvertible
        {
            double res;
            value = 1;
            Console.WriteLine(value.GetType());
            long squareRootElapsedMiliseconds = 0;
            long logElapsedMiliseconds = 0;
            long sinusElapsedMiliseconds = 0;


            for (int j = 0; j < testsCount; j++)
            {
                // square root
                Stopwatch sw = Stopwatch.StartNew();
                for (int i = 0; i < operationsPerTest; i++)
                {
                    res = Math.Sqrt((dynamic)value);
                }

                squareRootElapsedMiliseconds += sw.ElapsedMilliseconds;

                // natural logarithm
                sw.Restart();
                for (int i = 0; i < operationsPerTest; i++)
                {
                    res = Math.Log((dynamic)value);
                }

                logElapsedMiliseconds += sw.ElapsedMilliseconds;

                // sinus
                sw.Restart();
                for (int i = 0; i < operationsPerTest; i++)
                {
                    res = Math.Sin((dynamic)value);
                }

                sinusElapsedMiliseconds += sw.ElapsedMilliseconds;
            }

            Console.WriteLine("Tsting with {0} ops per test with average for {1} test. ", operationsPerTest, testsCount);

            Console.WriteLine("Average miliseconds for SQUARE ROOT: " + squareRootElapsedMiliseconds / testsCount);
            Console.WriteLine("Average miliseconds for NATURAL LOGARITHM: " + logElapsedMiliseconds / testsCount);
            Console.WriteLine("Average miliseconds for SINUS: " + sinusElapsedMiliseconds / testsCount);

        }
        
    }
}
