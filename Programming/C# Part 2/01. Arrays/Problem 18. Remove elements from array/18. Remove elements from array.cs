using System;
//### Problem 18.* Remove elements from array
//*	Write a program that reads an array of integers and removes from it a minimal number of elements in such a way that the remaining array is sorted in increasing order.
//*	Print the remaining sorted array.

//_Example:_

//|           input           |     result    |
//|:-------------------------:|:-------------:|
//| 6, **1**, 4, **3**, 0, **3**, 6, **4**, **5** | 1, 3, 3, 4, 5 |
class Program
{
    static void Main()
    {
        // I take out all possible combinations 
        //of k elements (1 to n) from all elements, using the algorithm in Problem 21.
        //The algorithm there makes combinations without repetition of k numbers from 1 to N numbers
        //I will use this combinations as indexes of a boolean array - mask.
        //Then I check the initial array arr members using mask true values for the condition of sequential increase and pick the longest.

        //IMPORTANT     IMPORTANT     IMPORTANT      IMPORTANT      IMPORTANT      IMPORTANT      IMPORTANT 

        //Since this is a brute force method the program may take very long time to calculate the result.
        //Particularly to calculate the example it takes about 4-5 min on my AMD Athlon II Neo K325 1.3Ghz mobile processor
        //I consider the problem solved, since we have no time or memory limit. I know it is not the best, but it is
        //the first I could think of with my limited time available. The program is fast with 7 or less members.
        //Then the time increases exponentially.

        //     IMPORTANT      IMPORTANT      IMPORTANT      IMPORTANT      IMPORTANT      IMPORTANT      IMPORTANT 

        //int[] arr = { 6, 1, 4, 3, 0, 3, 6, 4, 5 };
        int[] arr = { 6, 1, 4, 3, 0, 3, 6, 4, 5 }; // YOUR INPUT HERE !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        bool[] resultMask = new bool[arr.Length];   // WAIT 3-5 MINUTES PLEASE!!!


        int n = arr.Length;
        int maxCount = 0;

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
                //get the combo
                if (allLeftSmaller)
                {
                    for (int i = 0; i < k; i++)
                        mask[digit[i] - 1] = true;

                    //next check for sequential increase
                    int max = int.MinValue;
                    int count = 0;
                    bool isIncrease = true;
                    for (int i = 0; i < n; i++)
                    {
                        if (mask[i])
                        {
                            count++;
                            if (arr[i] >= max) { max = arr[i]; }
                            else isIncrease = false;
                        }
                    }
                    //if we have sequential increase check if it is the longest so far
                    if (isIncrease)
                    {
                        if (count >= maxCount)
                        {
                            maxCount = count;
                            resultMask = (bool[])mask.Clone();
                        }

                    }
                    mask = new bool[arr.Length]; //reset mask for new combination

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

        for (int i = 0; i < n; i++)
        {
            if (resultMask[i])
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}

