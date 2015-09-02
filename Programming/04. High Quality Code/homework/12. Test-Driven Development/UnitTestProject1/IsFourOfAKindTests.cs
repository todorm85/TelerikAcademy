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
    public class IsFourOfAKind
    {
        private IList<IHand> validHands = new List<IHand>() 
        {
            new Hand(new List<ICard>() 
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds)
            }),
            new Hand(new List<ICard>() 
            {
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Spades)
            })
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
        public void 
            IsFourOfAKindShouldReturnTrueOnValidHand()
        {
            foreach (var hand in validHands)
            {
                Assert.IsTrue(pokerHandsChecker.IsFourOfAKind(hand), hand.ToString());
            }
        }

        [TestMethod]
        public void IsFourOfAKindShouldReturnFalseOnInvalidHand()
        {
            foreach (var hand in invalidHands)
            {
                Assert.IsFalse(pokerHandsChecker.IsFourOfAKind(hand), hand.ToString());
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void IsFourOfAKindShouldThrowOnNullHand()
        {
            pokerHandsChecker.IsFourOfAKind(null);
        }
    }
}