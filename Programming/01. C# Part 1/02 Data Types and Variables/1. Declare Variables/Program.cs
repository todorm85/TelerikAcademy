using System;

//Problem 1. Declare Variables. 
//Declare five variables choosing for each of them 
//the most appropriate of the types  byte, sbyte, short, ushort, int, uint, long, ulong 
//to represent the following values:  52130, -115, 4825932, 97, -10000 .
//Choose a large enough type for each number to ensure it will fit in it. Try to compile the code.

class DeclareVariables
{
    static void Main()
    {
        //unsigned short delivers a range of 0:65535
        ushort a = 52130;
        //signed byte variable has a range of -128:127
        sbyte b = -115;
        //signed integer has a range of -2147483648:2147483647
        int c = 4825932;
        //with its 8bits available unsugned byte has 0:255 totalling 256 possible values
        byte d = 97;
        //signed short is capable of holding values in the range of -65536:65535
        short e = -10000;
    }
}

