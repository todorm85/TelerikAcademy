using System;

//Problem 3. Divide by 7 and 5
//• Write a Boolean expression that checks for given integer 
//if it can be divided (without remainder) by  7  and  5  at the same time.
//Examples:
//n      Divided by 7 and 5?
//3 false 
//0 false 
//5 false 
//7 false 
//35 true 
//140 true 


class DivideBy7And5
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine());

        //First two lines prompt for and read a user input to the console
        //int.Parse converts the input array of chars into an integer value

        bool result = ((num % 5 == 0) && (num % 7 == 0));

        //this checks whether both ((num % 5 == 0) && (num % 7 == 0)) are true
        //and assigns the result value to the variable result

        Console.WriteLine("The number is devisible by 7 and 5 : {0}", result);
    }
}

