using System;
using System.IO;
//### Problem 02. Concatenate text files
//*	Write a program that concatenates two text files into another text file.
class Program
{
    static void Main()
    {
        // copy first file
        File.Copy(@"..\..\test_1.txt", @"..\..\output.txt", true);

        // check if first file was empty
        bool isEmpty = true;
        using (StreamReader outputRead = new StreamReader(@"..\..\output.txt"))
        {
            if (outputRead.ReadLine() != null) isEmpty = false;
        }

        // write new line char as last char if it was not empty
        using (StreamWriter outputWrite = new StreamWriter(@"..\..\output.txt", true))
        {
            if (!isEmpty)
            {
                outputWrite.WriteLine();
            }
        }

        // append lines from second file
        using (StreamReader test_2Read = new StreamReader(@"..\..\test_2.txt"))
        {
            string line;
            using (StreamWriter output = new StreamWriter(@"..\..\output.txt", true))
            {
                line = test_2Read.ReadLine();
                while (line != null)
                {
                    output.WriteLine(line);
                    line = test_2Read.ReadLine();
                }
            }
        }
    }
}

