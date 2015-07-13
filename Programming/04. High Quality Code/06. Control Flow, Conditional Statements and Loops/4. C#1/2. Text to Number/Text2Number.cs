using System;

class Text2Number
{
    const int breakCharCode = (int)'@';

    const int firstDigitCode = (int)'0';
    const int lastDigitCode = (int)'9';

    const int firstCapitalLetterCode = (int)'A';
    const int lastCapitalLetterCode = (int)'Z';

    const int firstLowerLetterCode = (int)'a';
    const int lastLowerLetterCode = (int)'z';

    static void Main()
    {
        //Console.Write("Enter M: ");
        int moduleDivider = int.Parse(Console.ReadLine());
        //Console.Write("Enter string: ");
        string inputString = Console.ReadLine();

        int result = 0;
        for (int i = 0; i < inputString.Length; i++)
        {
            int currentCharCode = (int)inputString[i];
            //Console.WriteLine(currentCharCode);

            if (currentCharCode == breakCharCode)
            {
                break;
            }

            else if (firstDigitCode <= currentCharCode && currentCharCode <= lastDigitCode)
            {
                int digit = currentCharCode - firstDigitCode;
                result *= digit;
            }

            else if (firstCapitalLetterCode <= currentCharCode && currentCharCode <= lastCapitalLetterCode)
            {
                int letterNumber = currentCharCode - firstCapitalLetterCode;
                result += letterNumber;
            }

            else if (firstLowerLetterCode <= currentCharCode && currentCharCode <= lastLowerLetterCode)
            {
                int letterNumber = currentCharCode - firstLowerLetterCode;
                result += letterNumber;
            }

            else
            {
                result %= moduleDivider;
            }
        }

        Console.WriteLine(result);
    }
}