using System;
////### Problem 06. First larger than neighbours
////*	Write a method that returns the index of the first element in array that is larger than its neighbours, or `-1`, if there�s no such element.
////*	Use the method from the previous exercise.
class Program
{
    static void Main()
    {
        int[] integers = { 1, 5, 25, 55, 3, 56, 3, 2, 4 };
        int result = FirstLargerThanNeighbours(integers);
        Console.WriteLine("Index of first element larger than neighbours is " + result);
    }

    static bool LargerThanNeighbrs(int idx, int[] collection)
    {
        if (collection[idx] > collection[idx - 1] && collection[idx] > collection[idx + 1])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static int FirstLargerThanNeighbours(int[] arr)
    {
        for (int i = 1; i < arr.Length-1; i++)
        {
            if (LargerThanNeighbrs(i, arr)) return i;
        }
        return -1;
    }
}

