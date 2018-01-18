using System;
//### Problem 02. Get largest number
//*	Write a method `GetMax()` with two parameters that returns the larger of two integers.
//*	Write a program that reads `3` integers from the console and prints the largest of them using the method `GetMax()`.
class Program
{
    static void Main()
    {
        int[] nums = new int[3];
        for (int i = 0; i < 3; i++)
        {
            Console.Write("Enter num[{0}] = ", i);
            nums[i] = int.Parse(Console.ReadLine());
        }

        int res = GetMax(GetMax(nums[0], nums[1]), nums[2]);
        Console.WriteLine("Max: " + res);
    }

    static int GetMax(int a, int b)
    {
        int max = a;
        max = (a > b) ? a : b;
        return max;
    }
}