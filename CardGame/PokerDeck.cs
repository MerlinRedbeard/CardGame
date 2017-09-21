using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class PokerDeck : Deck
    {
        private LinkedList<Card> deck;
        private string displayName;

        public PokerDeck(string addDisplayName) : this(addDisplayName, false) { }

        public PokerDeck(string addDisplayName, bool addJokers) : base(addDisplayName, createStandardDeck(addJokers)) { }

        private static Card[] createStandardDeck(bool addJokers)
        {
            Card[] cardsToAdd;
            if (addJokers)
            {
                cardsToAdd = new Card[54];
                cardsToAdd[52] = new StandardCard();
                cardsToAdd[53] = new StandardCard();
            } else
            {
                cardsToAdd = new Card[52];
            }
            
            for (int i = 0; i < 13; i++)
            {
                cardsToAdd[(i * 4)] = new StandardCard(i + 1, StandardCard.Suit.CLUB);
                cardsToAdd[(i * 4) + 1] = new StandardCard(i + 1, StandardCard.Suit.DIAMOND);
                cardsToAdd[(i * 4) + 2] = new StandardCard(i + 1, StandardCard.Suit.HEART);
                cardsToAdd[(i * 4) + 3] = new StandardCard(i + 1, StandardCard.Suit.SPADE);
            }

            return cardsToAdd;
        }
    }
}
