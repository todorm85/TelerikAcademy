using System;

class Program
{
    static void Main()
    {
        // Works with insanly LARGE numbers. As much as can be typed at one time on the console
        Console.Write("Enter hex: ");
        string hex = Console.ReadLine();
        Console.WriteLine(Hex2Bin(hex));
    }

    static string Hex2Bin(string hex)
    {
        string res = "";
        for (int i = 0; i < hex.Length; i++)
        {
            switch (hex[i])
            {
                case 'f':
                case 'F':
                    res += "1111 ";
                    break;
                case 'e':
                case 'E':
                    res += "1110 ";
                    break;
                case 'd':
                case 'D':
                    res += "1101 ";
                    break;
                case 'c':
                case 'C':
                    res += "1100 ";
                    break;
                case 'b':
                case 'B':
                    res += "1011 ";
                    break;
                case 'a':
                case 'A':
                    res += "1010 ";
                    break;
                case '9':
                    res += "1001 ";
                    break;
                case '8':
                    res += "1000 ";
                    break;
                case '7':
                    res += "0111 ";
                    break;
                case '6':
                    res += "0110 ";
                    break;
                case '5':
                    res += "0101 ";
                    break;
                case '4':
                    res += "0100 ";
                    break;
                case '3':
                    res += "0011 ";
                    break;
                case '2':
                    res += "0010 ";
                    break;
                case '1':
                    res += "0001 ";
                    break;
                case '0':
                    res += "0000 ";
                    break;
            }
        }

        return res;
    }
}

