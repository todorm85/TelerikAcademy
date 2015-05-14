using System;
//### Problem 20(bonus). Variations of set without Repetition
//This task is not in the homeworks!!!!! It`s just a personal bonus.
//*	Write a program that reads two numbers `N` and `K` and generates all the variations of `K` elements from the set [`1..N`].
class Program
{
    static void Main()
    {
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

            //cycle to print digits if no any two digits or more are equal
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

