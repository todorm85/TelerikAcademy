namespace StudentSystem
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
            return rand.Next(min,max);
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
    }
}
