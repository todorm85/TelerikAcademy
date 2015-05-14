using System;

////### Problem 05. Larger than neighbours
////*Write a method that checks if the element at given position in given array of integers is larger than its two neighbours (when such exist).
class Program
{
    static void Main()
    {
        // YOU CAN CHANGE INPUT HERE
        int[] integers = { 1, 5, 25, 55, 3, 56, 3, 2, 4 };
        Console.Write("Enter element position: ");
        int index = int.Parse(Console.ReadLine());
        if (index < 1 || index >= integers.Length - 1)
        {
            Console.WriteLine("Invalid Input");
            return;
        }

        bool result = LargerThanNeighbrs(index, integers);
        Console.WriteLine("Element is larger than neighbours: " + result);
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
}