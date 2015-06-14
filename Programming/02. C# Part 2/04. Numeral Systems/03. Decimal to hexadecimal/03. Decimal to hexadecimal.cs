using System;
//### Problem 03. Decimal to hexadecimal
//*	Write a program to convert decimal numbers to their hexadecimal representation.
class Program
{
    static void Main()
    {
        Console.Write("Enter integer: ");
        int num = int.Parse(Console.ReadLine());

        char[] hex = ToHex(num);
        PrintHex(hex);
    }

    static char[] ToHex(int num)
    {
        string res = "";
        while (num > 0)
        {
            int remainder = num % 16;
            if (remainder > 9)
            {
                res += ((char)(remainder+55)).ToString();
            }

            else
            {
                res += remainder.ToString();
            }

            num /= 16;
        }

        char[] resCharArray = res.ToCharArray();
        Array.Reverse(resCharArray);
        return resCharArray;

    }

    static void PrintHex(char[] bin)
    {
        string res = "";
        res = new string(bin);
        if (bin.Length % 2 != 0) res = "0" + res;
        for (int i = 0; i < res.Length; i++)
        {
            Console.Write(res[i]);
            if ((res.Length - i-1) % 2 == 0)
            {
                Console.Write(" ");
            }
        }
    }
}

