using System;

//Problem 14.* Print the ASCII Table
//• Find online more information about ASCII (American Standard Code for Information Interchange) 
//and write a program that prints the entire ASCII table of characters on the console (characters from 0 to 255).

class PrintTheASCIITable
{
    static void Main()
    {

        //this is a simple code block that uses a for statment
        //to print the first 256 characters of the ASCII table

        for (int i = 0; i < 256; i++)
        {
            char a = (char)i; 
            //we define the variable a with the integer value of the iteration i
            //casted to character code number (the value of i is the ASCII code decimal number)
            //this is an easier method than using escape characters
            Console.WriteLine(a);
        }
    }
}

