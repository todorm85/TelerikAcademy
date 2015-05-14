using System;
using System.Collections.Generic;
////### Problem 10. N Factorial
////*	Write a program to calculate `n!` for each `n` in the range [`1..100`].

////_Hint: Implement first a method that multiplies a number represented as array of digits by given integer number._
class Program
{
    static void Main()
    {
        for (int i = 1; i < 101; i++)
        {
            Console.WriteLine(Fact(i));
        }
    }

    static string Fact(int n)
    {
        string fact = "1";
        for (int i = 1; i <= n; i++)
        {
            fact = MultiplyByDigits(fact, i);
        }

        return fact;
    }

    static string MultiplyByDigits(string largeNum, int num)
    {
        char[] a = largeNum.ToCharArray();
        int offset = 0;
        string sumDigits = "0";
        for (int ai = a.Length - 1; ai >= 0; ai--)
        {
            int product = (a[ai] - 48) * num;
            string productDigits = product.ToString();
            productDigits = productDigits.PadRight(productDigits.Length + offset, '0');
            sumDigits = LargeAdd(productDigits, sumDigits);
            offset++;
        }

        return sumDigits;
    }

    static string LargeAdd(string num1, string num2)
    {
        int numLen = (num1.Length > num2.Length) ? num1.Length : num2.Length;
        num1 = num1.PadLeft(numLen, '0');
        num2 = num2.PadLeft(numLen, '0');
        char[] res = new char[numLen];
        int remainder = 0;

        for (int i = numLen - 1; i >= 0; i--)
        {
            res[i] = (char)(((num1[i] + num2[i] - 2 * 48 + remainder) % 10) + 48);
            remainder = (num1[i] + num2[i] - 2 * 48 + remainder) / 10;
        }

        string resFinal = "";
        if (remainder > 0)
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

