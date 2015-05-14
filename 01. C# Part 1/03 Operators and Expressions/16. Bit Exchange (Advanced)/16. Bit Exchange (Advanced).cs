using System;

//Problem 16.** Bit Exchange (Advanced)
//• Write a program that exchanges bits  {p, p+1, …, p+k-1}  
//with bits  {q, q+1, …, q+k-1}  of a given 32-bit unsigned integer.
//• The first and the second sequence of bits may not overlap.
//Examples:
//n           p       q       k       binary representation of n              binary result                           result
//1140867093  3       24      3       01000100 00000000 01000000 00010101     01000010 00000000 01000000 00100101     1107312677 
//4294901775  24      3       3       11111111 11111111 00000000 00001111     11111001 11111111 00000000 00111111     4194238527 
//2369124121  2       22      10      10001101 00110101 11110111 00011001     01110001 10110101 11111000 11010001     1907751121 
//987654321   2       8       11      -                                       -                                       overlapping 
//123456789   26      0       7       -                                       -                                       out of range 
//33333333333 -1      0       33      -                                       -                                       out of range 

class BitExchangeAdvanced
{
    static void Main()
    {
        //First we read the input values from the console

        Console.Write("Enter number n: ");
        string numInput = Console.ReadLine();
        uint num = 0;

        Console.Write("Enter bit p: ");
        string pInput = Console.ReadLine();
        byte p = 0;

        Console.Write("Enter bit q: ");
        string qInput = Console.ReadLine();
        byte q = 0;

        Console.Write("Enter range k: ");
        string kInput = Console.ReadLine();
        byte k = 0;

        //next we use a few if statements to check whether the input valids are valid

        //first if stetment checks whether the input is in the valid range of the data types using Try.Parse, which returns true or false

        if (!(uint.TryParse(numInput, out num) && byte.TryParse(pInput, out p) && byte.TryParse(qInput, out q) && byte.TryParse(kInput, out k)))
        {
            Console.WriteLine("Out of range!!!!!!! Invalid input values, possibly too big or too small or not integers!");
        }
        
        //next if stetment checks whether the bit ranges overlap

        else if (Math.Abs(p - q) < k)
        {
            Console.WriteLine("Overlapping bit ranges!!!!!!");
        }

        //next if checks whether the ranges fall out of the valid 0-31 bit range of the integer

        else if ((p + k - 1 > 31) || (q + k - 1 > 31))
        {
            Console.WriteLine("Exchange bits out of range!!!!!!");
        }

        //if all the conditions above are false we move on to the else statement which is the workhorse of the method

        else
        {
            //first we define the resulting variable resultNum value equal to the entered value for variable num
            uint resultNum = num;

            //the following for cycle checks the bit value of num at position p+i and puts it in position q+i in resultNum
            for (int i = 0; i < k; i++)
            {
                resultNum = (((num >> (p + i)) & 1) == 1) ? ((uint)(1 << (q + i)) | resultNum) : ((uint)(~(1 << (q + i))) & resultNum);
            }

            //next for cycle does the opposite - checks bit value at q+i of num and puts it in position p+i in resultNum
            for (int i = 0; i < k; i++)
            {
                resultNum = (((num >> q + i) & 1) == 1) ? ((uint)(1 << (p + i)) | resultNum) : ((uint)(~(1 << (p + i))) & resultNum);
            }

            //when we define the mask`s value we need to use casting (uint) in front of the values assigned, because by default
            //they are considered integer int, not unsigned integers - uint. And the variable resultNum is of type unsigned uint.

            Console.WriteLine("Result is " + resultNum);
            Console.WriteLine(Convert.ToString(num, 2).PadLeft(32, '0'));
            Console.WriteLine(Convert.ToString(resultNum, 2).PadLeft(32, '0'));
        }
    }
}

