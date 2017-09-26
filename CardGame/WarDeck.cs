using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class WarDeck : PokerDeck
    {
        public WarDeck(string addDisplayName) : base(addDisplayName)
        {
        }

        public WarDeck(string addDisplayName, bool addJokers) : base(addDisplayName, addJokers)
        {
        }

        public WarDeck(string addDisplayName, Card.Face showing) : base(addDisplayName, showing)
        {
        }

        public WarDeck(string addDisplayName, bool addJokers, Card.Face showing) : base(addDisplayName, addJokers, showing)
        {
        }

        public void AddToBottom(StandardCard newCard)
        {
            base.cards.AddLast(newCard);
        }
    }
}
