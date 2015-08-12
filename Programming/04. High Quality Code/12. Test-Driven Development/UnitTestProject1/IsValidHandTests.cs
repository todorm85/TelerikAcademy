using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Poker;
using NUnit.Framework;

namespace Poker.Tests
{
    [TestFixture]
    public class PokerHandsCheckerTests
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

        private static List<ICard> deck;

        [TestFixtureSetUp]
        public void GenerateCards()
        {
            deck = new List<ICard>();
            foreach (var face in faces)
            {
                foreach (var suit in suits)
                {
                    Card card = new Card(face.Key, suit.Key);
                    deck.Add(card);
                }
            }
        }

        [TestCase(5)]
        [TestCase(2)]
        [TestCase(10)]
        [TestCase(15)]
        [TestCase(3)]
        public void IsValidHandShouldReturnTrueOnExactltyFiveDifferentCards(int startDeckIndex)
        {            
            var hand = new Hand(deck.GetRange(startDeckIndex, 5));
            var pokerHandsChecker = new PokerHandsChecker();

            var result = pokerHandsChecker.IsValidHand(hand);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidHandShouldReturnFalseIfSameCardAddedMoreThanOnce()
        {
            var hand = new Hand(deck.GetRange(0,4));
            hand.Cards.Add(deck[0]);
            var pokerHandsChecker = new PokerHandsChecker();

            var result = pokerHandsChecker.IsValidHand(hand);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidHandShouldReturnFalseIfTwoDifferentCardsAreEqual()
        {
            var hand = new Hand(deck.GetRange(0, 3));
            hand.Cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            hand.Cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            var pokerHandsChecker = new PokerHandsChecker();

            var result = pokerHandsChecker.IsValidHand(hand);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidHandShouldReturnFalseWhenNotFiveCardsArePresent()
        {
            var hand = new Hand(deck.GetRange(0, 3));
            var pokerHandsChecker = new PokerHandsChecker();

            var result = pokerHandsChecker.IsValidHand(hand);

            Assert.IsFalse(result);
        }
    }
}