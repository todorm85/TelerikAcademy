namespace Common
{
    using System;

    public class RandomGenerator
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
    }
}
