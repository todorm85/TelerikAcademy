using System;
using System.IO;
//### Problem 01. Odd lines
//*	Write a program that reads a text file and prints on the console its odd lines.
class Program
{
    static void Main()
    {
        StreamReader input = new StreamReader(@"..\..\test_read.txt");
        string line = input.ReadLine();
        int counter = 0;    // counter to see at what line are we
        while (line!=null)
        {
            counter++;
            if (counter%2==1)
            {
                Console.Write("line{0}: ",counter);
                Console.WriteLine(line);
            }

            else
            {
                Console.WriteLine();
            }

            line = input.ReadLine();
        }

        input.Close();
    }
}

