using System;

//Problem 12. Extract Bit from Integer
//r• Write an expression that extracts from given integer
//n  the value of given bit at index  p .
//Examples:
//n       binary representation       p       bit @ p
//5       00000000 00000101           2       1 
//0       00000000 00000000           9       0 
//15      00000000 00001111           1       1 
//5343    00010100 11011111           7       1 
//62241   11110011 00100001           11      0 

class ExtractBitFromInteger
{
    static void Main()
    {
        Console.Write("Enter an integer (-2,147,483,648 to 2,147,483,647): ");
        int num = int.Parse(Console.ReadLine());
        Console.Write("Enter bit index (0 to 31): ");
        byte bitIndex = byte.Parse(Console.ReadLine());

        num >>= bitIndex; //wee shift the bits to the right by the value of bitIndex and assign the new number to num
        num &= 1; //we use bitwise anding of num and 1, which will give the value of rightmost bit and all other bits will be zeros. Then it is assigned to num.
        
        //finally the value of num contains the value of bit at position bitIndex of the original input num value.
        Console.WriteLine(num);        
    }
}

