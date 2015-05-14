using System;
////### Problem 8. Number as array
////*	Write a method that adds two positive integer numbers represented as arrays of digits (each array element `arr[i]` contains a digit; the last digit is kept in `arr[0]`).
////*	Each of the numbers that will be added could have up to `10 000` digits.
class Program
{
    static void Main()
    {
        Console.Write("Enter num1: ");
        string num1 = Console.ReadLine();
        Console.Write("Enter num2: ");
        string num2 = Console.ReadLine();
        if (num1.Length>10000 || num2.Length>10000)
        {
            Console.WriteLine("Invalid Input");
            return;
        }

        string result = LargeAdd(num1, num2);
        Console.WriteLine("{0} + {1} = {2}", num1, num2, result);
    }

    static string LargeAdd(string num1,string num2)
    {
        int numLen = (num1.Length > num2.Length) ? num1.Length : num2.Length;
        num1 = num1.PadLeft(numLen, '0');
        num2 = num2.PadLeft(numLen, '0');
        char[] res = new char[numLen];
        int remainder = 0;

        for (int i = numLen-1; i >= 0; i--)
        {
            res[i] = (char)(((num1[i] + num2[i] - 2 * 48 + remainder) % 10) + 48);
            remainder = (num1[i] + num2[i] - 2 * 48 + remainder) / 10;
        }

        string resFinal = "";
        if (remainder>0)
        {
            resFinal = "1";
        }

        for (int i = 0; i < numLen; i++)
        {
            resFinal += res[i];
        }

        return resFinal;
    }
}

