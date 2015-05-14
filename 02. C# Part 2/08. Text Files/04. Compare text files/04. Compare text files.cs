using System;
using System.IO;
//### Problem 04. Compare text files
//*	Write a program that compares two text files line by line and prints the number of lines that are the same and the number of lines that are different.
//*	Assume the files have equal number of lines.
class Program
{
    static void Main()
    {
        using (StreamReader file_1 = new StreamReader(@"..\..\file_1.txt"), file_2 = new StreamReader(@"..\..\file_2.txt"))
        {
            string lineLeft = file_1.ReadLine();
            string lineRight = file_2.ReadLine();
            int same = 0;
            int different = 0;
            while (lineLeft != null && lineRight != null)
            {
                if (lineRight == lineLeft)
                {
                    same++;
                }
                else
                {
                    different++;
                }

                lineLeft = file_1.ReadLine();
                lineRight = file_2.ReadLine();
            }

            Console.WriteLine("Same: {0}, Different: {1}", same, different);
        }
    }
}

