using System;
//### Problem 4.  Appearance count
//*	Write a method that counts how many times given number appears in given array.
//*	Write a test program to check if the method is workings correctly.
class Program
{
    static void Main()
    {
        Console.Write("Enter number: ");
        int num = int.Parse(Console.ReadLine());
        Console.Write("Enter array (members delimited by space: ");
        string[] arrStr = Console.ReadLine().Split(' ');
        int[] arr = new int[arrStr.Length];
        for (int i = 0; i < arrStr.Length; i++)
        {
            arr[i] = int.Parse(arrStr[i]);
        }

        int count = CountNumInArr(num, arr);
        Console.WriteLine("Number {0} is found {1} times", num, count);
        Console.WriteLine();
        if (test())
            Console.WriteLine("Test is success");
        else
            Console.WriteLine("Test failed");
    }

    static int CountNumInArr(int num, int[] collection)
    {
        int count = 0;
        foreach (var item in collection)
        {
            if (item == num)
            {
                count++;
            }
        }

        return count;
    }

    static bool test ()
    {
        int answer = CountNumInArr(1, new int[] { 1, 4, 3, 1, 5 });
        if (answer == 2)
            return true;
        else
            return false;
    }
}