using System;
//### Problem 09. Frequent number
//*	Write a program that finds the most frequent number in an array.

//_Example:_

//|                  input                |    result   |
//|---------------------------------------|-------------|
//| **4**, 1, 1, **4**, 2, 3, **4**, **4**, 1, 2, **4**, 9, 3 | 4 (5 times) |
class Program
{
    static void Main()
    {
        //first enter the array with spaces between different members
        Console.Write("Enter array members delimited by space: ");
        string[] arrStr = Console.ReadLine().Split(' ');
        
        //just a brute force check starting with the first member to the one before the last.
        int count = 0, maxCount = 0, resultMember = 0;
        for (int indx = 0; indx < arrStr.Length-1; indx++)  //start checking the first member
        {
            for (int nextIndx = indx; nextIndx < arrStr.Length; nextIndx++) //begin comparing with the rest members, including itself for correct count
            {
                if (arrStr[indx] == arrStr[nextIndx]) count++;  //increase counter if match
            }

            if (count > maxCount) { maxCount = count; resultMember = int.Parse(arrStr[indx]); } //if counter bigger than last biggest set new maximum
            count = 0;  //reset the counter for the next member check
        }

        Console.WriteLine("{0} ({1} times)",resultMember,maxCount);

    }
}

