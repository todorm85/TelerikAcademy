using System;

//Problem 14. Decimal to Binary Number
//• Using loops write a program that converts an integer number to its binary
//representation.
//• The input is entered as long. The output should be a variable of type string.
//• Do not use the built-in .NET functionality.

//Examples:
//decimal     binary
//0           0 
//3           11 
//43691       1010101010101011 
//236476736   1110000110000101100101000000 

class Decimal_to_Binary_Number
{
    static void Main()
    {
        start:

        Console.Write("Enter number: ");
        long num = long.Parse(Console.ReadLine());
        string binary = "";
        int j = 0;

        //the first cycle will run the algorithm of converting a decimal to binary number and write the resulting
        //array of '1' and '0' to the string binary
        do
        {
            binary = binary.Insert(j, Convert.ToString( num % 2) ); 
            //we use the string.insert method instead of array of characters to insert string in a string at certain position
            //the previous line inserts (num%2) string value into the binary string at character position j
            //note that first we need to convert num%2, which is integer to a string value
            //actually each string is an array of characters but the difference is that you cannot assign a value to a character at certain
            //position (called string index), this is done with arrays. But we can simply define an empty string and then use the string.insert method to achieve
            //the same functionality as if we were asssigning values to an array of characters
            num /= 2;
            j++;
            
        } while (num>0);

        string output = "";

        //the next cycle will reverse the binary string and assign it to output string, again using the string.insert method
        //we need to reverse it because the algorithm gives the sequence of '1' and '0' in reverse order
        //which means that the first remainder of deletion with 2 is actually the last number ( the least significant binary digit )
        //since we don`t know how much binary digit the number will be long we first write them to a string then reverse it
        for (int i = 0; i < j; i++)
        {
            output = output.Insert( i, Convert.ToString(binary[j - 1 - i] ) );
        }

        Console.WriteLine(output);

        //no need to worry as the character code for latin letters and digits 0 to 9 are equal in Unicode and ASCII

        goto start;

    }
}
