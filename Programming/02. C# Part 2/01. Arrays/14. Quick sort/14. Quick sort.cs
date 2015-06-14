using System;
//### Problem 14. Quick sort
//*	Write a program that sorts an array of strings using the [Quick sort](http://en.wikipedia.org/wiki/Quicksort) algorithm (find it in Wikipedia).
class Program
{
    static void Main()
    {
        // as it became clear in the forms we are supposed to sort integers not strings!!!!!!!!!!!!!!!!!!!!!!!
        Console.Write("Enter array (members delimited by space: ");
        string[] arrStr = Console.ReadLine().Split(' ');
        int[] arr = new int[arrStr.Length];
        for (int i = 0; i < arrStr.Length; i++)
        {
            arr[i] = int.Parse(arrStr[i]);
        }

        bool[] isSorted = new bool[arr.Length];
        bool isFinished = new bool();

        while (true)
        {
            int leftIdx = 0, rightIdx = arr.Length - 1, pivotIdx = 0, pivot = 0;

            for (int i = 0; i < arr.Length; i++)    //cycle to find first unsorted portion in array (marked with false)
            {
                if (!isSorted[i]) { leftIdx++; isFinished = true; }   //set the flag isFinished to true when first time condition is met, 
                //leftIdx is just a counter for unsorted positions in this case

                if ((isSorted[i] && isFinished) || (i == isSorted.Length - 1 && isFinished))  //if element i is sorted or we reached the end 
                    //and isFinsihed is true, then end cycle (we found our unsorted part)
                {
                    isFinished = false;                     //reset the flag because we use it in the global while cycle also.
                    leftIdx = (isSorted[i]) ? i - leftIdx : i - (leftIdx - 1);        //left start index is the current position minus all 
                    //previous unsorted positions if current is sorted, else we have to exclude the current also. This is needed because of 
                    //the case when we reached the end of the array
                    rightIdx = (isSorted[i]) ? i - 1 : i;   //right end index was the previous position if current is sorted, else is the 
                    //current.
                    break;
                }

                if (!isFinished && i == isSorted.Length - 1)    //if we reached the end of the array and haven`t met unsorted values break
                {
                    isFinished = true;  //mark isFinished to true, because we sorted all elements
                    break;  //exit this cycle
                }
            }

            if (isFinished) break; //if there are no more unsorted values exit global cycle
            if (rightIdx == leftIdx) { isSorted[leftIdx] = true; continue; }    //if single element unsorted sequential part left it is marked
            // as sorted

            pivotIdx = leftIdx + (rightIdx - leftIdx) / 2;  //pick pivot index in middle
            pivot = arr[pivotIdx];  //assign pivot value

            //next we sort the currently unsorted part
            while (leftIdx < rightIdx) //continue until left meets right at the pivot
            {
                while (arr[leftIdx] < pivot) leftIdx++; //continue until left has reached a pivot value or bigger

                while (arr[rightIdx] > pivot) rightIdx--; //continue until right has reached a pivot value or smaller

                if (leftIdx < rightIdx) //if the indexes haven`t met at the pivot yet
                {
                    //swap the left and right values
                    arr[leftIdx] += arr[rightIdx];
                    arr[rightIdx] = arr[leftIdx] - arr[rightIdx];
                    arr[leftIdx] -= arr[rightIdx];

                    if (leftIdx == pivotIdx) { pivotIdx = rightIdx; leftIdx++; }    //if left reached pivot index in preceeding while since we
                        // swap it with right, the new pivot position is the right index. Now we need to increment only leftIdx in case it is
                    //also equal to the pivot value (we have repeating elements). Because if we don`t do it we`ll get into an endless loop 
                    //since the current right will continue swapping with pivot indefinitely and left and right index will never meet.
                    else if (rightIdx == pivotIdx) { pivotIdx = leftIdx; rightIdx--; }  //if right reached pivot index in preceeding while 
                    //since we swap it with left, the new pivot position is left index and we only need to increment right index

                }
            }

            isSorted[pivotIdx] = true;  //mark current pivot as sorted

        }

        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
    }
}

