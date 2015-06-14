using System;

//Problem 11.* Number as Words
//• Write a program that converts a number in the range [0…999] to words, corresponding to the English pronunciation.

//Examples:
//numbers         number as words
//0               Zero 
//9               Nine 
//10              Ten 
//12              Twelve 
//19              Nineteen 
//25              Twenty five 
//98              Ninety eight 
//98              Ninety eight 
//273             Two hundred and seventy three 
//400             Four hundred 
//501             Five hundred and one 
//617             Six hundred and seventeen 
//711             Seven hundred and eleven 
//999             Nine hundred and ninety nine 

class Number_as_Words
{
    static void Main()
    {
        start:
        Console.Write("Enter an integer (0 - 999): ");
        int num = int.Parse(Console.ReadLine());
        int hundreds = 0;
        int tens = 0;
        int ones = 0;
        string hundredsString = "";
        string tensString = "";
        string onesString = "";

        hundreds = num / 100;
        tens = ( num / 100 > 0) ? (num % 100) / 10 : num / 10;
        ones = num % 10;

        if (num < 20)
        {
            switch (num)
            {
                case 0:
                    Console.WriteLine("zero");
                    break;
                case 1:
                    Console.WriteLine("one");
                    break;
                case 2:
                    Console.WriteLine("two");
                    break;
                case 3:
                    Console.WriteLine("three");
                    break;
                case 4:
                    Console.WriteLine("four");
                    break;
                case 5:
                    Console.WriteLine("five");
                    break;
                case 6:
                    Console.WriteLine("six");
                    break;
                case 7:
                    Console.WriteLine("seven");
                    break;
                case 8:
                    Console.WriteLine("eight");
                    break;
                case 9:
                    Console.WriteLine("nine");
                    break;
                case 10:
                    Console.WriteLine("ten");
                    break;
                case 11:
                    Console.WriteLine("eleven");
                    break;
                case 12:
                    Console.WriteLine("twelve");
                    break;
                case 13:
                    Console.WriteLine("thirteen");
                    break;
                case 14:
                    Console.WriteLine("fourteen");
                    break;
                case 15:
                    Console.WriteLine("fifteen");
                    break;
                case 16:
                    Console.WriteLine("sixteen");
                    break;
                case 17:
                    Console.WriteLine("seventeen");
                    break;
                case 18:
                    Console.WriteLine("eighteen");
                    break;
                case 19:
                    Console.WriteLine("nineteen");
                    break;
            }

        }
        else
        {

            switch (hundreds)
            {
                case 1:
                    hundredsString = "one";
                    break;
                case 2:
                    hundredsString = "two";
                    break;
                case 3:
                    hundredsString = "three";
                    break;
                case 4:
                    hundredsString = "four";
                    break;
                case 5:
                    hundredsString = "five";
                    break;
                case 6:
                    hundredsString = "six";
                    break;
                case 7:
                    hundredsString = "seven";
                    break;
                case 8:
                    hundredsString = "eight";
                    break;
                case 9:
                    hundredsString = "nine";
                    break;
            }

            switch (tens)
            {
                case 2:
                    tensString = "twenty";
                    break;
                case 3:
                    tensString = "thirty";
                    break;
                case 4:
                    tensString = "fourty";
                    break;
                case 5:
                    tensString = "fifty";
                    break;
                case 6:
                    tensString = "sixty";
                    break;
                case 7:
                    tensString = "seventy";
                    break;
                case 8:
                    tensString = "eighty";
                    break;
                case 9:
                    tensString = "ninety";
                    break;
            }

            switch (ones)
            {
                case 1:
                    onesString = "one";
                    break;
                case 2:
                    onesString = "two";
                    break;
                case 3:
                    onesString = "three";
                    break;
                case 4:
                    onesString = "four";
                    break;
                case 5:
                    onesString = "five";
                    break;
                case 6:
                    onesString = "six";
                    break;
                case 7:
                    onesString = "seven";
                    break;
                case 8:
                    onesString = "eight";
                    break;
                case 9:
                    onesString = "nine";
                    break;
            }
            if (hundreds != 0)
            {
                Console.Write("{0} hundred", hundredsString);
            }
            if (tens != 0)
            {
                Console.Write(" and {0}", tensString);
            }
            if (ones != 0)
            {
                Console.Write(" {0}", onesString);
            }
            Console.WriteLine();
        }
        goto start;
    }
}

