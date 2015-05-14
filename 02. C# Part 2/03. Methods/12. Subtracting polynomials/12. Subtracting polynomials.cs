using System;
//### Problem 12. Subtracting polynomials
//*	Extend the previous program to support also subtraction and multiplication of polynomials.
class Program
{
    static void Main()
    {
        // MODIFY YOUR INPUT HERE!!!!!!!!!!!!!!!!!!
        // first coefficient is the constant, then the power of 1, power of 2 and so on....
        int[] poly1 = { 3, 1 };
        int[] poly2 = { 2, 1, 2 };

        PrintPoly(poly1);
        PrintPoly(poly2);
        Console.WriteLine("\nSum");
        PrintPoly(Sum(poly1, poly2));
        Console.WriteLine("\nSubtraction");
        PrintPoly(Subtract(poly1, poly2));
        Console.WriteLine("\nMultiplication");
        PrintPoly(Multiply(poly1, poly2));

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

    static int[] Subtract(int[] poly1, int[] poly2)
    {
        int maxLength = Math.Max(poly1.Length, poly2.Length);
        int minLength = Math.Min(poly1.Length, poly2.Length);
        int[] res = new int[maxLength];

        for (int id = 0; id < minLength; id++)
        {
            res[id] = poly1[id] - poly2[id];
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

    static int[] Multiply(int[] poly1, int[] poly2)
    {
        int[] res = new int[poly1.Length + poly2.Length - 1];

        for (int id1 = 0; id1 < poly1.Length; id1++)
        {
            for (int id2 = 0; id2 < poly2.Length; id2++)
            {
                res[id1 + id2] += (poly1[id1] * poly2[id2]);

            }
        }

        return res;
    }

    static void PrintPoly(int[] poly)
    {
        for (int i = 0; i < poly.Length; i++)
        {
            if (i != 0)
            {
                Console.Write("{0,2} * x^{1}", poly[i], i);
            }
            else
            {
                Console.Write("{0,2}", poly[i]);
            }

            if (i < poly.Length - 1) Console.Write(" + ");
        }

        Console.WriteLine();
    }
}