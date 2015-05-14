using System;

//Problem 9. Trapezoids
//• Write an expression that calculates trapezoid's
//area by given sides  a  and  b  and height  h .
//Examples:
//a       b       h       area
//5       7       12      72 
//2       1       33      49.5 
//8.5     4.3     2.7     17.28 
//100     200     300     45000 
//0.222   0.333   0.555   0.1540125 

class Trapezoids
{
    static void Main()
    {
        Console.Write("Enter side a ( (+/-)5.0 x 10-324 to (+/-)1.7 x 10308 ): ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter side b ( (+/-)5.0 x 10-324 to (+/-)1.7 x 10308 ): ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Enter height h ( (+/-)5.0 x 10-324 to (+/-)1.7 x 10308 ): ");
        double h = double.Parse(Console.ReadLine());

        Console.WriteLine("Trapezoid area is: " + (a+b)/2*h);
    }
}

