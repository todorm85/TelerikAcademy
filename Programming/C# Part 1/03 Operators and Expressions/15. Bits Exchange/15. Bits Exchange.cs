using System;

//Problem 15.* Bits Exchange
//• Write a program that exchanges bits  3 ,  4  and  5  with bits
//24 ,  25  and  26  of given 32-bit unsigned integer.
//Examples:
//n               binary representation of n                      binary result                           result
//1140867093      01000100 00000000 01000000 00010101             01000010 00000000 01000000 00100101     1107312677 
//255406592       00001111 00111001 00110010 00000000             00001000 00111001 00110010 00111000     137966136 
//4294901775      11111111 11111111 00000000 00001111             11111001 11111111 00000000 00111111     4194238527 
//5351            00000000 00000000 00010100 11100111             00000100 00000000 00010100 11000111     67114183 
//2369124121      10001101 00110101 11110111 00011001             10001011 00110101 11110111 00101001     2335569705 

class BitsExchange
{
    static void Main()
    {        
        Console.Write("Enter an integer (0 to 4,294,967,295): ");
        uint num = uint.Parse(Console.ReadLine());
        uint resultNum = num;

        //the following tree lines check the bit value at position 3,4,5 in num and assign them to 24,25,26 in resultNum
        resultNum = (((num >> 3) & 1) == 1) ? (uint)((1 << 24) | resultNum) : (uint)((~(1 << 24)) & resultNum);
        resultNum = (((num >> 4) & 1) == 1) ? (uint)((1 << 25) | resultNum) : (uint)((~(1 << 25)) & resultNum);
        resultNum = (((num >> 5) & 1) == 1) ? (uint)((1 << 26) | resultNum) : (uint)((~(1 << 26)) & resultNum);

        //the following tree lines check the bit value at position 24,25,26 in num and assign them to 3,4,5  in resultNum
        resultNum = (((num >> 24) & 1) == 1) ? (uint)((1 << 3) | resultNum) : (uint)((~(1 << 3)) & resultNum);
        resultNum = (((num >> 25) & 1) == 1) ? (uint)((1 << 4) | resultNum) : (uint)((~(1 << 4)) & resultNum);
        resultNum = (((num >> 26) & 1) == 1) ? (uint)((1 << 5) | resultNum) : (uint)((~(1 << 5)) & resultNum);

        //when we define the mask`s value we need to use casting (uint) in front of the values assigned, because by default
        //they are considered integer int, not unsigned integers - uint. And the variable resultNum is of type unsigned uint.

        Console.WriteLine("Result is " + resultNum);
        Console.WriteLine(Convert.ToString(num,2).PadLeft(32,'0'));
        Console.WriteLine(Convert.ToString(resultNum, 2).PadLeft(32,'0'));
    }
}

