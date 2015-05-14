using System;

//Problem 13.* Comparing Floats
//• Write a program that safely compares floating-point numbers (double) with precision  eps = 0.000001 .

//Note: Two floating-point numbers  a  and  b  cannot be compared directly by  a == b  
//because of the nature of the floating-point arithmetic. Therefore, we assume two numbers 
//are equal if they are more closely to each other than a fixed constant  eps .

//5.3 6.01 false The difference of 0.71 is too big (> eps) 
//5.00000001 5.00000003 true The difference 0.00000002 < eps 
//5.00000005 5.00000001 true The difference 0.00000004 < eps 
//-0.0000007 0.00000007 true The difference 0.00000077 < eps 
//-4.999999 -4.999998 false Border case. The difference 0.000001 == eps. We consider the numbers are different. 
//4.999999 4.999998 false Border case. The difference 0.000001 == eps. We consider the numbers are different. 

class  ComparingFloats
{
    static void Main()
    {
        Console.Write("Enter number 1:");
        double num1 = double.Parse(Console.ReadLine());
        Console.Write("Enter number 2:");
        double num2 = double.Parse(Console.ReadLine());
        //the initial code lines print the requests
        //and then read the input values to the console
        //for the two numbers: num1 and num2

        double eps = 0.000001;
        //next we define the accuracy toleranse value eps
        bool result;
        //a boolean value will store the result

        result = Math.Abs(num1 - num2) < eps;
        //basically this statement assigns the result of the boolean operation
        //which will be true if the absolute value of the subtraction of the two numbers
        //is less than eps and false if bigger or equal

        Console.WriteLine(result);

        //keep in mind that this method has certain limitations:
        //if we are comapring numbers that are smaller than the epsilon defined it will not work
        //for example: 3.15e-10 and 4.15e-10 - their absolute difference is 1.0e-10 which is smaller than 1.0e-7
        //but it is obvious that they are not meant to be equal in terms of significant digits
        //for more info check: http://www.cprogramming.com/tutorial/floating_point/understanding_floating_point_representation.html
    }
}

