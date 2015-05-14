using System;

//Problem 13. Binary to Decimal Number
//• Using loops write a program that converts a binary integer number to
//its decimal form.
//• The input is entered as string. The output should be a variable of type long.
//• Do not use the built-in .NET functionality.

//Examples:
//binary                          decimal
//0                               0 
//11                              3 
//1010101010101011                43691 
//1110000110000101100101000000    236476736 

class Binary_to_Decimal_Number
{
    static void Main()
    {
        start:

        Console.Write("Enter number: ");

        string input = Console.ReadLine();
        ulong num = 0;

        for (int i = 0; i < input.Length; i++)
        {
            //the next line gets the character at position input.Lenght - i -1 (starting from the last entered)
            //and then multiplies it by 2 to the power of i (starting from 0).
            //Note: input[i] returns the ascii code character number, which for '0' is integer 48, for '1' is 49 and so on... check ascii table
            //this means that if input[i] == '0', when we cast it to integer, the integer value will be character '0' ascii code number, which is 48.
            //therefore when we subtract 48 from the integer value of a digit character (0 to 9) we get its equivalent integer value
            num += (ulong)(input[input.Length - 1 - i] - 48) * (ulong)Math.Pow(2,i);
        }

        Console.WriteLine(num);

        //no need to worry as the character code for latin letters and digits 0 to 9 are equal in Unicode and ASCII

        goto start;
    }
}
