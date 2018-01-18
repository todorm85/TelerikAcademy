using System;

class Program
{
    static void Main()
    {
        Console.BufferHeight = 800;
        for (int ctr = Convert.ToInt32(Char.MinValue); ctr <= Convert.ToInt32(Char.MaxValue); ctr++)
        {
            char ch = (Char)ctr;
            if (Char.IsPunctuation(ch))
                Console.WriteLine(@"\u{0:X4} ({1}) {2}", (int)ch, Char.GetUnicodeCategory(ch).ToString(), ch);
        }
    }
}

