using System;
using System.IO;
//### Problem 03. Line numbers
//*	Write a program that reads a text file and inserts line numbers in front of each of its lines.
//*	The result should be written to another text file.
class Program
{
    static void Main()
    {
        using (StreamReader source = new StreamReader(@"..\..\test_1.txt"))
        {
            using (StreamWriter output = new StreamWriter(@"..\..\output.txt"))
            {
                string sourceLine = source.ReadLine();
                int i = 1;
                while (sourceLine != null)
                {
                    output.Write("Line{0,2}: ", i);
                    output.WriteLine(sourceLine, true);
                    i++;
                    sourceLine = source.ReadLine();
                }
            }
        }
    }
}

