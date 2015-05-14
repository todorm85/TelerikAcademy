using System;

class Program
{
    static void Main()
    {
        // Works with insanly LARGE numbers. As much as can be typed at one time on the console
        Console.Write("Enter binary: ");
        string binary = Console.ReadLine();
        string hex = Bin2Hex(binary);
        PrintHex(hex);
    }

    static string Bin2Hex(string binary)
    {
        if (binary.Length % 4 != 0)
        {
            binary = binary.PadLeft(4 - (binary.Length % 4) + binary.Length, '0');
        }

        string[] bin4DigitGroups = new string[binary.Length/4];

        for (int i = 0, j = 0; i < binary.Length; i++)
        {
            bin4DigitGroups[j] += binary[i];
            if ((i + 1) % 4 == 0) j++;
        }

        string res = "";
        for (int i = 0; i < bin4DigitGroups.Length; i++)
        {
            switch (bin4DigitGroups[i])
            {
                case "0000":
                    res += "0";
                    break;
                case "0001":
                    res += "1";
                    break;
                case "0010":
                    res += "2";
                    break;
                case "0011":
                    res += "3";
                    break;
                case "0100":
                    res += "4";
                    break;
                case "0101":
                    res += "5";
                    break;
                case "0110":
                    res += "6";
                    break;
                case "0111":
                    res += "7";
                    break;
                case "1000":
                    res += "8";
                    break;
                case "1001":
                    res += "9";
                    break;
                case "1010":
                    res += "A";
                    break;
                case "1011":
                    res += "B";
                    break;
                case "1100":
                    res += "C";
                    break;
                case "1101":
                    res += "D";
                    break;
                case "1110":
                    res += "E";
                    break;
                case "1111":
                    res += "F";
                    break;

            }
        }

        return res;
    }

    static void PrintHex(string res)
    {
        if (res.Length % 2 != 0) res = "0" + res;
        for (int i = 0; i < res.Length; i++)
        {
            Console.Write(res[i]);
            if ((res.Length - i - 1) % 2 == 0)
            {
                Console.Write(" ");
            }
        }
    }
}

