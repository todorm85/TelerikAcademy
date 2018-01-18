using System;

//Problem 4. Rectangles
//• Write an expression that calculates rectangle’s perimeter and area by given width and height.
//Examples:
//width    height     perimeter       area
//3        4          14              12 
//2.5      3          11              7.5 
//5        5          20              25 


class Rectangles
{
    static void Main()
    {
        Console.Write("Enter rectangle width: ");
        double width = double.Parse(Console.ReadLine());
        Console.Write("Enter rectangle height: ");
        double height = double.Parse(Console.ReadLine());

        Console.Write("\nRectangle perimiter is: ");
        Console.WriteLine(2*width+2*height);
        Console.Write("Rectangle area is: ");
        Console.WriteLine(width * height);
    }
}

