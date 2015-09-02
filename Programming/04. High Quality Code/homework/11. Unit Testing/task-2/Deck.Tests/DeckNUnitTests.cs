using System;
using Santase.Logic.Cards;
using NUnit.Framework;

namespace DeckTests
{
    [TestFixture]
    public class DeckNUnitTests
    {
        [TestCase(5)]
        [TestCase(24)]
        public void DeckConstructorShouldGenerateFullDeck(int cardsCount)
        {
            var deck = new Deck();
            if (cardsCount == 24)
            {
                Assert.AreEqual(cardsCount, deck.CardsLeft);
            }
            else
            {
                Assert.AreNotEqual(cardsCount, deck.CardsLeft);
            }
        }

        [TestCase(5)]
        [TestCase(10)]
        public void GetNextCardShouldRemoveCardsFromDeck(int cardsCount)
        {
            var deck = new Deck();
            var initialCardsCount = deck.CardsLeft;

            for (int i = 0; i < cardsCount; i++)
            {
                deck.GetNextCard();
            }

            Assert.AreEqual(initialCardsCount - cardsCount, deck.CardsLeft);
        }

        [Test]
        [ExpectedException]
        public void GetNextCardShouldThrowWhenDeckIsEmpty()
        {
            var deck = new Deck();
            var initialCardsCount = deck.CardsLeft;

            for (int i = 0; i <= initialCardsCount; i++)
            {
                deck.GetNextCard();
            }
        }

        [Test]
        public void ChangeTrumpCardShouldChangeDeckTrumpCardToTheNewTrumpCardInstance()
        {
            var deck = new Deck();
            var newTrumpCard = new Card(CardSuit.Club, CardType.Ace);

            deck.ChangeTrumpCard(newTrumpCard);

            Assert.AreEqual(newTrumpCard, deck.GetTrumpCard);
        }
    }
}
