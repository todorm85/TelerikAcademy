using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using Poker;

namespace Poker.Tests
{
    [TestClass]
    public class IsFlushTests
    {
        private IList<IHand> validHands = new List<IHand>() 
        {
            new Hand(new List<ICard>() 
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts)
            }),
            new Hand(new List<ICard>() 
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades)
            }),
            new Hand(new List<ICard>() 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds)
            }),
        };

        private IList<IHand> invalidHands = new List<IHand>() 
        {
            new Hand(new List<ICard>() 
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts)
            }),
            new Hand(new List<ICard>() 
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts)
            }),
            new Hand(new List<ICard>() 
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts)
            }),
            new Hand(new List<ICard>() 
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts)
            }),
            new Hand(new List<ICard>() {}),
        };

        private PokerHandsChecker pokerHandsChecker = new PokerHandsChecker();

        [TestMethod]
        public void IsFlushShouldReturnTrueOnValidHand()
        {
            foreach (var hand in validHands)
            {
                Assert.IsTrue(pokerHandsChecker.IsFlush(hand), hand.ToString());
            }
        }

        [TestMethod]
        public void IsFlushShouldReturnFalseOnInvalidHand()
        {
            foreach (var hand in invalidHands)
            {
                Assert.IsFalse(pokerHandsChecker.IsFlush(hand), hand.ToString());
            }
        }

        [TestMethod]
        [ExpectedException(typeof (NullReferenceException))]
        public void IsFlushShouldThrowOnNullHand()
        {
            pokerHandsChecker.IsFlush(null);
        }
    }
}
