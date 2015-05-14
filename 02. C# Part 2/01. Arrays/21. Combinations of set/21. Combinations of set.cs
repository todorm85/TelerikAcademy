using System;
//### Problem 21. Combinations of set
//*	Write a program that reads two numbers `N` and `K` and generates all the combinations of `K` distinct elements from the set [`1..N`].

//_Example:_

//| N | K |                                          result                                           |
//|:-:|:-:|:-----------------------------------------------------------------------------------------:|
//| 5 | 2 | `{1, 2}` <br> `{1, 3}` <br> `{1, 4}` <br> `{1, 5}` <br> `{2, 3}` <br> `{2, 4}` <br> `{2, 5}` <br> `{3, 4}` <br> `{3, 5}` <br> `{4, 5}` |
class Combinations
{
    static void Main()
    {
        //I will modify the algorithm from Problem 20 to get only the combinations from all the variations.
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter K: ");
        int k = int.Parse(Console.ReadLine());

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

            //cycle to print digits if every digit is always bigger than those that are to the left.
            if (allLeftSmaller)
            {
                for (int i = 0; i < k; i++)
                    Console.Write(digit[i]);
                Console.WriteLine();

            }

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

