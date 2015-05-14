using System;
//### Problem 01. Decimal to binary
//*	Write a program to convert decimal numbers to their binary representation.
class Program
{
    static void Main()
    {
        Console.Write("Enter integer: ");
        int num = int.Parse(Console.ReadLine());

        char[] binary = ToBinary(num);
        PrintBinary(binary);
    }

    static char[] ToBinary(int num)
    {
        string res = "";
        while (num > 0)
        {
            res += (num % 2).ToString();
            num /= 2;
        }

        char[] resCharArray = res.ToCharArray();
        Array.Reverse(resCharArray);
        return resCharArray;

    }

    static void PrintBinary(char[] bin)
    {
        string res = "";
        res = new string(bin);
        res = res.PadLeft(32, '0');
        for (int i = 0; i < res.Length; i++)
        {
            Console.Write(res[i]);
            if ((i+1)%8==0)
            {
                Console.Write(" ");
            }
        }
    }
}

