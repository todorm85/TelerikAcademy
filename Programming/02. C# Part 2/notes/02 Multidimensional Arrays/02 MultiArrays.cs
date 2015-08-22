using System;
using System.Collections.Generic;
using System.Linq;

//notes from 2014 lecture Матрици и многомерни масиви (Niki™)

class Program
{
    static void Main()
    {
        int[,] myArr = { { 3, 4, 5 }, 
                         { 7, 8, 10 } };
        Console.WriteLine(myArr.GetLength(0));   //number of rows
        Console.WriteLine();

        //create large matrix and fill with nums
        Random rand = new Random(); 

        int[,] matrix = new int[100, 100];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = rand.Next(1, 101);
            }
        }

        //jagged arrays
        int n = 5;
        int[][] jagged = new int[n][];
        for (int i = 0; i < n; i++)
        {
            jagged[i] = new int[i+1];
        }

        //jagged array with lists
        List<int>[] arrayWithLists = new List<int>[3];

        string[,] dim2ArrStr = new string[11, 11];
        Console.WriteLine(dim2ArrStr.Rank);  //returns 2 (2 dimensional)
        Console.WriteLine(dim2ArrStr.Length);     //returns num of all element in all dimensions 121
        Console.WriteLine(dim2ArrStr.LongLength);  //num of elements in long type
        Console.WriteLine(dim2ArrStr.GetLength(0));  //returns size of first dim - 11
        string[] dim1ArrStr = new string[5];
        Console.WriteLine(Array.IndexOf(dim1ArrStr, "word"));  //finds index of "word" value or returns -1 if not found, only single dimension arrays are supported
        Console.WriteLine(Array.LastIndexOf(dim1ArrStr, "word")); //returns lindex of word in firs found value starting from last member
        Console.WriteLine(Array.IndexOf(dim1ArrStr, "word", 2)); //begin searching for word from index 2 forward

        string[,] myArrStr2 = new string[11,11];
        Array.Copy(dim2ArrStr,myArrStr2, dim2ArrStr.Length);    //copies array
        myArrStr2 = (string[,])dim2ArrStr.Clone();    //copies array
        Array.Reverse(dim1ArrStr);    //this works with the memory of the array that is why we don`t need to assign it again to the array ( dim1ArrStr = Array.Reverse(dim1ArrStr); )
        
        int[] numbers = {3,7,2245,10,15,36788,2321,1234};
        Array.Sort(numbers);

        Array.Sort(numbers, (x, y) => (x%7).CompareTo(y%7));    //compares by remainder of %7 with lambda expression (functional programming)

        //next compare numbers by last digit, if last digits equal just compare numbers, lambda expression (functional programming)
        Array.Sort(numbers, (x, y) =>
            {
                int xRemainder = x % 10;
                int yRemainder = y % 10;
                if (xRemainder==yRemainder)
                {
                    if (x > y) return 1;
                    if (x < y) return -1;
                    if (x == y) return 0;
                    //return x.CompareTo(y);
                }
                if (xRemainder > yRemainder)
                {
                    return 1;
                }
                if (xRemainder < yRemainder)
                {
                    return -1;
                }
                return 0;
            });


    }
}

