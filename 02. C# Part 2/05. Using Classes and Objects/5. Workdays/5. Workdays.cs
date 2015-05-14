using System;
//### Problem 5. Workdays
//*	Write a method that calculates the number of workdays between today and given date, passed as parameter.
//*	Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter date (year/month/day): ");
        DateTime endDate = DateTime.Parse(Console.ReadLine());
        // holidays in array are from non leap year
        DateTime[] holidays = new DateTime[] 
        {
            // later we use only the DayofYear property, year here must be non-leap year
            new DateTime(2001,12,24),
            new DateTime(2001,3,3),
        };

        int count = WorkDaysToDate(endDate, holidays);
        Console.WriteLine(count);
    }

    private static int WorkDaysToDate(DateTime endDate, DateTime[] holidays)
    {
        DateTime today = DateTime.Today;
        if (endDate <= today) return 0;
        int counter = 0;
        while (today < endDate)
        {
            bool isHoliday = false;
            int leapIndex = 0;  // this is a correction index for leap years
            if (DateTime.IsLeapYear(today.Year))
            {
                leapIndex = 1;
            }

            if (today <= new DateTime(2015 / 2 / 28))  // we don`t need correction index for these days of leap year
            {
                leapIndex = 0;
            }

            for (int i = 0; i < holidays.Length; i++)
            {

                if (today.DayOfYear - leapIndex == holidays[i].DayOfYear)
                {
                    isHoliday = true;
                    break;
                }
            }

            if (today.DayOfWeek == DayOfWeek.Saturday || today.DayOfWeek == DayOfWeek.Sunday) isHoliday = true;

            if (isHoliday)
            {
                today = today.AddDays(1);
            }
            else
            {
                counter++;
                today = today.AddDays(1);
            }
        }
        counter--; // don`t count first day
        return counter;
    }
}

