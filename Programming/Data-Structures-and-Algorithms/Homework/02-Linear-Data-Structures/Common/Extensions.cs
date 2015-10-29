using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Extensions
    {
        public static T PopMin<T>(this List<T> numbers)
            where T : IComparable
        {
            T min = numbers[0];
            foreach (T currentNumber in numbers)
            {
                if (currentNumber.CompareTo(min) < 0)
                {
                    min = currentNumber;
                }
            }

            numbers.Remove(min);
            return min;
        }
    }
}
