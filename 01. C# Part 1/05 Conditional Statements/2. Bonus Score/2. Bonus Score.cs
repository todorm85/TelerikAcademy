using System;

//Problem 2. Bonus Score
//• Write a program that applies bonus score to given score in the range  [1…9]  
//by the following rules: ◦ If the score is between  1  and  3 , the program multiplies it by  10 .
//◦ If the score is between  4  and  6 , the program multiplies it by  100 .
//◦ If the score is between  7  and  9 , the program multiplies it by  1000 .
//◦ If the score is  0  or more than  9 , the program prints  “invalid score” .

//Examples:
//score       result
//2           20 
//4           400 
//9           9000 
//-1          invalid score 
//10          invalid score 

class Bonus_Score
{
    static void Main()
    {
        Console.Write("Enter score ( (+/-)5.0 x 10e-324 to (+/-)1.7 x 10e+308 ): ");
        double num = double.Parse(Console.ReadLine());

        if (num <= 3 && num >= 1) { num *= 10; }
        else if (num >= 4 && num <= 6) { num *= 100; }
        else if (num >= 7 && num <= 9) { num *= 1000; }

        else { Console.WriteLine("invalid score"); return; }

        Console.WriteLine(num);
    }
}

