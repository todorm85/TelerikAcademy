using System;
//### Problem 07. Encode/decode
//*	Write a program that encodes and decodes a string using given encryption key (cipher).
//*	The key consists of a sequence of characters. 
//*	The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter of the string with the first of the key, the second � with the second, etc. When the last key character is reached, the next is the first.
class Program
{
    static void Main()
    {
        Console.Write("Enter text: ");
        string text = Console.ReadLine();
        Console.Write("Enter key: ");
        string key = Console.ReadLine();

        string encoded = "";
        for (int i = 0, j=0; i < text.Length; i++,j++)
        {
            if (j >= key.Length) j = 0;
            encoded += (char)(text[i] ^ key[j]);
        }

        Console.WriteLine("Endocded = " + encoded);

        string decoded = "";
        for (int i = 0, j = 0; i < encoded.Length; i++, j++)
        {
            if (j >= key.Length) j = 0;
            decoded += (char)(encoded[i] ^ key[j]);
        }

        Console.WriteLine("Decoded = " + decoded);
    }
}

