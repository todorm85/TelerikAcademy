using System;
//### Problem 1. Leap year
//*	Write a program that reads a year from the console and checks whether it is a leap one.
//*	Use `System.DateTime`.
class Program
{
    static void Main()
    {
        Console.Write("Enter year: ");
        int year = int.Parse(Console.ReadLine());
        bool answer = DateTime.IsLeapYear(year);
        Console.WriteLine("Is leap year: " + answer);
    }
}

