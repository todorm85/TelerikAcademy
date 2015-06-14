using System;
//### Problem 08. Maximal sum
//*	Write a program that finds the sequence of maximal sum in given array.

//_Example:_

//|                 input               |    result   |
//|-------------------------------------|-------------|
//| 2, 3, -6, -1, **2, -1, 6, 4**, -8, 8 | 2, -1, 6, 4 |

//*	_Can you do it with only one loop (with single scan through the elements of the array)?_
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

        //next cycle finds the start and end index of the max sum.
        int sum = 0, maxSum = int.MinValue, start = 0, bestStart = 0, end = 0;
        for (int indx = 0; indx < arr.Length; indx++)
        {
            if (sum <= 0)   //if previous cycle`s current sum was less than or equal to zero, then restart calculating it from the current indx member. This is true because no matter the next number, the current sum will either be smaller if next num is negative or it wouldn`t be bigger than the next number if it is positive. The next positive number alone will be bigger than the current sum, so we just need to restart calculating it.
            {
                start = indx;   //set the new sequence start indx from the current member
                sum = 0;    //restart the sum to start calculating it again from the current indx member
            }

            sum += arr[indx];   //calculates current sum, up to the current indx member inclusive

            if (sum > maxSum)   //if this cycles current sum is bigger than previous maxSum
            {
                maxSum = sum;   //set the new maxSUm
                bestStart = start;  //set the bestStart to current sum sequence start 
                end = indx; //set the end to the current num indx
            }
            
        }

        Console.WriteLine("Max sum: {0}", maxSum);
        Console.WriteLine("Sequence start = {0}, sequence end: {1}", bestStart, end);

    }
}

