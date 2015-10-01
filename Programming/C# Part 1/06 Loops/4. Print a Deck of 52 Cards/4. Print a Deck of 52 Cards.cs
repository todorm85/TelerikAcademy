using System;

//Problem 4. Print a Deck of 52 Cards
//• Write a program that generates and prints all possible cards from a standard
//deck of 52 cards (without the jokers). The cards should be printed using the 
//classical notation (like 5 of spades, A of hearts, 9 of clubs; and K of diamonds).
//◦ The card faces should start from 2 to A.
//◦ Print each card face in its four possible suits: clubs, diamonds, hearts and 
//spades. Use 2 nested for-loops and a switch-case statement.

//output
//2 of spades, 2 of clubs, 2 of hearts, 2 of diamonds
//3 of spades, 3 of clubs, 3 of hearts, 3 of diamonds
//…  
//K of spades, K of clubs, K of hearts, K of diamonds
//A of spades, A of clubs, A of hearts, A of diamonds

//Note: You may use the suit symbols instead of text.

class Print_a_Deck_of_52_Cards
{
    static void Main()
    {
        for (int i = 2; i <= 10; i++)
        {
            Console.WriteLine("{0,2} of \u2660, {0,2} of \u2665, {0,2} of \u2666, {0,2} of \u2663", i);
        }
        string card = "J";
        Console.WriteLine("{0,2} of \u2660, {0,2} of \u2665, {0,2} of \u2666, {0,2} of \u2663", card);
        card = "Q";
        Console.WriteLine("{0,2} of \u2660, {0,2} of \u2665, {0,2} of \u2666, {0,2} of \u2663", card);
        card = "K";
        Console.WriteLine("{0,2} of \u2660, {0,2} of \u2665, {0,2} of \u2666, {0,2} of \u2663", card);
        card = "A";
        Console.WriteLine("{0,2} of \u2660, {0,2} of \u2665, {0,2} of \u2666, {0,2} of \u2663", card);
    }
}

