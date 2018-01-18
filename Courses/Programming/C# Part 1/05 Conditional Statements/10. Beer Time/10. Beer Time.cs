using System;

//Problem 10.* Beer Time
//• A beer time is after  1:00 PM  and before  3:00 AM .
//• Write a program that enters a time in format “hh:mm tt”
//(an hour in range [01...12], a minute in range [00…59] and AM / PM 
//designator) and prints  beer time  or  non-beer time  according to
//the definition above or  invalid time  if the time cannot be parsed.
//Note: You may need to learn how to parse dates and times. 

//Examples:
//time        result
//1:00 PM     beer time 
//4:30 PM     beer time 
//10:57 PM    beer time 
//8:30 AM     non-beer time 
//02:59 AM    beer time 
//03:00 AM    non-beer time 
//03:26 AM    non-beer time 

class Beer_Time
{
    static void Main()
    {
        DateTime input;     //if we input just time, the date is automatically assigned to the current system`s
        DateTime beerStart = DateTime.Parse("1:00 PM");
        DateTime beerEnd = DateTime.Parse("3:00 AM");

        start:
        //cycle that will continously prompt the user to write his/her birth date until a valid input is received
        do
        {
            Console.Write("\nEnter time (hh:mm tt):");
        }

        while (!DateTime.TryParse(Console.ReadLine(), out input));
        //checks for valid date input and if true assigns to input

        if (input >= beerStart)     //we cannot simultaneously check whether the entered time is bigger than start and smaller than end,
            // because they are from the same day. And if bigger than start will always be bigger than end. We need to do the check separately
            //with two different ifs.
        {
            Console.WriteLine("Beer time!");
        }
        else
        {
            if (input < beerEnd)
            {
                Console.WriteLine("Beer time!"); //second check whether the entered time falls within range
            }
            else
            {
                Console.WriteLine("Not a beer time :(.");   //if both checks fail it is not beer time.
            }
        }
        goto start;
    }
}

