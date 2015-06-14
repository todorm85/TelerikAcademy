using System;

class PrintNums
{
    static void Main()
    {
        for (int num = 1; num < 10; num += 4)                       //cycle that increments the integer num from 1 to 9 with the addition of 4 after each cycle
        {
            Console.WriteLine("{0}", Convert.ToString(num, 2));     //converts integer num to string in base 2 numerical system and prints to the console
        }
    }
}

