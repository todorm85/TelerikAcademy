namespace Printers
{
    internal class GenericPrinter
    {
        public void PrintStatistics(double[] numbers, int numbersCount)
        {
            double maxNumber = double.MinValue;
            for (int i = 0; i < numbersCount; i++)
            {
                if (numbers[i] > maxNumber)
                {
                    maxNumber = numbers[i];
                }
            }

            this.PrintMax(maxNumber);

            double minNumber = double.MaxValue;
            for (int i = 0; i < numbersCount; i++)
            {
                if (numbers[i] < minNumber)
                {
                    minNumber = numbers[i];
                }
            }

            this.PrintMin(minNumber);

            double numbersSum = 0;
            for (int i = 0; i < numbersCount; i++)
            {
                numbersSum += numbers[i];
            }

            double linearAverageNumber = numbersSum / numbersCount;
            this.PrintAvg(linearAverageNumber);
        }

        public void PrintMax(double input)
        {
        }

        public void PrintMin(double input)
        { 
        }

        public void PrintAvg(double input)
        { 
        }
    }
}
