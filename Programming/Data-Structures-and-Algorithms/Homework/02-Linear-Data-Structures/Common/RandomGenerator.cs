namespace Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RandomGenerator : IRandomGenerator
    {
        private static Random rand = new Random();

        public int GetRandomInteger(int min = int.MinValue, int max = int.MaxValue)
        {
            return rand.Next(min, max);
        }

        public string GetRandomString(int minLen = 5, int maxLen = 10)
        {
            int stringLen = GetRandomInteger(minLen, maxLen);
            string word = "";

            for (int i = 0; i < stringLen; i++)
            {
                var asciiIndex = GetRandomInteger(97, 122);
                var letter = (char)asciiIndex;
                word += letter;
            }

            return word;
        }

        public DateTime GetRandomDate(DateTime minDate, DateTime maxDate)
        {
            TimeSpan timeDifference = maxDate - minDate;
            int daysDifference = timeDifference.Days;

            int randomDaysToAdd = GetRandomInteger(0, daysDifference);
            TimeSpan randomTimeToAdd = new TimeSpan(randomDaysToAdd, 0, 0, 0);

            DateTime randomDate = minDate + randomTimeToAdd;
            return randomDate;
        }

        public List<T> GetRandomNumbersList<T>(int length)
            where T : IConvertible
        {
            var thisType = default(T);
            var typeCode = thisType.GetTypeCode();

            List<T> numbers = new List<T>();
            for (int i = 0; i < length; i++)
            {
                double randomDouble = this.GetRandomInteger(-100, 100) / this.GetRandomInteger(1, 5);
                switch (typeCode)
                {
                    case TypeCode.Int16:
                    case TypeCode.Int32:
                    case TypeCode.Int64:
                        var randomInt = Convert.ToInt16(randomDouble);
                        numbers.Add((T)Convert.ChangeType(randomInt, typeCode));
                        break;

                    case TypeCode.UInt16:
                    case TypeCode.UInt32:
                    case TypeCode.UInt64:
                        randomDouble = this.GetRandomInteger(0, 100) / this.GetRandomInteger(1, 5);
                        var randomUInt = Convert.ToUInt16(randomDouble);
                        numbers.Add((T)Convert.ChangeType(randomUInt, typeCode));
                        break;

                    case TypeCode.Double:
                        numbers.Add((T)Convert.ChangeType(randomDouble, typeCode));
                        break;

                    default:
                        throw new ArgumentException("Unsupported generic type.");
                }
            }

            return numbers;
        }
    }
}
