using System;
using System.IO;
//### Problem 06. Save sorted names
//*	Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file.

//_Example:_

//|  input.txt | output.txt |
//|:----------:|:----------:|
//| Ivan <br> Peter <br> Maria <br> George | George <br> Ivan <br> Maria <br> Peter |
class Save_sorted_names
{
    static void Main()
    {
        using (StreamReader source = new StreamReader(@"..\..\source.txt"))
        {
            string[] names = File.ReadAllLines(@"..\..\source.txt");
            Array.Sort(names);
            using (StreamWriter target = new StreamWriter(@"..\..\target.txt"))
            {
                for (int i = 0; i < names.Length; i++)
                {
                    target.WriteLine(names[i]);
                }
            }
        }
    }
}

