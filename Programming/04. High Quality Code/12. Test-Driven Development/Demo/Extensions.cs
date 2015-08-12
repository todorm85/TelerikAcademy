using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    internal static class Extensions
    {
        internal static string ToFriendlyString(this CardFace face)
        {
            string faceAsString;

            switch (face)
            {
                case CardFace.Jack:
                    faceAsString = "J";
                    break;
                case CardFace.Queen:
                    faceAsString = "Q";
                    break;
                case CardFace.King:
                    faceAsString = "K";
                    break;
                case CardFace.Ace:
                    faceAsString = "A";
                    break;
                default:
                    faceAsString = ((int)face).ToString();
                    break;
            }

            return faceAsString;
        }

        internal static string ToFriendlyString(this CardSuit suit)
        {
            string suitAsString;
            switch (suit)
            {
                case CardSuit.Clubs:
                    suitAsString = "♣";
                    break;
                case CardSuit.Diamonds:
                    suitAsString = "♦";
                    break;
                case CardSuit.Hearts:
                    suitAsString = "♥";
                    break;
                case CardSuit.Spades:
                    suitAsString = "♠";
                    break;
                default:
                    throw new ArgumentException("Invalid Card Suit");
            }

            return suitAsString;
        }
    }
}
