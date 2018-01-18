using System;

namespace Poker
{
    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {

            var cardAsString = String.Format("{0}{1}", this.Face.ToFriendlyString(), this.Suit.ToFriendlyString());
            return cardAsString;
        }
    }
}
