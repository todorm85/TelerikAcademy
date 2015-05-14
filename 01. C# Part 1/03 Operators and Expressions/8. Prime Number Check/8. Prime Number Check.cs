using System;

//Problem 8. Prime Number Check
//• Write an expression that checks if given positive integer number
//n (n = 100) is prime (i.e. it is divisible without remainder only to itself and 1).
//Examples:
//n   Prime?
//1 false 
//2 true 
//3 true 
//4 false 
//9 false 
//97 true 
//51 false 
//-3 false 
//0 false 

class PrimeNumberCheck
{
    static void Main()
    {
        Console.Write("Enter an integer (0 to 18,446,744,073,709,551,615): ");
        ulong num = ulong.Parse(Console.ReadLine());
        //we use ulong because in the problem description we are required to check only positive numbers.
        bool result = true;

        for (ulong i = 2; i < num/2; i++)  
        //we don`t have to check for numbers bigger or equal to num/2 because it is obvious that this will give results smaller than 2.
        {
            if (num % i == 0) result = false;
        }

        if (num <= 1 || num==4) result = false;
        //By definition 1 is not a prime number although it meets the requirements. We also add the check for 4 here because it is a
        //border case. If we are to include this check in the cycle we will have to change the limit to (i<=num/2)
        //and this would add to much unneccessary checking overhead for all the other numbers greater than 4.

        Console.WriteLine(result);
    }
}

