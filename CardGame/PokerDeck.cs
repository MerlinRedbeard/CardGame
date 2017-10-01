using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class PokerDeck : Deck
    {

        public PokerDeck(string addDisplayName) : this(addDisplayName, false) { }

        public PokerDeck(string addDisplayName, bool addJokers) : this(addDisplayName, addJokers, Card.Face.BACK) { }

        public PokerDeck(string addDisplayName, Card.Face showing) : this(addDisplayName, false, showing) { }

        public PokerDeck(string addDisplayName, bool addJokers, Card.Face showing) : base(addDisplayName, CreateStandardDeck(addJokers,showing)) { }

        private static Card[] CreateStandardDeck(bool addJokers,Card.Face showing)
        {
            Card[] cardsToAdd;
            if (addJokers)
            {
                cardsToAdd = new Card[54];
                cardsToAdd[52] = new StandardCard(showing);
                cardsToAdd[53] = new StandardCard(showing);
            } else
            {
                cardsToAdd = new Card[52];
            }
            
            for (int i = 0; i < 13; i++)
            {
                cardsToAdd[(i * 4)] = new StandardCard(i + 1, StandardCard.Suit.CLUB, showing);
                cardsToAdd[(i * 4) + 1] = new StandardCard(i + 1, StandardCard.Suit.DIAMOND, showing);
                cardsToAdd[(i * 4) + 2] = new StandardCard(i + 1, StandardCard.Suit.HEART, showing);
                cardsToAdd[(i * 4) + 3] = new StandardCard(i + 1, StandardCard.Suit.SPADE, showing);
            }

            return cardsToAdd;
        }
    }
}
