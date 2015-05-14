using System;

//Problem 8. Catalan Numbers•
//In combinatorics, the Catalan numbers are calculated by the following formula: catalan-formula 
//• Write a program to calculate the  nth  Catalan number by given  n  (1 < n < 100). 

//Examples:
//n   Catalan(n)
//0   1 
//5   42 
//10  16796 
//15  9694845 

class Catalan_Numbers
{
    static void Main()
    {
        Console.Write("Enter integer n (0 to 100): ");
        byte n = byte.Parse(Console.ReadLine());

        double nfacTimes2 = 1;
        double nfac = 1;
        double nfacPlusOne = 1;

        for (byte i = 1; i <= 2*n; i++)
        {
            nfac = (i <= n) ? nfac * i : nfac; 
            nfacPlusOne = ( i <= (n+1) ) ? nfacPlusOne * i : nfacPlusOne;
            nfacTimes2 *= i;
        }

        Console.WriteLine(nfacTimes2 / (nfacPlusOne * nfac));
    }
}
