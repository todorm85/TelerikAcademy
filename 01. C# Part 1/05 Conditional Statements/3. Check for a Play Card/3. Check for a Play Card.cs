using System;

//Problem 3. Check for a Play Card
//• Classical play cards use the following signs to designate the card face:
//`2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K and A. Write a program that enters a string 
//and prints “yes” if it is a valid card sign or “no” otherwise.
//Examples:
//character       Valid card sign?
//5               yes 
//1               no 
//Q               yes 
//q               no 
//P               no 
//10              yes 
//500             no 

class Check_for_a_Play_Card
{
    static void Main()
    {
        Console.Write("Enter card: ");
        string input = Console.ReadLine();

        if (input == "j" || input == "J" || input == "q" || input == "Q" || input == "k" || input == "K" || input == "a" || input == "A")
        {
            Console.WriteLine("yes");
            return;
        }

        for (int i = 2; i < 11; i++)
        {
            if (input == Convert.ToString(i))
            {
                Console.WriteLine("yes");
                return;
            }

        }

        Console.WriteLine("No");
    }
}

