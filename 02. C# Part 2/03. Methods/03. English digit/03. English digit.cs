using System;
////### problem 03. english digit
////* write a method that returns the last digit of given integer as an english word.

////_examples:_

////| input | output |
////|:-----:|:------:|
////| 512   | two    |
////| 1024  | four   |
////| 12309 | nine   |
class Program
{
    static void Main()
    {
        Console.Write("Enter integer: ");
        int num = int.Parse(Console.ReadLine());
        Console.WriteLine("Last digit is {0}", LastDigitWord(num));
    }

    static string LastDigitWord(int num)
    {
        num = (num > 9) ? num % 10 : num;
        switch (num)
        {
            case 0:
                return "zero";
            case 1:
                return "one";
            case 2:
                return "two";
            case 3:
                return "three";
            case 4:
                return "four";
            case 5:
                return "five";
            case 6:
                return "six";
            case 7:
                return "seven";
            case 8:
                return "eight";
            case 9:
                return "nine";
        }

        return "error";
    }
}
