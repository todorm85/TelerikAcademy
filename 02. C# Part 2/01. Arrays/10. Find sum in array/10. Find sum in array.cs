using System;
//### Problem 10. Find sum in array
//*	Write a program that finds in given array of integers a sequence of given sum `S` (if present).

//_Example:_

//|        array            |  S |  result |
//|---------------------    |----|---------|
//| 4, 3, 1, **4, 2, 5**, 8 | 11 | 4, 2, 5 |
class Program
{
    static void Main()
    {
        //first enter the array with spaces between different members
        Console.Write("Enter array (members delimited by space: ");
        string[] arrStr = Console.ReadLine().Split(' ');
        int[] arr = new int[arrStr.Length];
        for (int i = 0; i < arrStr.Length; i++)
        {
            arr[i] = int.Parse(arrStr[i]);
        }
        //next enter sum S
        Console.Write("Enter sum (-2,147,483,648 to 2,147,483,647): ");
        int s = int.Parse(Console.ReadLine());
        //brute force check for every possible sequential sum
        int sum = 0;
        for (int startIndx = 0; startIndx < arr.Length - 1; startIndx++)
        {
            //int startPrintIdx = startIndx;
            for (int endIndx = startIndx; endIndx < arr.Length; endIndx++)
            {
                sum += arr[endIndx];    //begin calculating the sum from the startIndx inclusive

                if (sum == s)   //printing the result if any match is found
                {
                    for (int i = startIndx; i <= endIndx; i++)
                    {
                        Console.Write(arr[i] + " ");
                    }
                    startIndx = endIndx;
                    Console.WriteLine();
                    sum = arr[startIndx];    //resetting the counter to start checking the next sequence sum including starting one
                }

            }

            sum = 0;

        }

    }
}

