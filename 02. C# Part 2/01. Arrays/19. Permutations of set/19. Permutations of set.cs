using System;
//### Problem 19.* Permutations of set
//*	Write a program that reads a number `N` and generates and prints all the permutations of the numbers [`1 � N`].

//_Example:_

//| N |                                  result                                 |
//|:-:|:-----------------------------------------------------------------------:|
//| 3 | `{1, 2, 3}` <br> `{1, 3, 2}` <br> `{2, 1, 3}` <br> `{2, 3, 1}` <br> `{3, 1, 2}` <br> `{3, 2, 1}` |
class Program
{
    static void Main()
    {
        //permutations are simply n variations of n numbers, but without repetition of the numbers
        //so I will use the same algorithm as in Problem 20 with slight modification to exclude all
        //the repeating members

        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        //no need to enter k here, will make it equal to n
        int k = n;

        //set a k digit array
        int[] digit = new int[k];

        //set initial digits to 1, except the k digit
        for (int i = 0; i < k - 1; i++)
            digit[i] = 1;

        //start printing
        bool finish = false;
        while (!finish)
        {
            //start digit incremention from last
            for (int i = k - 1; i >= 0; i--)
            {
                //increment digit
                digit[i]++;

                //if after incremention bigger than max
                if (digit[i] > n)
                {
                    //reset and continou to previous
                    digit[i] = 1;
                }

                else break;

            }

            //check if at least any two digits are equal
            bool noEqual = true;
            for (int i = 0; i < k - 1; i++)
            {
                for (int ii = i + 1; ii < k; ii++)
                {
                    if (digit[i] == digit[ii]) noEqual = false;
                }
            }

            //cycle to print digits if no two digits or more are equal
            if (noEqual)
            {
                for (int i = 0; i < k; i++)
                    Console.Write(digit[i]);
                Console.WriteLine();

            }

            //cycle to check if we have reached the max possible values of all digits
            for (int i = 0; i < k; i++)
            {
                //if at least one is not max we stop the check and continue with next variation
                if (digit[i] != n) { finish = false; break; }
                else finish = true;
            }
        }
    }
}

