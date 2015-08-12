using System;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            if (hand == null)
            {
                throw new NullReferenceException("hand to check cannot be null");
            }

            var cards = hand.Cards;

            if (cards.Count != 5 )
            {
                return false;
            }

            foreach (var card in cards)
            {
                var hasSameCardAddedMoreThanOnce = 
                    cards.Where(x => x == card).Count() > 1;

                if (hasSameCardAddedMoreThanOnce)
                {
                    return false;
                }

                var hasDifferentButEqualCards = cards
                    .Where(x => x != card)
                    .Any(x => x.Face == card.Face && x.Suit == card.Suit);

                if (hasDifferentButEqualCards)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            var cards = hand.Cards;
            var firstCardFace = CardFace.Ace;
            var sameFaceCount = cards.Where(x => x.Face == firstCardFace).Count();

            if (sameFaceCount == 1 || sameFaceCount == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            if(!IsValidHand(hand))
            {
                return false;
            }

            var firstCardSuit = hand.Cards[0].Suit;

            return hand.Cards.All(x => x.Suit == firstCardSuit);
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
