using System;
using System.Linq;

////### Problem 05. Sort by string length
////*You are given an array of strings. Write a method that sorts the array by the length of its elements (the number of characters composing them).
class SortByStringLength
{
    static void Main()
    {
        // WARNING! To better understand this code you can watch the last hour of Matrix and Multidim arrays
        // lecture by Niki from 2013/2014 C# Part 2 archive on TelerikAcademy`s website

        // YOUR INPUT HERE!!!!!!!!!!!!!!!!
        string[] arrStr = 
        {
            "Asen", "Petko", "Mincho", "Martin", "Dancho", "Lyubo", "Lyudmil"
        };

        // using lambda expression we create anonymous function for comparing two values in arrStr
        Array.Sort(arrStr, (x, y) => 
            {
                // we need to make sure that the function returns either -1, 0 or 1
                // if x > y (first value bigger than second) return 1
                if (x.Length > y.Length)
                {
                    return 1;
                }

                // if first value is smaller, return -1
                else if (x.Length < y.Length)
                {
                    return -1;
                }

                // if strings are equal in length sort them lexicographically
                else
                {
                    if (x.CompareTo(y) > 0)
                    {
                        return 1;
                    }
                    if (x.CompareTo(y) < 0)
                    {
                        return -1;
                    }
                    if (x.CompareTo(y) == 0)
                    {
                        return 0;
                    }
                }

                // we need this final statement to fulfil compilers condition to return -1,0 or 1
                // although it will never be reached
                return 0;
            }
            );

        foreach (var item in arrStr)
        {
            Console.WriteLine(item);
        }
    }
}

