using System;

//Problem 1. Odd or Even Integers
//• Write an expression that checks if given integer is odd or even.
//Examples:
//n Odd?
//3 true 
//2 false 
//-2 false 
//-1 true 
//0 false 


class OddOrEvenIntegers
{
    static void Main()
    {
        Console.Write("Enter an integer: ");
        int num = int.Parse(Console.ReadLine());

        //The first two lines print a request to the user and read the typed value.
        //The int.Parse() method converts the array of characters that are entered to an integer value.
        //This value is then assigned to the integer variable num.

        string result = (num % 2 == 0) ? "even" : "odd";

        //This is the actual expression that checks
        //if the number is even or odd. It is a
        //conditional operator with the expression
        //num%2==0 as the condition. If the condition
        //is met the first value "even" is assigned to
        //result, else the second - "odd".

        Console.WriteLine("Number is {0}", result);

        //this line prints the result to the console.
    }
}

