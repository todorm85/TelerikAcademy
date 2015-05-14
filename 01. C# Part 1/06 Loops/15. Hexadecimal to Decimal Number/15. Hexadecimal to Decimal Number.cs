using System;

//Problem 15. Hexadecimal to Decimal Number
//• Using loops write a program that converts a hexadecimal integer number
//to its decimal form.
//• The input is entered as string. The output should be a variable of type long.
//• Do not use the built-in .NET functionality.

//Examples:
//hexadecimal         decimal
//FE                  254 
//1AE3                6883 
//4ED528CBB4          338583669684 

class Hexadecimal_to_Decimal_Number
{
    static void Main()
    {
    start:

        Console.Write("Enter number: ");

        string input = Console.ReadLine();
        long num = 0;

        for (int i = 0; i < input.Length; i++)
        {
            long currentChar = input[input.Length - 1 - i];  //assigns the ascii code value (int) to currentChar variable

            if (currentChar < 58) //ascii code range in decimal for chars 0 to 9 starts from 48 to 57
            {
                num += (currentChar - 48) * (long)Math.Pow(16, i);
            }
            else if (currentChar > 64 && currentChar < 71)  //ascii code range in decimal for letter 'A' to 'F'
            {
                num += (currentChar - 55) * (long)Math.Pow(16, i);  //this ensures that char 'A' returns the the value of 10 (in decimal), 'B' -> '11', 'C' -> 12 ... 'F'->16
            }
            else if (currentChar > 96 && currentChar < 103)  //ascii code range in decimal for letter 'a' to 'f'
            {
                num += (currentChar - 87) * (long)Math.Pow(16, i);
            }
        }

        Console.WriteLine(num);

        //no need to worry as the character code for latin letters and digits 0 to 9 are equal in Unicode and ASCII

        goto start;
    }
}
