using System;

////### Problem 04. Binary search
////*Write a program, that reads from the console an array of `N` integers and an integer `K`, sorts the array and using the method `Array.BinSearch()` finds the largest number in the array which is <= `K`. 
class BinarySearch
{
    static void Main()
    {
        // YOUR INPUT HERE!!!!!!!!!!!!!!!!
        int[] arr = 
        {
            4, 21, 8, 3, 85, 55, 9, 15 
        };
        int n = arr.Length;
        int k = 20;

        Array.Sort(arr);

        int result = -1;

        // start checking from k until we find a match (returned index >= 0), or we reached minimum posssible value for int
        while (result < 0)
        {
            result = Array.BinarySearch(arr, k);
            if (k == int.MinValue) break;
            k--;

        }
        
        Console.WriteLine("Number is {0}", arr[result]);
    }
}