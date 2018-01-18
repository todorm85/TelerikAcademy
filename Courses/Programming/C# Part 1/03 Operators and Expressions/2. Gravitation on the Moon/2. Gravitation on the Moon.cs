using System;

//Problem 2. Gravitation on the Moon
//• The gravitational field of the Moon is approximately  17%  of that on the Earth.
//• Write a program that calculates the weight of a man on the moon by a given weight on the Earth.
//Examples:
//weight / weight on the Moon
//86 / 14.62 
//74.6 / 12.682 
//53.7 / 9.129 


class GravitationOnTheMoon
{
    static void Main()
    {
        Console.Write("Enter your weight:");
        float weight = float.Parse(Console.ReadLine());

        //The first two lines prompt the user for input and read it from the console.
        //float.Parse() method converts the input array of chars to a float value.
        //Float is more than enough for representation of human weight values. 
        //It has total of 7 digits of precision after the decimal point in normalized scientific notation. A total of 8 digits for the whole number.
        //Every person`s weight is represented with a maximum of 3 digits for the whole number, which
        //leaves minimum 5 digits of precision after the decimal point. Only 3 digits are needed
        //to represent grams. So float is more than enough for our needs.
        //Also not all decimal fractions can be represented accurately in binary. 
        //It is likely that there will be occasions where the last digit
        //will get rounded. But since we`ll be working with numbers that are not very close to zero
        //we are guaranteed with an accuracy in the results of at least 0.00005 at worst (this is not precision!).
        //Precision is concered with significant digits of the number. See http://www.cprogramming.com/tutorial/floating_point/understanding_floating_point_representation.html for more info.
        //It is also very important to note that
        //the calculations involved will not include any intermediate results that will be very close to zero!!
        //Float starts to lose precision for numbers with absolute value smaller than  1.1754943e-38.
        //The smallest absolute value representable in float is 1.4e-45, but it has only 1 digit of precision.
        //Avoid using floats with numbers smaller than 1.1754943e-38.

        float moonWeight = 17 * weight / 100;
        Console.WriteLine("Your weight on the moon is: {0}", moonWeight);
    }
}

