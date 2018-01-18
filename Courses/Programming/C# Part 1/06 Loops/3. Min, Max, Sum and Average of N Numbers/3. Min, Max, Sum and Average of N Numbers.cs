using System;

//Problem 3. Min, Max, Sum and Average of N Numbers
//• Write a program that reads from the console a sequence of  n  integer numbers and returns 
//the minimal, the maximal number, the sum and the average of all numbers (displayed with 2 digits after the decimal point).
//• The input starts by the number  n  (alone in a line) followed by  n  lines, each holding an integer number.
//• The output is like in the examples below.

//Example 1:
//input       output
//3           min = 1 
//2           max = 5 
//5           sum = 8 
//1           avg = 2.67 

//Example 2:
//input       output
//2           min = -1 
//-1          max = 4 
//4           sum = 3 
//            avg = 1.50 

class Min_Max_Sum_and_Average_of_N_Numbers
{
    static void Main()
    {
        Console.Write("Enter count of numbers (0 to 4,294,967,295): ");
        uint n = uint.Parse(Console.ReadLine());
        uint min = uint.MaxValue;
        uint max = uint.MinValue;
        uint sum = 0;
        double average = 0;

        for (uint i = 0; i < n; i++)
        {
            Console.Write("Enter integer i (-2,147,483,648 to 2,147,483,647): ");
            uint num = uint.Parse(Console.ReadLine());

            min = Math.Min(min, num);
            max = Math.Max(max, num);
            sum += num;
        }

        average = sum / (double)n;  
        //we need to cast at least one of the members of the expression to double so that
        //the calculation takes place in floating point, otherwise we will get an integer result after the calculation
        //and then it will be casted to double, which will lose all precision after the decimal point.

        Console.WriteLine("min= {0}, max= {1}, sum= {2}, average= {3:0.00}", min, max, sum, average);
    }
}

