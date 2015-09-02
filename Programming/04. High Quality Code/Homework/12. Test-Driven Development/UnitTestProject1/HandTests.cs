using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Poker;
using NUnit.Framework;

namespace Poker.Tests
{
    [TestFixture]
    public class HandTests
    {
        private static Dictionary<CardSuit, string> suits = new Dictionary<CardSuit, string>() {
            {CardSuit.Clubs, "♣"},
            {CardSuit.Diamonds, "♦"},
            {CardSuit.Hearts, "♥"},
            {CardSuit.Spades, "♠"}
        };

        private static Dictionary<CardFace, string> faces = new Dictionary<CardFace, string>()
        {
            {CardFace.Two, "2"},
            {CardFace.Three, "3"}, 
            {CardFace.Four, "4"},
            {CardFace.Five, "5"},
            {CardFace.Six, "6"},
            {CardFace.Seven, "7"},
            {CardFace.Eight, "8"},
            {CardFace.Nine, "9"},
            {CardFace.Ten, "10"},
            {CardFace.Jack, "J"},
            {CardFace.Queen, "Q"},
            {CardFace.King, "K"},
            {CardFace.Ace, "A"}
        };

        [Test]
        public void HandToStringShouldReturnCorrectResultWithAllValidCards()
        {
            var cards = new List<ICard>();
            foreach (var face in faces)
            {
                foreach (var suit in suits)
                {
                    Card card = new Card(face.Key, suit.Key);
                    cards.Add(card);
                }
            }

            var hand = new Hand(cards);
            var expected = new StringBuilder();
            expected.Append(String.Join(", ", cards));

            var actual = hand.ToString();

            Assert.AreEqual(expected.ToString(), actual, "CardToString should return the friendly representation of the card as string. First the face in number or uppercase letter, followed by the corresponding card suit character (filled)");
        }
    }
}