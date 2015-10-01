using System;
using System.Globalization;
//Problem 11. Format number• Write a program that reads a number and prints it as a decimal number, hexadecimal number, percentage and in scientific notation.
//• Format the output aligned right in 15 symbols.

class Program
{
    static void Main()
    {
        int n = 25;
        //CultureInfo culture = new CultureInfo("bg-BG");
        Console.WriteLine("{0,15}{1,15}{2,15}{3,15}", "Decimal", "Hex", "Percent", "Scientific");
        Console.WriteLine("{0,15:D}{1,15:X}{2,15:P}{3,15:E}", n, n, n, n);
    }
}
