using System;
//### Problem 16. Subset with sum S
//*	We are given an array of integers and a number `S`.
//*	Write a program to find if there exists a subset of the elements of the array that has a sum `S`.

//_Example:_

//|       input array      | S  |     result    |
//|:----------------------:|:--:|:-------------:|
//| 2, **1**, **2**, 4, 3, **5**, 2, **6** | 14 | yes |
class Program
{
    static void Main()
    {
        // THIS PROGRAM PRINTS ALL POSSIBLE COMBINATIONS OF ELEMENTS THAT HAS SUM S !!! not just the first met
        // I take out all possible combinations 
        //of k elements (1 to n) from all elements, using the algorithm in Problem 21.
        //The algorithm there makes combinations without repetition of k numbers from 1 to N possible numbers.
        //Then I use this number combinations to generate combinations of array`s indexes.
        //This results in finding all possible combinations of the array`s elements.
        //Then each possible combo is checked for the condition.

        //IMPORTANT     IMPORTANT     IMPORTANT      IMPORTANT      IMPORTANT      IMPORTANT      IMPORTANT 

        //Since this is a brute force method the program may take very long time to calculate the result.
        //I consider the problem solved, since we have no time or memory limit. I know it is not the best, but it is
        //the first I could think of with my limited time available. With each additional member the time increases exponentially.

        //     IMPORTANT      IMPORTANT      IMPORTANT      IMPORTANT      IMPORTANT      IMPORTANT      IMPORTANT

        //all possible combinations of 2 to n numbers from n numbers are checked for the condition
        int[] arr = { 2, 1, 2, 4, 3, 5, 2, 6};  // YOUR INPUT HERE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        int s = 14;
        int n = arr.Length;

        for (int k = 2; k <= n; k++)
        {
            //start brute forcing with algorithm from Problem 21
            bool[] mask = new bool[arr.Length]; //reset mask for new combination

            //set a k digit array
            int[] digit = new int[k];

            //set initial digits to 1, except the k digit
            for (int i = 0; i < k - 1; i++)
                digit[i] = 1;

            //start printing
            bool finish = false;
            while (!finish)
            {
                //start digit incremention from last digit(element). Basically this generates all possible variations with repetition K from N
                for (int i = k - 1; i >= 0; i--)
                {
                    //increment digit
                    digit[i]++;

                    //if after incremention bigger than N
                    if (digit[i] > n)
                    {
                        //reset to 1 and move on to next previous
                        digit[i] = 1;
                    }
                    else break;

                }

                //check if every digit is always bigger and not equal than those that are to the left. This will sort combinations without repetition from variations (variations include combinations). If you want combinations with repetitions just remove the equals conditions and leave bigger than.
                bool allLeftSmaller = true;
                for (int i = 0; i < k - 1; i++)
                {
                    for (int ii = i + 1; ii < k; ii++)
                    {
                        if (digit[i] >= digit[ii]) allLeftSmaller = false;
                    }
                }

                //THIS IS THE BEGINNING OF THE MODIFICATION!!!!!!!!!
                //get only combinations from variations
                if (allLeftSmaller)
                {
                    for (int i = 0; i < k; i++)
                        mask[digit[i] - 1] = true;  //digit[i]-1 because we want indexes. n is from 1 to arr.Lenght!

                    //next check whether this combo equals sum S
                    int sum = 0;
                    for (int i = 0; i < n; i++)
                    {
                        if (mask[i]) sum += arr[i];
                    }
                    //if current sum equals what we search for
                    if (sum == s)
                    {
                        //print the numbers
                        for (int i = 0; i < n; i++)
                        {
                            if (mask[i]) Console.Write(arr[i] + " ");
                        }
                        Console.WriteLine();
                    }
                    mask = new bool[arr.Length]; //reset mask for next combination

                }
                //THIS IS THE END OF THE MODIFICATION!!!!!!!!!

                //cycle to check if we have reached the max possible values of all digits. This is the last Variation.
                for (int i = 0; i < k; i++)
                {
                    //if at least one is not max we stop the check and continue with next variation
                    if (digit[i] != n) { finish = false; break; }
                    else finish = true;
                }
            }
        }

    }
}

