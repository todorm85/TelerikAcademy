using System;

//Problem 13. Check a Bit at Given Position
//• Write a Boolean expression that returns if the bit at position
//p  (counting from  0 , starting from the right) in given integer 
//number  n , has value of 1.
//Examples:
//n       binary representation of n      p       bit @ p == 1
//5       00000000 00000101               2       true 
//0       00000000 00000000               9       false 
//15      00000000 00001111               1       true 
//5343    00010100 11011111               7       true 
//62241   11110011 00100001               11      false 

class CheckBitGivenPosition
{
    static void Main()
    {
        Console.Write("Enter an integer (-2,147,483,648 to 2,147,483,647): ");
        int num = int.Parse(Console.ReadLine());
        Console.Write("Enter bit index (0 to 31): ");
        byte bitIndex = byte.Parse(Console.ReadLine());

        //we will shift the bits to the right by the value of bitIndex and then bitwise anding with 1 will 
        //give the value of the rightmost bit in num. It will be assigned to result.
        bool result = (((num >> bitIndex) & 1) == 1);
        Console.WriteLine(result);
    }
}

