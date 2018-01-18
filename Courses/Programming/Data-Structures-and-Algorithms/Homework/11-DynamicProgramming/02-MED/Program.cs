/* Write a program to calculate the "Minimum Edit Distance" (MED) between two words.
MED(x, y) is the minimal sum of costs of edit operations used to transform x to y.

Sample costs:
cost (replace a letter) = 1
cost(delete a letter) = 0.9
cost(insert a letter) = 0.8
Example:
x = "developer", y = "enveloped" → cost = 2.7
delete ‘d’: "developer" → "eveloper", cost = 0.9
insert ‘n’: "eveloper" → "enveloper", cost = 0.8
replace ‘r’ → ‘d’: "enveloper" → "enveloped", cost = 1 */

// USED REFERENCE FOR SOLUTION: https://web.stanford.edu/class/cs124/lec/med.pdf

namespace _02_MED
{
    using System;

    internal class Program
    {
        private static void Main()
        {
            var source = "developer";
            var target = "enveloped";

            var srcLen = source.Length;
            var tgLen = target.Length;

            // med[i, j] is the MED for subsource {0:i-1} and subtarget {0:j-1}, because
            // strings are zero based - letters are accessed starting with index 0. In med
            // letters will be referenced starting from 1. The zero based index is
            // reserved for the case "no letters"
            var med = new double[srcLen + 1, tgLen + 1];

            // operation costs
            var ins = .8;
            var del = .9;
            var rep = 1;

            // when source is empty we only have insert operations to reach the target
            for (int j = 1; j <= tgLen; j++)
            {
                med[0, j] = med[0, j - 1] + ins;
            }

            // when target is empty we only have delete operations to reach the target
            for (int i = 1; i <= srcLen; i++)
            {
                med[i, 0] = med[i - 1, 0] + del;
            }

            for (int i = 1; i <= srcLen; i++)
            {
                for (int j = 1; j <= tgLen; j++)
                {
                    var delCost = med[i - 1, j] + del;
                    var insCost = med[i, j - 1] + ins;
                    double subCost;
                    if (source[i - 1] != target[j - 1])
                    {
                        subCost = med[i - 1, j - 1] + rep;
                    }
                    else
                    {
                        subCost = med[i - 1, j - 1];
                    }

                    med[i, j] = Min(delCost, insCost, subCost);
                }
            }

            Console.WriteLine($"MED = {med[srcLen, tgLen]}");
        }

        // doubles have intrinsic errors in accuracy that may create problems when we want
        // to compare results of different computations with them, but since we don`t have
        // any operations with very large or very small numbers we can ignore this,
        // because these errors are accumulated in the last least significant digits in
        // the fraction part ex. 0.3 and 0.30000000001. BUT if we were to have costs like
        // var ins = .0000000000008; var del = .0000000000009; var rep = 1; we would have
        // had problems, because these numbers would be represented very inaccurately in
        // double (floating-point format)!
        private static double Min(double delCost, double insCost, double subCost)
        {
            double min = delCost;

            if (insCost < min)
            {
                min = insCost;
            }

            if (subCost < min)
            {
                min = subCost;
            }

            return min;
        }
    }
}