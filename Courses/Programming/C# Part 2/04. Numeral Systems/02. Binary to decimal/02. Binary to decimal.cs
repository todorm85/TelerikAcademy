using System;
//### Problem 02. Binary to decimal
//*	Write a program to convert binary numbers to their decimal representation.
class Program
{
    static void Main()
    {
        Console.Write("Enter binary: ");
        string binary = Console.ReadLine();
        int res = Bin2Decimal(binary);
        Console.WriteLine(res);
    }

    static int Bin2Decimal(string input)
    {
        char[] binary = input.ToCharArray();
        Array.Reverse(binary);
        int res = 0;
        
        for (int i = 0; i < binary.Length; i++)
        {
            int digit = int.Parse(binary[i].ToString());
            res += (int)(digit * Math.Pow(2, i));
        }

        return res;
    }
}

