namespace Songs
{
    using System;
    using System.Linq;
    using System.IO;

    internal class Program
    {
        static long CountInversions(int[] arr, int left, int right)
        {
            if (left + 1 == right)
            {
                return 0;
            }

            int middle = (left + right) / 2;

            long inversions = CountInversions(arr, left, middle) + CountInversions(arr, middle, right);

            int[] sorted = new int[right - left];
            int i = left;
            int j = middle;
            int k = 0;
            while (i < middle && j < right)
            {
                if (arr[i] < arr[j])
                {
                    sorted[k] = arr[i];
                    i++;
                }
                else
                {
                    sorted[k] = arr[j];
                    inversions += middle - i;
                    j++;
                }

                k++;
            }

            while (i < middle)
            {
                sorted[k] = arr[i];
                i++;
                k++;
            }

            while (j < right)
            {
                sorted[k] = arr[j];
                j++;
                k++;
            }

            for (int n = 0; n < sorted.Length; n++)
            {
                arr[left + n] = sorted[n];
            }

            return inversions;
        }

        private static void Main(string[] args)
        {
            //GetSampleInput();

            var n = int.Parse(Console.ReadLine());

            var arr1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var arr2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var rename = new int[n + 1];
            for (int i = 0; i < n; i++)
            {
                rename[arr1[i]] = i;
            }

            for (int i = 0; i < n; i++)
            {
                arr2[i] = rename[arr2[i]];
            }

            var inversions = 0L;

            inversions = CountInversions(arr2, 0, arr2.Length);

            Console.WriteLine(inversions);
        }

        private static void GetSampleInput()
        {
            // 3
            var input1 = @"3
3 2 1
1 2 3
"; // 3
            // 4
            var input2 = @"5
3 1 2 5 4
5 3 2 1 4
";

            // 9
            var input3 = @"6
6 2 3 4 5 1
1 2 3 4 5 6
";

            var reader = new StringReader(input3);
            Console.SetIn(reader);
        }
    }
}