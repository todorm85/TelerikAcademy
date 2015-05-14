using System;

//Problem 8. Isosceles Triangle
//• Write a program that prints an isosceles triangle of 9 copyright symbols  © , something like this:
//   ©

//  © ©

// ©   ©

//© © © ©
//Note: The  ©  symbol may be displayed incorrectly at the console so you may need to change the console
//character encoding to  UTF-8  and assign a Unicode-friendly font in the console.
//Note: Under old versions of Windows the  ©  symbol may still be displayed incorrectly, 
//regardless of how much effort you put to fix it.

class IsoscelesTriangle
{
    static void Main()
    {
        //first we set the console output encoding to Unicode
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        //then we assign the copyright symbol unicode hex code to the variable c 
        char c = '\u00a9';

        //following are the 4 lines that write the triangle
        Console.WriteLine("   "+ c + "   ");
        Console.WriteLine("  "+c+" "+c+"  ");
        Console.WriteLine(" "+c+"   "+c+" ");
        Console.WriteLine("{0} {0} {0} {0}",c);
    }
}

