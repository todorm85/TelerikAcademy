using System;

//Problem 9. Exchange Variable Values
//• Declare two integer variables  a  and  b  and assign them with  5  and  10 
//and after that exchange their values by using some programming logic.
//• Print the variable values before and after the exchange.

class ExchangeVariableValues
{
    static void Main()
    {
        int a = 5;
        int b = 10;

        a = a + b;          //this assigns a new value to a: a + b;
        b = a - b;          //this assigns b = a + b - b, so b is assigned the initial value of a;
        a = a - b;          //finally a = a - b = (a + b) - a, in first line we assigned a = a + b,  
                            //and in the second line we assigned to b the initial value of a

        Console.WriteLine("a={0} b={1}",a,b);
    }
}

