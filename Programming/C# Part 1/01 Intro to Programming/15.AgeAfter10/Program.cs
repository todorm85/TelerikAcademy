using System;

class AgeAfter10
{
    static void Main()
    {
        DateTime bDay;

        do                                                                             //cycle that will continously prompt the user to write his/her birth date until a valid input is received
        {
            Console.Write("\nEnter your birth date (year/month/day hour:min):");       //"\n" in the beginning is an escape character and moves the cursor to a new line
        }

        while (!DateTime.TryParse(Console.ReadLine(), out bDay));                      //checks for valid date input and if true assigns to BDay

        TimeSpan age = DateTime.Now.AddYears(10) - bDay;                               //define special variable age of type TimeSpan to calculate the time between 10 years from now and the birth date
        Console.WriteLine("Your age after 10 years: " + (int)age.TotalDays / 365);     //outputs the timespan in years. The value age.TotalDays returns a double type by default so we need to convert it to int. This way when we divide by 365 it returns only the whole number.
    }
}

