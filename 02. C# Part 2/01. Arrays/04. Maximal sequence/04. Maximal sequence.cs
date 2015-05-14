using System;
//### Problem 4. Maximal sequence 
//*	Write a program that finds the **maximal sequence** of equal elements in an array.

//_Example:_

//|              input              | result  |
//|---------------------------------|---------|
//| 2, 1, 1, 2, 3, 3, **2, 2, 2**, 1 | 2, 2, 2 |
class Program
{
    static void Main()
    {
        //I made this task more complex. This algorithm checks for maximum number of sequential repeating elements and prints all of them. It finds all of them even if there are more than one elements that are repeated equal times. For example: 1 1 2 2 5 will return 1 1 on firs line and 2 2 on second. Because they are both maximum sequence of repeating elements.
        Console.Write("Enter integer array length (numbers delimited by space: ");
        string[] arr1Str = Console.ReadLine().Split(' '); //this is the string array for the input
        string[] result = new string[arr1Str.Length];   //this is the array that will store the resulting elements that are repeated the most

        int resultIndex = 0;
        int maxCount = 0;
        int count = 0;

        for (int index = 0; index < arr1Str.Length - 1; index++)    //we start the check sequentially
        {
            if (arr1Str[index] == arr1Str[index + 1])   //compare the first with next
            {
                if (index != arr1Str.Length - 2) { count++; continue; } //if they are equal move on to next string member in the cycle and increase counter
                else count++;   //if we have reached the last element, then increase counter and move on to compare the length of the last sequence of string members to the length of the previous longest before exiting the cycle
            }
            //compare the length of the current sequence of string members to previous longest sequence
            if (count == maxCount)     //if the current sequence is equal in length to the previous longest sequence
            {
                resultIndex++;  //increase the index for the resulting array
                result[resultIndex] = arr1Str[index]; //write the current string member to the next member of the resulting array
                count = 0; //reset the string repetition counter
            }
            
            else if (count > maxCount)  //if the current sequence length is longer than the length of the last longest sequence
            {
                maxCount = count;   //set the length of the new longest sequence
                result = new string[arr1Str.Length];    //reset the resulting string array to write the new longest results strings
                resultIndex = 0;    //start writing results from the beginning of the new array
                result[resultIndex] = arr1Str[index];   //write the current string member that is repeated the most to the first member
                count = 0; //reset sequence repetition counter
            }
            else //if we don`t have a bigger or equal in length sequential repetition of elements just reset the repetition counter
            {
                count = 0;
            }
           
        }


        if (maxCount == 0) Console.WriteLine("No reapeating elements");   //if we didn`t have at least one repetition then we don`t have repeating elements

        if (maxCount > 0)   //if we had at least one repetition then the maxCount will be bigger than 0
        {
            for (int i = 0; i <= resultIndex; i++)  //we will print all the different string members that were found to be with the maximum repetition, their total number is resultIndex and they are repeated maxCount+1 times sequentially in the array
            {
                for (int j = 0; j < maxCount + 1; j++)
                {
                    Console.Write(result[i] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

