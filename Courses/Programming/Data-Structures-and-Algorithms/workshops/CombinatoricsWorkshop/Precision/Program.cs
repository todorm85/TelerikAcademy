namespace Precision
{
    using System;
    using System.IO;

    internal class Precision
    {
        static int Precision2(string fraction, int a, int b)
        {
            a *= 10;
            int i = 0;
            for (i = 0; i < fraction.Length; i++)
            {
                int digit = a / b;
                if (digit != fraction[i] - '0')
                {
                    break;
                }

                a = (a % b) * 10;
            }

            return i;
        }

        static bool Compare(string fraction, int a, int b)
        {
            a *= 10;
            int i = 0;
            for (i = 0; i < fraction.Length; i++)
            {
                int digit = a / b;
                if (digit < fraction[i] - '0')
                {
                    return false;
                }
                else if (digit > fraction[i] - '0')
                {
                    return true;
                }

                a = (a % b) * 10;
            }

            return true;
        }

        private static void Main()
        {
            //GetSampleInput();
            int maxDenominator = int.Parse(Console.ReadLine());
            var fraction = Console.ReadLine().Split('.')[1];

            int bestNom = 0;
            int bestDen = 1;
            int precision = 0;
            for (int den = 1; den <= maxDenominator; den++)
            {
                int left = 0;
                int right = den;

                while (left < right)
                {
                    int mid = (left + right) / 2;
                    if(Compare(fraction, mid, den))
                    {
                        right = mid;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }

                int current = Precision2(fraction, left-1, den);
                {
                    if (current > precision)
                    {
                        bestDen = den;
                        bestNom = left - 1;
                        precision = current;
                    }
                }

                current = Precision2(fraction, left, den);
                {
                    if (current > precision)
                    {
                        bestDen = den;
                        bestNom = left;
                        precision = current;
                    }
                }
            }

            Console.WriteLine("{0}/{1}", bestNom, bestDen);
            Console.WriteLine(precision + 1);
        }

        private static void GetSampleInput()
        {
            // 1/7
            // 3
            var input1 = @"42
0.141592658";
            var input2 = @"42
0.141592658";
            var input3 = @"42
0.141592658";
            var input4 = @"42
0.141592658";
            var input5 = @"42
0.141592658";
            var input6 = @"42
0.141592658";

            var reader = new StringReader(input1);
            Console.SetIn(reader);
        }
    }
}