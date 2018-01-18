using System;

//Problem 10. Odd and Even Product
//• You are given  n  integers (given in a single line, separated by a space).
//• Write a program that checks whether the product of the odd elements is equal
//to the product of the even elements.
//• Elements are counted from  1  to  n , so the first element is odd, the second 
//is even, etc.

//Examples:
//numbers             result
//2 1 1 6 3           yes 
//product = 6  
  
//3 10 4 6 5 1        yes 
//product = 60  
  
//4 3 2 5 2           no 
//odd_product = 16  
//even_product = 15 

class Odd_and_Even_Product
{
    static void Main()
    {
        Console.Write("Enter integers: ");
        string input = Console.ReadLine();

        string[] nums = input.Split(' ');

        int evenProduct = 1;
        int oddProduct = 1;

        for (int i = 0; i < nums.Length; i += 2)
        {
            oddProduct *= int.Parse(nums[i]);

            if (i < nums.Length - 1)
            {
                evenProduct *= int.Parse(nums[i + 1]);
            }
        }
        Console.WriteLine(oddProduct == evenProduct);
    }
}
