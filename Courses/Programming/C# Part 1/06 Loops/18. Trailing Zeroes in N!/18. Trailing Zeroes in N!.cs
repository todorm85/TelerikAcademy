using System;
using System.Numerics;

//Problem 18.* Trailing Zeroes in N!
//• Write a program that calculates with how many zeroes the factorial
//of a given number  n  has at its end.
//• Your program should work well for very big numbers, e.g.  n=100000 .

//Examples:
//n       trailing zeroes of n!       explaination
//10      2                           3628800 
//20      4                           2432902008176640000 
//100000  24999                       think why 

class Trailing_Zeroes_in_Nfact
{
    //static void Main()
    //{
    //start:
    //    Console.Write("Enter integer: ");
    //    ulong num = ulong.Parse(Console.ReadLine());
    //    BigInteger factorial = 1;

    //    do
    //    {
    //        factorial *= num;
    //        num--;
    //    }
    //    while (num != 0);

    //    uint i = 0;
    //    BigInteger remainder = factorial % 10;

    //    if (factorial > 24)    //because the cycle doesn`t work for facotrials less than 5 and anyway they don`t have trailing zeros
    //    {
    //        while (remainder == 0)
    //        {
    //            i++;
    //            remainder = factorial % 10;
    //            factorial /= 10;
    //        }
    //        i--;
    //    }
    //    Console.WriteLine("Trailing zeros: " + i);
    //    goto start;
    //}

    static void Main()
    {
        //of course there`s a simpler method than brute force calculation
        //every time the result is multiplied by 5 and 2 (10) it gets a trailing zero,
        //we get 5 every five times, and we get 2 with every even number. So it is enough just to count all the times we get 5
        //in the fatorial calculation. We get five every five numbers. 5, 10(2*5), 15(3*5), 20(4*5), 25(5*5)...
        //we notice also that when we get a number that is a power of 5 we get more than one 5s in the factorial calculation.
        //we also have to take these into account. But first, if we need to calculate the count of numbers that can be divided by 5 from 1 to n,
        //all we need to do is divide n/5 and get the whole number. Next we will need to check for all the numbers that are the next power
        //of 5 (2^2=25). This means to check how many times we get 25 in n. n/25 will give the count of all numbers that can be divided
        //by 5 more than ones (two times). Since we already taken into account the first 5 multiplier, we only need to take into account the
        //second 5 in our final count. And so on as long as the next power of 5 that we check for is smaller than n.
        //From the above algorithm it is clear that if we first divide n/5. We get the count of the first power of 5. But we also can simply divide this result by five again,
        //instead of dividing n by the next power of 5 (5*5). Since we already divided n by 5, we can divide this result to 5 again and this is the count of all 25 multipliers in the factorial.
        //then the logic continues until the result is smaller than 5 because this will yield results smaller than 0. This means that this power of 5 we are checking is bigger than n so it is outside the range of facotrial multipliers.
        
    start:
        Console.Write("Enter integer: ");
        ulong num = ulong.Parse(Console.ReadLine());
        ulong zeroCount = 0;

        do
        {
            zeroCount += num / 5;
            num = num / 5;
        }
        while (num >= 5);
        Console.WriteLine(zeroCount);
        goto start;
    }
}
