using System;


//Problem 2. Float or Double?
//Which of the following values can be assigned to a variable of type  float 
//and which to a variable of type  double :  34.567839023, 12.345, 8923.1234857, 3456.091 ?
//Write a program to assign the numbers in variables and print them to ensure no precision is lost.

class  FloatDouble
{
    static void Main()
    {
        //                                                   float                  double
        //Largest representable number                       3.4028234e+38,         1.7976931348623157e+308  
        //Smallest number without losing precision           1.1754943e-38,         2.2250738585072014e-308  
        //Smallest representable number                      1.401298464e-45        5e-324  
        //precision in decimal after the decimal point       7                      15-16
        //Mantissa bits                                      23                     52  
        //Exponent bits                                      8                      11  
        //Epsilon                                            1.1929093e-7           2.220446049250313e-16  
        
        //for the first number we use double because it has 11 significant digits that are beyond the precision of float (7)
        double a = 34.567839023;

        //here float type is enough to store all the 5 significant digits of precision
        float b = 12.345f;

        //again the same rule applies - we have more than 7 significant digits, so we use double
        double c = 8923.1234857;

        //finally we have 7 significant digits so this decimal number carries the maximum precision that can be kept by float
        float d = 3456.091f;

        Console.WriteLine("a={0}, b={1}, c={2}, d={3}",a,b,c,d);
    }
}

