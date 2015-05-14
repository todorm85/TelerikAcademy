using System;
////### Problem 09. Sorting array
////*	Write a method that return the maximal element in a portion of array of integers starting at given index.
////*	Using it write another method that sorts an array in ascending / descending order.
class Program
{
    static void Main()
    {
        Console.Write("Enter array (members delimited by space: ");
        string[] arrStr = Console.ReadLine().Split(' ');
        int[] ints = new int[arrStr.Length];
        for (int i = 0; i < arrStr.Length; i++)
        {
            ints[i] = int.Parse(arrStr[i]);
        }
        ////int[] ints = { 4, 5, 7, 32, 56, 3, 55, 7, 3, 1 };
        ArrSort(ints);
        for (int i = 0; i < ints.Length; i++)
        {
            Console.Write(ints[i] + " ");
        }
    }

    static int MaxElemIdxInArr(int[] arr, int idx)
    {
        if (idx == arr.Length - 1)
        {
            return idx;
        }

        int max = arr[idx];
        int maxIdx = idx;
        for (int i = idx + 1; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
                maxIdx = i;
            }
        }

        return maxIdx;
    }

    static void ArrSort(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            int maxIdx = MaxElemIdxInArr(arr, i);
            if (maxIdx != i)   // swap element at position i with element at maxidx, works only if it is not the same element
            {                
                arr[i] += arr[maxIdx];
                arr[maxIdx] = arr[i] - arr[maxIdx];
                arr[i] -= arr[maxIdx];
            }
        }
    }
}

