namespace _01_Count_occurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Startup
    {
        private static void Main()
        {
            var arr = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            var valuesCount = new Dictionary<double, int>();
            foreach (var item in arr)
            {
                if (!valuesCount.Keys.Contains(item))
                {
                    valuesCount.Add(item, 0);
                }

                valuesCount[item]++;
            }

            foreach (var key in valuesCount.Keys)
            {
                Console.WriteLine($"{key} -> {valuesCount[key]}");
            }
        }
    }
}
