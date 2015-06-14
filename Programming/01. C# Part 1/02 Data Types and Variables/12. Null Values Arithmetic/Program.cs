using System;

//Problem 12. Null Values Arithmetic
//• Create a program that assigns null values to an integer and to a double variable. 
//• Try to print these variables at the console. 
//• Try to add some number or the null literal to these variables and print the result.

class NullValuesArithmetic
{
    static void Main()
    {
        int? intVar = null;
        double? doubleVar = null;
        //the "?" after the data type represent their entire underlying value range
        //+ the nullable type value

        Console.WriteLine(intVar);
        Console.WriteLine(doubleVar);
        Console.WriteLine(intVar + 5);
        Console.WriteLine(doubleVar + 5);
        //even after addition the value of a null is still null
        intVar = 5;
        //only when explicitly assigned does the null value changes
        Console.WriteLine(intVar);
    }
}

