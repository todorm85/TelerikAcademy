using System;
//### Problem 08. Binary short
//*	Write a program that shows the binary representation of given 16-bit signed integer number (the C# type `short`).
class Program
{
    static void Main()
    {
        Console.Write("Enter integer: ");
        short num = short.Parse(Console.ReadLine());
        string binary = ToBinary(num);
        PrintBinary(binary);
        Console.WriteLine("\n\nAfter built-in conversion");
        Console.WriteLine(Convert.ToString(num,2).PadLeft(16,'0'));
    }

    static string ToBinary(short num)
    {
        // k is positive decimal that will be converted to binary
        // k needs to be int because of the border case when num = -32768
        int k = num;
        k = Math.Abs(k);
        if (num < 0)
        {
            k--;
        }

        string res = "";
        while (k > 0)
        {
            res += (k % 2).ToString();
            k /= 2;
        }

        char[] resCharArray = res.ToCharArray();
        Array.Reverse(resCharArray);

        // invert binary representation res and append 1`s to the left if num<0 or
        if (num<0)
        {
            for (int i = 0; i < resCharArray.Length; i++)
            {
                resCharArray[i] = (resCharArray[i]=='0') ? '1' : '0';   
            }

            res = new string(resCharArray).PadLeft(16,'1');
        }

        // append zeros to the left if num>=0
        else
        {
            res = new string(resCharArray).PadLeft(16, '0');
        }

        
        return res;
    }

    static void PrintBinary(string res)
    {
        for (int i = 0; i < res.Length; i++)
        {
            Console.Write(res[i]);
            if ((i + 1) % 4 == 0)
            {
                Console.Write(" ");
            }
        }
    }
}

