using System;
using System.Collections.Generic;
//### Problem 3. Compare char arrays
//*	Write a program that compares two `char` arrays lexicographically (letter by letter).
class Program
{
    static void Main()
    {
        //input the first char array
        List<char> myList1 = new List<char>();
        Console.Write("Start typing characters for array 1, to finish press Escape\n");
        int indx = 0;
        while (true)
        {
            Console.Write("Array1[{0,2}] = ", indx);
            ConsoleKeyInfo inputKey = Console.ReadKey();
            if (inputKey.Key == ConsoleKey.Escape) break;
            if (inputKey.Key == ConsoleKey.Enter) continue;
            myList1.Add(inputKey.KeyChar);
            indx++;
            Console.WriteLine();
        }

        //input of second char array
        List<char> myList2 = new List<char>();
        Console.Write("\nStart typing characters for array 2, to finish press Escape\n");
        indx = 0;
        while (true)
        {
            Console.Write("Array2[{0,2}] = ", indx);
            ConsoleKeyInfo inputKey = Console.ReadKey();
            if (inputKey.Key == ConsoleKey.Escape) break;
            if (inputKey.Key == ConsoleKey.Enter) continue;
            myList2.Add(inputKey.KeyChar);
            indx++;
            Console.WriteLine();
        }
        Console.WriteLine();

        //comparison of char arrays
        for (int i = 0; i < myList1.Count && i < myList2.Count; i++)
        {
            //checks if character is a letter
            if (!((myList1[i] > 64 && myList1[i] < 91) || (myList1[i] > 96 && myList1[i] < 123)))
            {
                Console.WriteLine("Not a letter character in Array1[{0}]",i);
                continue;
            }
            if (!((myList2[i] > 64 && myList2[i] < 91) || (myList2[i] > 96 && myList2[i] < 123)))
            {
                Console.WriteLine("Not a letter character in Array2[{0}]", i);
                continue;
            }

            //assigns an integer value to letters making capital and non-capital forms of the same letter equal
            int list1Temp = 0;
            int list2Temp = 0;
            if (myList1[i] > 64 && myList1[i] < 91) list1Temp = myList1[i] - 64;
            if (myList2[i] > 64 && myList2[i] < 91) list2Temp = myList2[i] - 64;
            if (myList1[i] > 96 && myList1[i] < 123) list1Temp = myList1[i] - 96;
            if (myList2[i] > 96 && myList2[i] < 123) list2Temp = myList2[i] - 96;

            //actual comparison of the letters` values from array1 and array2
            if (list1Temp > list2Temp)
            {
                Console.WriteLine("Array1 [{0}] > Array 2 [{0}]", i);
            }
            else if (list1Temp < list2Temp)
            {
                Console.WriteLine("Array1 [{0}] < Array 2 [{0}]", i);
            }
            else
            {
                Console.WriteLine("Array1 [{0}] = Array 2 [{0}]", i);
            }
        }

    }
}

