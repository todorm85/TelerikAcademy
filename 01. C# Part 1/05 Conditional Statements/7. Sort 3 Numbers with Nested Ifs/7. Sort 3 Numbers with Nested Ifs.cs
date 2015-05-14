using System;

//Problem 7. Sort 3 Numbers with Nested Ifs
//• Write a program that enters 3 real numbers and prints them sorted in descending order. ◦ Use nested  if  statements.
//Note: Don’t use arrays and the built-in sorting functionality.
//Examples:
//a       b       c       result
//5       1       2       5 2 1 
//-2      -2      1       1 -2 -2 
//-2      4       3       4 3 -2 
//0       -2.5    5       5 0 -2.5 
//-1.1    -0.5    -0.1    -0.1 -0.5 -1.1 
//10      20      30      30 20 10 
//1       1       1       1 1 1 

class Sort_3_Numbers_with_Nested_Ifs
{
    static void Main()
    {
    start:
        Console.Write("Enter number ( (+/-)5.0 x 10e-324 to (+/-)1.7 x 10e+308 ): ");
        double num1 = double.Parse(Console.ReadLine());
        Console.Write("Enter number ( (+/-)5.0 x 10e-324 to (+/-)1.7 x 10e+308 ): ");
        double num2 = double.Parse(Console.ReadLine());
        Console.Write("Enter number ( (+/-)5.0 x 10e-324 to (+/-)1.7 x 10e+308 ): ");
        double num3 = double.Parse(Console.ReadLine());

        //it is not the easiest way with nested ifs, but that`s what we are instructed in the task to do
        
        if (num1 < num2)
        {
            if (num1 < num3)
            {

                if (num2 < num3)
                {
                    Console.WriteLine(num3 + " " + num2 + " " + num1);
                }
                else
                {
                    Console.WriteLine(num2 + " " + num3 + " " + num1);
                }
            }
            else
            {
                Console.WriteLine(num2 + " " + num1 + " " + num3);
            }

        }

        else
        {
            if (num1 > num3)
            {
                if (num3 > num2)
                {
                    Console.WriteLine(num1 + " " + num3 + " " + num2);
                }
                else
                {
                    Console.WriteLine(num1 + " " + num2 + " " + num3);
                }
            }
            else
            {
                Console.WriteLine(num3 + " " + num1 + " " + num2);
            }
        }
        goto start;
    }
}

