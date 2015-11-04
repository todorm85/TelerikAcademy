using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class Extensions
    {
        public static void ForEach<T>(this T[] arr, Action<T> callback)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                callback(arr[i]);
            }
        }

        public static void ForEach<T1, T2>(this T1[] arr, Action<T1, T2> callback, T2 callbackParam)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                callback(arr[i], callbackParam);
            }
        }

        public static TRes[] ForEach<T, TRes>(this T[] arr, Func<T, TRes> callback)
        {
            List<TRes> result = new List<TRes>();

            for (int i = 0; i < arr.Length; i++)
            {
                result.Add(callback(arr[i]));
            }

            return result.ToArray();
        }
    }
}
