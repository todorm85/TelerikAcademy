using System;
//### Problem 15. Prime numbers
//*	Write a program that finds all prime numbers in the range [`1...10 000 000`]. Use the [Sieve of Eratosthenes](http://en.wikipedia.org/wiki/Sieve_of_Eratosthenes) algorithm.
class Program
{
    static void Main()
    {
        int n = 10000000+1; //including the zero, we assume the first member of array to be number 0
        int[] arr = new int[n];

        for (int idx = 0; idx < n; idx++)   //assign arr[0]=0, arr[1]=1......
        {
            arr[idx] = idx;
        }

        int currentPrime = 2;

        while (true)    //the Eratosthenes algorithm
        {
            int i = 2;

            while (currentPrime * i < n)    //start marking non primes as 0
            {
                arr[currentPrime*i] = 0;
                i++;
            }

            bool isFinished = true;
            i = currentPrime;

            while (i < n/2) //start searching for next prime
            {
                i++;
                if (arr[i] != 0) { currentPrime = i; isFinished = false; break; }
            }

            if (isFinished) break;  //if next prime not found exit loop
        }

        for (int i = 2; i <= 10000000; i++)  //printing to console takes time
        {
            if (arr[i] != 0) Console.WriteLine(arr[i]);
        }
    }
}

