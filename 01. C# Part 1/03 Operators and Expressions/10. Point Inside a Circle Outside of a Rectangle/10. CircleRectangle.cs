using System;

//Problem 10. Point Inside a Circle & Outside of a Rectangle
//• Write an expression that checks for given point (x, y) if
//it is within the circle  K({1, 1}, 1.5)  and out of the rectangle
//R(top=1, left=-1, width=6, height=2) 
//Examples:
//x       y       inside K & outside of R
//1       2       yes 
//2.5     2       no 
//0       1       no 
//2.5     1       no 
//2       0       no 
//4       0       no 
//2.5     1.5     no 
//2       1.5     yes 
//1       2.5     yes 
//-100    -100    no 

class CircleRectangle
{
    static void Main()
    {
        Console.Write("Enter X ( (+/-)5.0 x 10-324 to (+/-)1.7 x 10308 ): ");
        double x = double.Parse(Console.ReadLine());
        Console.Write("Enter Y ( (+/-)5.0 x 10-324 to (+/-)1.7 x 10308 ): ");
        double y = double.Parse(Console.ReadLine());

        x--;
        y--;
        bool inCircle = (Math.Sqrt(x * x + y * y) <= 1.5);
        x++;
        y++;

        //we need to find out whether the distande between the circle center and the point is smaller than the radius.
        //To do that we subtract the x and y coordinates of the circle center point{1,1} and our point{x,y}.
        //To simplify the code first we assign new values to x and y which are the coordinate deltas of the two points.
        //Then we use the Pitagor`s theorem to calculate the distance between circle center point and our point.
        //Finally we restore the original x and y values.

        bool outRect = ((Math.Abs(y) > 1) || (x > 5) || (x < -1));

        //the top left point of the rectangle has coordinates x=-1 and y=1.
        //Next we need to check whether any one of the point`s coordinates is outside
        //the range of the rectangle which is (y: -1 to 1, x: -1 to 5)
        //math.abs takes an absolute value (modulus)

        Console.WriteLine(inCircle&&outRect); 
        
        //Finally we check whether both conditions are met at the same time.
    }
}

