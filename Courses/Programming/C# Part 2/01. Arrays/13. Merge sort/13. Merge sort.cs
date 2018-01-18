using System;
//### Problem 13.*  Merge sort
//*	Write a program that sorts an array of integers using the [Merge sort](http://en.wikipedia.org/wiki/Merge_sort) algorithm (find it in Wikipedia).
class Program
{
    static void Main()
    {
        //Enter YOUR INPUT HERE !!!!!!!!!!!!!!!!
        int[] arr = { 19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1};
        int L = arr.Length;
        int m = L / 2;
        int[] left = new int[L];
        int[] right = new int[L];

        Console.WriteLine("Unsorted array:");
        foreach (var item in arr)
        {
            Console.Write("{0} ", item);
        }
        Console.WriteLine("\n");

        // we start from lowest subdivision length (step = 1)
        // then we merge those 1 member pairs
        // then continue to next subdivision which is two time previous  (step = 2*1 = 2)
        // merge those pairs of 2 members and continue to next subdivision (step = 2*2=4)
        // continue until we reach the max possible subpart length and merge it with remaining right part.
        // the remaining right part will be sorted because it would have gone through all possible 
        // subpart levels merging up to the current part length
        for (int step = 1; step < L; step *= 2)
        {
            int stepBase = 0;
            while (stepBase < L - step)
            {
                // extract left and right subdivisions with length step into left and right arrays starting from beginning
                left = new int[step];
                for (int j = stepBase, i = 0; j < stepBase + step; j++, i++)
                {
                    left[i] = arr[j];
                }

                int max = 0;
                right = new int[step];

                // next if is neccessary to check whether remaining elements are less than current subdivision
                // and get only them, otherwise we`ll get exception for index out of range
                if (stepBase + 2 * step >= L)
                {
                    max = L;
                    right = new int[L - (stepBase + step)];
                }
                else
                {
                    max = stepBase + 2 * step;  // because right subdivision index starts one step from current left subdivision( stepBase + step) and it finishes at one more step away to the right ( stepbase + step + step)
                }

                for (int k = stepBase + step, i = 0; k < max; k++, i++)
                {
                    right[i] = arr[k];
                }

                // merge left and right subparts
                int[] merged = new int[left.Length + right.Length];
                bool[] maskRight = new bool[right.Length];
                bool[] maskLeft = new bool[left.Length];
                int mergedIdx = 0;
                for (int i = 0; i < left.Length; i++)
                {
                    for (int j = 0; j < right.Length; j++)
                    {
                        if (left[i] > right[j])
                        {
                            if (maskRight[j] == false)
                            {
                                merged[mergedIdx] = right[j];
                                maskRight[j] = true;
                                mergedIdx++;
                            }
                        }
                        else
                        {
                            merged[mergedIdx] = left[i];
                            maskLeft[i] = true;
                            mergedIdx++;
                            break;
                        }
                    }

                }

                for (int i = 0; i < left.Length; i++)
                {
                    if (!maskLeft[i])
                    {
                        merged[mergedIdx] = left[i];
                        mergedIdx++;
                    }
                }

                for (int i = 0; i < right.Length; i++)
                {
                    if (!maskRight[i])
                    {
                        merged[mergedIdx] = right[i];
                        mergedIdx++;
                    }
                }

                // assign merged back to arr
                for (int i = 0; i < merged.Length; i++)
                {
                    arr[stepBase + i] = merged[i];
                }
                                
                // go to next pair
                stepBase += 2 * step;
            }

            // current subdivision merge print after all pairs of current subparts step(length) have been merged
            if (step == 1)
            Console.WriteLine("After merging pairs with {0} elements each:", step);
            else
                Console.WriteLine("After merging pairs with {0} or less than {0} elements (remaining right subparts at the end)", step);
            foreach (var item in arr)
            {
                Console.Write("{0} ", item);
            }

            Console.WriteLine("\n");
        }

        //finally after merging all possible subdivision parts print the array
        Console.WriteLine("Sorted array:");
        foreach (var item in arr)
        {
            Console.Write("{0} ", item);
        }
        Console.WriteLine();
    }
}

