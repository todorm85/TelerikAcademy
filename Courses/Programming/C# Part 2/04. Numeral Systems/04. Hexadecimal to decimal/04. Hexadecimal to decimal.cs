using System;
//### Problem 04. Hexadecimal to decimal
//*	Write a program to convert hexadecimal numbers to their decimal representation.
class Program
{
    static void Main()
    {
        Console.Write("Enter hex: ");
        string binary = Console.ReadLine();
        int res = Hex2Decimal(binary);
        Console.WriteLine(res);
    }

    static int Hex2Decimal(string input)
    {
        char[] hex = input.ToCharArray();
        Array.Reverse(hex);
        int res = 0;
        int digit = 0;

        for (int i = 0; i < hex.Length; i++)
        {
            if (hex[i] > 64 && hex[i] < 91)
            {
                digit = (int)(hex[i] - 55);
            }

            else if (hex[i] > 96)
            {
                digit = (int)hex[i] - 87;
            }

            else
            {
                digit = int.Parse(hex[i].ToString());
            }

            res += (int)(digit * Math.Pow(16, i));
        }

        return res;
    }
}

