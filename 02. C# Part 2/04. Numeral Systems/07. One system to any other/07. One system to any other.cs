using System;
//### Problem 07. One system to any other
//*	Write a program to convert from any numeral system of given base `s` to any other numeral system of base `d`  (2<=s d<=16)
class Program
{
    static void Main()
    {
        // works with s and d in the range of [2 to 35]
        Console.Write("Enter source base: ");
        int s = int.Parse(Console.ReadLine());
        Console.Write("Enter number: ");
        string num = Console.ReadLine();
        num.ToUpper();
        Console.Write("Enter destination base: ");
        int d = int.Parse(Console.ReadLine());

        string result = Base10ToAny(AnyToBase10(num, s), d);
        Console.WriteLine(result);
    }

    static long AnyToBase10(string num, int s)
    {
        long sum = 0;
        for (int i = 0; i < num.Length; i++)
        {
            int digit = 0;
            if (num[i] > 64 && num[i] < 91)
            {
                digit = num[i] - 55;
            }

            if (num[i] > 47 && num[i] < 58)
            {
                digit = num[i] - 48;
            }

            sum += (long)(digit * Math.Pow(s, num.Length - 1 - i));
        }

        return sum;
    }

    static string Base10ToAny(long num, int d)
    {
        string res = "";
        while (num != 0)
        {
            long digit = num % d;
            if (digit > 9)
            {
                res += (char)(digit + 55);
            }
            else
            {
                res += digit.ToString();
            }

            num /= d;
        }

        char[] resCharArr = res.ToCharArray();
        Array.Reverse(resCharArr);
        res = new string(resCharArr);
        return res;
    }
}

