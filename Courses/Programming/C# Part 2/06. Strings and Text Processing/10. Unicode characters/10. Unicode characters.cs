using System;

//Problem 10. Unicode characters• Write a program that converts a string to a sequence of C# Unicode character literals.
//• Use format strings.
//Example:
//input       output
//Hi!         \u0048\u0069\u0021 

class Program
{
    static void Main()
    {
        // YOUR INPUT HERE!!!!!!!!!!!!!!
        string text = "Hi!";

        foreach (var item in text)
        {
            string output = String.Format("\\u{0:X4}", (int)item);
            Console.Write(output);
        }
    }
}
