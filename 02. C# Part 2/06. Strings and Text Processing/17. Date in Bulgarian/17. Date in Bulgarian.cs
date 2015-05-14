using System;
using System.Globalization;
//### Problem 17. Date in Bulgarian
//*	Write a program that reads a date and time given in the format: `day.month.year hour:minute:second` and prints the date and time after `6` hours and `30` minutes (in the same format) along with the day of week in Bulgarian.
class Program
{
    static void Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
        //System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        DateTime date1;
        Console.WriteLine("Enter date 1 (dd.MM.yyyy HH:mm:ss): ");
        while (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture , DateTimeStyles.None, out date1))
        {
            Console.WriteLine("Invalid input!");
            Console.WriteLine("Enter date 1 (dd.MM.yyyy HH:mm:ss): ");
        }

        CultureInfo bg = new CultureInfo("bg-BG");
        string day = bg.DateTimeFormat.GetDayName(date1.DayOfWeek);
        Console.WriteLine("{0:dd.MM.yyyy HH:mm:ss} {1}", date1, day);
    }
}

