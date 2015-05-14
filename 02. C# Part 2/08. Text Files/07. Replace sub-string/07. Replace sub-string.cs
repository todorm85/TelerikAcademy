using System;
using System.IO;
//### Problem 07. Replace sub-string
//*	Write a program that replaces all occurrences of the sub-string `start` with the sub-string `finish` in a text file.
//*	Ensure it will work with large files (e.g. `100 MB`).
class UntitledClass
{
    static void Main()
    {
        using (StreamReader source = new StreamReader(@"..\..\source.txt"))
        {
            string sourceLine = source.ReadLine();
            using (StreamWriter output = new StreamWriter(@"..\..\output.txt"))
            {
                while (sourceLine != null)
                {
                    sourceLine = sourceLine.Replace("start", "finish");
                    output.WriteLine(sourceLine);
                    sourceLine = source.ReadLine();
                }

            }
        }
    }
}

