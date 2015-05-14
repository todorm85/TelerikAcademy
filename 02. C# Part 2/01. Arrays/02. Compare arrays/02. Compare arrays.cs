using System;

//### Problem 2. Compare arrays
//*	Write a program that reads two `integer` arrays from the console and compares them element by element.

class Program
{
    static void Main()
    {

        Console.Write("Enter integer array 1 (numbers delimited by space: ");
        string[] arr1Str = Console.ReadLine().Split(' ');

        int[] arr1 = new int[arr1Str.Length];
        for (int i = 0; i < arr1Str.Length; i++)
        {
            arr1[i] = int.Parse(arr1Str[i]);
        }

        Console.Write("Enter integer array 2 (numbers delimited by space: ");
        string[] arr2Str = Console.ReadLine().Split(' ');

        int[] arr2 = new int[arr2Str.Length];
        for (int i = 0; i < arr2Str.Length; i++)
        {
            arr2[i] = int.Parse(arr2Str[i]);
        }

        for (int i = 0; i < arr1.Length && i < arr2.Length; i++)    //checks whether first or second array has run out of elements and stops
        {
            char result = ' ';

            if (arr1[i] > arr2[i]) result = '>';
            else if (arr1[i] < arr2[i]) result = '<';
            else result = '=';

            Console.WriteLine("arr1[{0}] {1} arr2[{0}]", i, result);
        }
    }
}

