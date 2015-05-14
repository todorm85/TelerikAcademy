using System;
//### Problem 4. Triangle surface
//*	Write methods that calculate the surface of a triangle by given:
//    *	Side and an altitude to it;
//    *	Three sides;
//    *	Two sides and an angle between them;
//*	Use `System.Math`.
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter side: ");
        double side1 = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter altitude: ");
        double altitude = double.Parse(Console.ReadLine());
        Console.WriteLine(   TriangleSurface(side1, altitude));

        Console.WriteLine("\nEnter side1: ");
        side1 = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter side2: ");
        double side2 = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter side3: ");
        double side3 = double.Parse(Console.ReadLine());
        Console.WriteLine(TriangleSurface(side1,side2,side3));

        Console.WriteLine("\nEnter side1: ");
        side1 = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter side1: ");
        side2 = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter angle (radians): ");
        int angle = int.Parse(Console.ReadLine());
        Console.WriteLine(TriangleSurface(side1,side2,angle));
    }

    private static double TriangleSurface (double side, double altitude)
    {
        return side * altitude / 2;
    }

    private static double TriangleSurface (double side1, double side2, double side3)
    {
        // hero`s formula
        double s = (side1 + side2 + side3) / 2;
        double area = Math.Sqrt(s * (s - side1) * (s - side2) * (s - side3));
        return area;
    }

    private static double TriangleSurface (double side1, double side2, int angle)
    {
        double area = (side1 * side2 * Math.Sin(angle)) / 2;
        return area;
    }
}

