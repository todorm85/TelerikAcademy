using System;
using System.Collections.Generic;
using System.Linq;

//notes from 2015 array by Niki

class Program
{
    static void Main()
    {
        List<int> list = new List<int>();

        list.AddRange(new int[] { 1, 2, 3, 4, 3, 5, 6 });  //add an array of values to the list

        list.Insert(5, 123);    //inserts to index 5 123 and moves all the right to the right one position
        list.Add(5);    //adds 5 to the end
        list.Remove(5);     //removes the first instance of five from left to right, and shifts indexes accordingly
        list.RemoveAll(x => x == 5);      //removes all instances of 5
        list.Sort();    //sorts list
        bool existThree = list.Contains(3);   //is there number 3 in list?
        int threeIndx = list.IndexOf(3);    //index of first occurrance of 3, if there is no 3 returns value -1
        int size = list.Count;   //returns list size
        list.Reverse();     //reverses the list
        int[] arr = list.ToArray(); //stores all list list items to array arr
        list.Clear();   //resets the list with zero elements
        Console.WriteLine(list.Capacity);   //current list capacity - memory size

        List<string> listStr = new List<string>();
        listStr.AddRange(new string[] { "1", "2222", "33", "4", "3", "5", "6" });
        listStr = listStr.OrderBy(x => x.Length).ToList(); //orders the listStr by the length of the string values

        List<List<int>> jaggedList = new List<List<int>>();     //multi dim list
        jaggedList.Add(new List<int>());    //add list to zero position in jagged list
        jaggedList[0].Add(5);       //add 5 to zero position in zero list in jaggedList
        Console.WriteLine(jaggedList[0][0]);
        jaggedList[0][0] = 1;   //assign 1 to zero element of zero list (zero position in global list).
        Console.WriteLine(jaggedList[0][0]);

        int[] source = { 2, 5, 7, 9, 10, 4, 3 };
        int[] copy = (int[])source.Clone();   //Clone method returns object (it just copies the bits from one part of the memory to the other) so we need to specify what these sequence of bits is. In this case its an integer array. That`s why we can clone anything but then need to cast it to the type it is explicitly. This is deep copy - it copies not just the pointer to memory but the entire array in memory itself and assigns the new array`s pointer to this new part of memory.

        int fiveIdx = Array.IndexOf(source, 5);   //returns the index of first instance of 5 in source array
        Array.Reverse(copy);

        source = new int[] { -2, 1, 3, -4, 5, 10 };
        source = source.OrderBy(x => Math.Abs(x)).ToArray();    //requires System.Linq. This orders elements but first takes their absolute values
        copy = source.Where(x => x < 0).ToArray();  //takes only negatives from source and puts in copy
    }
}

