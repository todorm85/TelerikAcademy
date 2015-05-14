using System;
using System.Collections.Generic;
////### Problem 11. Adding polynomials
////*	Write a method that adds two polynomials.
////*	Represent them as arrays of their coefficients.
class Program
{
    static void Main()
    {
        // MODIFY YOUR INPUT HERE!!!!!!!!!!!!!!!!!!
        // first coefficient is the constant, then the power of 1, power of 2 and so on....
        int[] poly1 = { 2, 5, 14 };
        int[] poly2 = { 6, 3 };

        PrintPoly(poly1);
        PrintPoly(poly2);
        PrintPoly(Sum(poly1, poly2));


    }

    static int[] Sum(int[] poly1, int[] poly2)
    {
        int maxLength = Math.Max(poly1.Length, poly2.Length);
        int minLength = Math.Min(poly1.Length, poly2.Length);
        int[] res = new int[maxLength];

        for (int id = 0; id < minLength; id++)
        {
            res[id] = poly1[id] + poly2[id];
        }

        if (maxLength != minLength)
        {
            for (int id = minLength; id < maxLength; id++)
            {
                res[id] = (poly1.Length == maxLength) ? poly1[id] : poly2[id];
            }
        }

        return res;
    }

    static void PrintPoly(int[] poly)
    {
        for (int i = 0; i < poly.Length; i++)
        {
            Console.Write(poly[i] + " * x^" + i);
            if (i < poly.Length - 1) Console.Write(" + ");
        }

        Console.WriteLine();
    }
}

