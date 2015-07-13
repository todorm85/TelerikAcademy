using System;
using System.Numerics;

class SaddyKopper
{
    static void Main()
    {
        //currentNum = "99999999999999999";
        string currentNum = Console.ReadLine();
        int transformationsCount = 0;
        while (currentNum.Length >= 2 && transformationsCount <= 9)
        {
            BigInteger product = 1;
            for (int digitsToRemove = 1; digitsToRemove < currentNum.Length; digitsToRemove++)
            {
                int sum = 0;
                int searchedNumLength = currentNum.Length - digitsToRemove;
                for (int i = 0; i < searchedNumLength; i += 2)  //calc sums of digits
                {
                    int currentDigit = (int)(currentNum[i] - '0');
                    sum += currentDigit;
                }

                product *= sum;                
            }

            currentNum = product.ToString();
            transformationsCount++;
        }

        if (transformationsCount <= 9)
        {
            Console.WriteLine(transformationsCount);
        }

        Console.WriteLine(currentNum);
    }
}