using System;
using System.IO;

namespace Problem
{
    internal class Inputs
    {
        internal static void SetInput(string testNum)
        {
            var ar = new StreamReader(File.Open($@"..\..\tests\test.{testNum}.out.txt", FileMode.Open));
            Console.WriteLine($"Expected: {ar.ReadLine()}");

            var tr = new StreamReader(File.Open($@"..\..\tests\test.{testNum}.in.txt", FileMode.Open));
            Console.SetIn(tr);

            
        }
    }
}