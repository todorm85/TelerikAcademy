using System;

//Problem 12.* Zero Subset
//• We are given 5 integer numbers. Write a program that finds all subsets of these numbers whose sum is 0.
//• Assume that repeating the same subset several times is not a problem.

//Examples:
//numbers         result
//3 -2 1 1 8      -2 + 1 + 1 = 0 

//3 1 -7 35 22    no zero subset 

//1 3 -4 -2 -1    1 + -1 = 0 
//                1 + 3 + -4 = 0 
//                3 + -2 + -1 = 0 

//1 1 1 -1 -1     1 + -1 = 0 
//                1 + 1 + -1 + -1 = 0 

//0 0 0 0 0       0 + 0 + 0 + 0 + 0 = 0 

//Hint: you may check for zero each of the 32 subsets with 32  if  statements.

class Zero_Subset
{
    static void Main()
    {
        int[] num = new int[5];

        for (int i = 0; i < 5; i++)
        {
            Console.Write("Enter integer {0}: ", i + 1);
            num[i] = int.Parse(Console.ReadLine());
        }

        int sum = 0;

        //the next sequence of cycles makes sure that the sum of the members of all possible combinations are checked.
        //Every possible combination consisting of 2 to the maximum of all 5 available members are checked without repeating the members.
        //This means that if we have combination of 3 members from 5, all possible combinations without repeating the members are 5*4*3 = 120 ( !n/!(n-k) = !5/!2 )
        //If we were to repeat the members then the combinations will be 5*5*5 = 125 (5^3)
        //the problem with this algorithm is that most combinations consist of the same members but in different order
        //which will results in duplication of unique combinations of output values.
        //But the problem is considered solved because it is stated in the task to assume that repeating the same subset (combination) several times is not a problem.
        for (int a = 0; a < 5; a++)
        {
            sum = num[a];

            for (int b = 0; b < 5; b++)     //this nested cycle will check for combinations of 2 numbers
            {
                if (b != a)  //makes sure that we are not repeating the same member of 5 numbers
                {
                    sum = num[a] + num[b];  //this is the sum for the current combination. We can`t use "sum += num[b];", because this will not discard incremented values (if any) from next cycles - num[c],num[d],num[e]

                    if (sum == 0)
                    {
                        Console.WriteLine("{0} {1} = {2}", num[a], num[b], num[a]+num[b]);
                        continue; //ok, we found one combination (subset) of two numbers that equals 0, lets move on to the next combination of two numbers
                    }
                }
                else continue; //so the current combination of 2 unique numbers is not equal to 0, lets try combinations of 3 numbers, two of which are the current two numbers

                for (int c = 0; c < 5; c++) //this nested cycle will check for combinations of 3 numbers and so on...
                {
                    if (c != b && c != a)
                    {
                        sum = num[a] + num[b] + num[c];

                        if (sum == 0)
                        {
                            Console.WriteLine("{0} {1} {2} = {3}", num[a], num[b], num[c], num[a] + num[b] + num[c]);
                            continue;
                        }
                    }
                    else continue;

                    for (int d = 0; d < 5; d++)
                    {
                        if (d != b && d != a && d != c)
                        {
                            sum = num[a] + num[b] + num[c] + num[d];

                            if (sum == 0)
                            {
                                Console.WriteLine("{0} {1} {2} {3} = {4}", num[a], num[b], num[c], num[d], num[a] + num[b] + num[c] + num[d]);
                                continue;
                            }
                        }
                        else continue;

                        for (int e = 0; e < 5; e++)
                        {
                            if (e != a && e != b && e != c && e != d)
                            {
                                sum += num[e];
                                if (sum == 0)
                                {
                                    Console.WriteLine("{0} {1} {2} {3} {4} = {5}", num[a], num[b], num[c], num[d], num[e], num[a] + num[b] + num[c] + num[d] + num[e]);
                                }
                                sum -= num[e];
                            }
                        }
                    }
                }
            }
        }
        //there is one border case: When all numbers are 0, the algorithm will not bother to check and display all possible combinations of more than 2 members.
        //Instead it will check and display only all the combinations of 2 members. We have combination of 2 numbers from 5 possilbe zero numbers,
        //which gives 5*4 different combinations which will display 20 possible combinations (subsets) of 2 numbers. It will print 20 times "0 0 = 0"
    }
}

