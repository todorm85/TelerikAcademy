using System;

//Problem 16. Decimal to Hexadecimal Number
//• Using loops write a program that converts an integer number to its
//hexadecimal representation.
//• The input is entered as long. The output should be a variable of type string.
//• Do not use the built-in .NET functionality.

//Examples:
//decimal         hexadecimal
//254             FE 
//6883            1AE3 
//338583669684    4ED528CBB4 

class Decimal_to_Hexadecimal_Number
{
    static void Main()
    {
        start:

        Console.Write("Enter number: ");
        long input = long.Parse(Console.ReadLine());
        int i = 0;
        char[] digits = new char[18];   //this is the array that will hold the digits. it is coprised of 18 maximum digits
        //which is the equivalent of the maximum of 64 bit binary number

        do
        {
            digits[i] = (input % 16 >= 10) ? (char)((input % 16) + 55) : (char)((input % 16) + 48);
            //again as in previous problem we use ascii character code values to convert the integer remainder to character symbol
            //and then assign this symbol to the current character array member
            input /= 16;
            i++;
        } 
        while (input>0);

        //now all we need is a cycle that will print the characters in the array in reverse sequence
        for (int j = 0; j < i; j++)
        {
            Console.Write(digits[i - 1 - j]);
        }

        Console.WriteLine();

        //no need to worry as the character code for latin letters and digits 0 to 9 are equal in Unicode and ASCII

        goto start;
    }
}
