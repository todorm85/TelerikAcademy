using System;
//### Problem 21. Letters count
//*	Write a program that reads a string from the console and prints all different letters in the string along with information how many times each letter is found. 
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter string");
        string text = Console.ReadLine();

        while (text != "")
        {
            // get first letter and remove from text
            char letter = text[0];
            text = text.Substring(1);

            // set counter including first letter and start searching
            int letterCount = 1;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == letter)
                {
                    text = text.Remove(i, 1);   // removes letter
                    i--;    // starts next check from removed letter position
                    letterCount++;
                }
            }

            if (Char.IsLetter(letter))  // print only letters
            {
                Console.WriteLine("char: {0}, {1} times", letter, letterCount);
            }
        }
    }
}

