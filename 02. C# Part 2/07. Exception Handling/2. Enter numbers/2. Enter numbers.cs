using System;
//### Problem 2. Enter numbers
//*	Write a method `ReadNumber(int start, int end)` that enters an integer number in a given range [`start...end`].
//    *	If an invalid number or non-number text is entered, the method should throw an exception.
//*	Using this method write a program that enters `10` numbers:	`a1, a2, ... a10`, such that `1 < a1 < ... < a10 < 100`
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter 10 numbers between 1 and 100, that are consequtively increasing!");
        int[] nums = new int[10];
        int start = 1;
        int end = 100;
        for (int i = 0; i < 10; i++)
        {
            Console.Write("Enter number {0}: ", i);
            nums[i] = ReadNumber(start, end);
            start = nums[i];
        }
    }

    private static int ReadNumber(int start, int end)
    {
        try
        {
            int num = int.Parse(Console.ReadLine());
            if (num<=start || num >= end)
            {
                throw new ArgumentOutOfRangeException();
            }

            return num;
        }

        catch (Exception)
        {
            throw new Exception("Invalid Number");
        }
    }
}

