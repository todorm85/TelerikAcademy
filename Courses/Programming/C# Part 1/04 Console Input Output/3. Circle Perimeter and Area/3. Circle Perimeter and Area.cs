using System;

//Problem 3. Circle Perimeter and Area
//• Write a program that reads the radius  r  of a circle and prints 
//its perimeter and area formatted with  2  digits after the decimal point.

//Examples:
//r       perimeter       area
//2       12.57           12.57 
//3.5     21.99           38.48 

class Circle_Perimeter_and_Area
{
    static void Main()
    {
        Console.Write("Enter radius ( (+/-)5.0 x 10e-324 to (+/-)1.7 x 10e+308 ): ");
        double r = double.Parse(Console.ReadLine());

        Console.WriteLine("Circle perimeter is {0:0.00}", (3.14159 * r * 2));
        Console.WriteLine("Circle area is {0:0.00}", (3.14159 * r * r));
    }
}

