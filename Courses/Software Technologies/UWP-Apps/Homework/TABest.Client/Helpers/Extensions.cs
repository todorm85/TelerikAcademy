namespace TABest.Client.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> c, Action<T> a)
        {
            foreach (var i in c)
            {
                a(i);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> c, Action<T, int> a)
        {
            int index = 0;
            foreach (var i in c)
            {
                a(i, index++);
            }
        }
    }
}