using System;
//### Problem 01. Say Hello
//*	Write a method that asks the user for his name and prints `�Hello, <name>�`
//*	Write a program to test this method.

//_Example:_

//| input |     output    |
//|:-----:|:-------------:|
//| Peter | Hello, Peter! |
class SayHello01
{
    static void Main()
    {
        Console.Write("Enter name: ");
        string input = Console.ReadLine();
        Console.WriteLine(   SayHello(input));
        if (test())
            Console.WriteLine("Test success!");

    }

    static string SayHello(string inString)
    {
        return "Hello, " + inString;
    }

    static bool test()
    {
        if (SayHello("Test") == "Hello, Test")
            return true;
        else
            return false;
    }
}

