namespace Common
{
    using System;
    using System.Collections.Generic;

    public interface IRandomGenerator
    {
        int GetRandomInteger(int min = int.MinValue, int max = int.MaxValue);

        string GetRandomString(int minLen = 5, int maxLen = 10);

        DateTime GetRandomDate(DateTime minDate, DateTime maxDate);

        List<T> GetRandomNumbersList<T>(int length)
            where T : IConvertible;
    }
}