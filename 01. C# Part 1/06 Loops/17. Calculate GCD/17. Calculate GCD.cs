using System;

//Problem 17.* Calculate GCD
//• Write a program that calculates the greatest common divisor (GCD)
//of given two integers  a  and  b .
//• Use the Euclidean algorithm (find it in Internet).

//Examples:
//a       b       GCD(a, b)
//3       2       1 
//60      40      20 
//5       -15     5 

class Calculate_GCD
{
    static void Main()
    {
        int[] nums = new int[2];

        for (int i = 0; i < 2; i++)
        {
            Console.Write("Enter integer {0}: ", i + 1);
            nums[i] = int.Parse(Console.ReadLine());
        }

        if (nums[1] > nums[0])  //swap the numbers if second is bigger
        {
            nums[0] += nums[1];
            nums[1] = nums[0] - nums[1];
            nums[0] -= nums[1];
        }

        int numA = nums[0];
        int numB = nums[1];
        int del = 0;
        int gcd = numA % numB;

        do
        {
            del = numA % numB;
            gcd = (gcd > del) ? gcd : del;
            numA = numB;
            numB = del;
        }
        while (del != 0);

        Console.WriteLine(gcd);
    }
}
