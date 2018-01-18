using System;
//### Problem 11. Binary search
//*	Write a program that finds the index of given element in a sorted array of integers by using the [Binary search](http://en.wikipedia.org/wiki/Binary_search_algorithm) algorithm.
class Program
{
    static void Main()
    {
        Console.Write("Enter array (members delimited by space: ");
        string[] arrStr = Console.ReadLine().Split(' ');
        int[] arr = new int[arrStr.Length];
        for (int i = 0; i < arrStr.Length; i++)
        {
            arr[i] = int.Parse(arrStr[i]);
        }

        Array.Sort(arr);

        Console.WriteLine("Sorted array:");
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        Console.Write("Enter integer to search for: ");
        int num = int.Parse(Console.ReadLine());

        int startIndx = 0, endIndx = arr.Length - 1;

        while ((endIndx - startIndx) > 1)
        {
            int indx = startIndx + (endIndx - startIndx) / 2;

            if (arr[indx] == num) { Console.WriteLine("{0} is at position {1}",num,indx); return; }
            else if (arr[indx] > num) endIndx = indx;
            else if (arr[indx] < num) startIndx = indx;

        }

        Console.WriteLine("Not found!");
    }
}

