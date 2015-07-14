using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printers
{
    class GenericPrinter
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

            PrintMax(maxNumber);

            double minNumber = double.MaxValue;
            for (int i = 0; i < numbersCount; i++)
            {
                if (numbers[i] < minNumber)
                {
                    minNumber = numbers[i];
                }
            }

            PrintMin(minNumber);

            double numbersSum = 0;
            for (int i = 0; i < numbersCount; i++)
            {
                numbersSum += numbers[i];
            }

            double linearAverageNumber = numbersSum / numbersCount;
            PrintAvg(linearAverageNumber);
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
