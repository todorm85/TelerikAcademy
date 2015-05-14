using System;
using System.Collections.Generic;

////### Problem 07*. Largest area in matrix
////*Write a program that finds the largest area of equal neighbour elements in a rectangular matrix and prints its size.
class LargestAreaInMatrix
{
    static void Main()
    {
        int r = 5;  // YOUR INPUT HERE!!!!!!!!!!!!!!!!
        int c = 6;
        string[,] matrix = new string[5, 6]         // feel free to change matrix for tests but also change n and m if changing size
        {
         { "1", "3", "2", "2", "2", "4" },
         { "3", "3", "3", "2", "4", "4" },
         { "4", "3", "1", "2", "3", "3" },
         { "4", "3", "1", "3", "3", "1" },
         { "4", "3", "3", "3", "1", "1" },
        };
        bool[,] mask = new bool[r, c];  //mask for area check
        int maxSum = 0;

        // first two cycles go through every row and column element except the last
        for (int id0 = 0; id0 < matrix.GetLength(0) - 1; id0++)
        {
            for (int id1 = 0; id1 < matrix.GetLength(1) - 1; id1++)
            {                
                mask[id0, id1] = true;      //include the current element
                string element = matrix[id0, id1];

                // start including adjacent elements
                while (true)
                {
                    bool changeMade = false;    // assume that no element is changed and start cycling through all
                    for (int idd0 = 0; idd0 < matrix.GetLength(0); idd0++)
                    {
                        for (int idd1 = 0; idd1 < matrix.GetLength(1); idd1++)
                        {
                            // include current element if it equals the value of the element being checked and any adjacent element is already included
                            if (matrix[idd0, idd1] == element && !mask[idd0, idd1])
                            {
                                bool rowTop = idd0 == 0;
                                bool rowBottom = idd0 == r - 1;
                                bool colLeft = idd1 == 0;
                                bool colRight = idd1 == c - 1;

                                if (!rowBottom)
                                {
                                    if (mask[idd0 + 1, idd1])
                                    {
                                        mask[idd0, idd1] = true;
                                        changeMade = true;
                                    }
                                }
                                if (!rowBottom && !colRight)
                                {
                                    if (mask[idd0 + 1, idd1 + 1])
                                    {
                                        mask[idd0, idd1] = true;
                                        changeMade = true;
                                    }
                                }
                                if (!colRight)
                                {
                                    if (mask[idd0, idd1 + 1])
                                    {
                                        mask[idd0 , idd1] = true;
                                        changeMade = true;
                                    }
                                }
                                if (!rowTop && !colRight)
                                {
                                    if (mask[idd0 - 1, idd1 + 1])
                                    {
                                        mask[idd0 - 1 , idd1 + 1] = true;
                                        changeMade = true;
                                    }
                                }
                                if (!rowTop)
                                {
                                    if (mask[idd0 - 1, idd1])
                                    {
                                        mask[idd0 , idd1] = true;
                                        changeMade = true;
                                    }
                                }
                                if (!rowTop && !colLeft)
                                {
                                    if (mask[idd0 - 1, idd1 - 1])
                                    {
                                        mask[idd0 , idd1 ] = true;
                                        changeMade = true;
                                    }
                                }
                                if (!colLeft)
                                {
                                    if (mask[idd0, idd1-1])
                                    {
                                        mask[idd0, idd1-1] = true;
                                        changeMade = true;
                                    }
                                }
                                if (!rowBottom && !colLeft)
                                {
                                    if (mask[idd0 + 1, idd1 - 1])
                                    {
                                        mask[idd0 , idd1 ] = true;
                                        changeMade = true;
                                    }
                                }
                            }
                        }
                    }

                    if (!changeMade)
                    {
                        break;
                    }
                }

                int sum = 0;
                for (int idd0 = 0; idd0 < matrix.GetLength(0); idd0++)
                {
                    for (int idd1 = 0; idd1 < matrix.GetLength(1); idd1++)
                    {                        
                        if (mask[idd0,idd1])
                        {
                            sum++;
                            mask[idd0,idd1] = false;    // reset the mask
                        }
                    }
                }

                maxSum = (sum > maxSum) ? sum : maxSum;                
            }
        }

        Console.WriteLine(maxSum);
    }
}

