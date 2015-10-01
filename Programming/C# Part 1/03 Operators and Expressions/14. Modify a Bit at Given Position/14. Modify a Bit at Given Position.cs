using System;

//Problem 14. Modify a Bit at Given Position
//• We are given an integer number  n , a bit value  v  (v=0 or 1) and a position  p .
//• Write a sequence of operators (a few lines of C# code) that modifies  n  to hold 
//the value  v  at the position  p  from the binary representation of  n  while
//preserving all other bits in  n .
//Examples:
//n       binary representation of n      p       v       binary result               result
//5       00000000 00000101               2       0       00000000 00000001           1 
//0       00000000 00000000               9       1       00000010 00000000           512 
//15      00000000 00001111               1       1       00000000 00001111           15 
//5343    00010100 11011111               7       0       00010100 01011111           5215 
//62241   11110011 00100001               11      0       11110011 00100001           62241 

class ModifyBitGivenPosition
{
    static void Main()
    {
        Console.Write("Enter an integer (-2,147,483,648 to 2,147,483,647): ");
        int num = int.Parse(Console.ReadLine());
        Console.Write("Enter bit index (0 to 31): ");
        byte bitIndex = byte.Parse(Console.ReadLine());
        Console.Write("Enter bit value (0 to 31): ");
        int bitValue = byte.Parse(Console.ReadLine());

        //next we will use ternary operator to assign the value of bitValue to position bitIndex of num
        //we create masks with the integer value of 1 and bit shifting it by the value of bitIndex.
        //then we use bitwise operator | or & (depending on whether we want to change the bit value at position bitIndex to 0 or 1 in num).
        num = (bitValue == 1) ? num | (1 << bitIndex) : num & ~(1 << bitIndex);
        Console.WriteLine("Result: " + num);
    }
}

