using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Deck
    {
        private string displayName;
        private LinkedList<Card> cards;

        public Deck(string addDisplayName, Card[] addCards)
        {
            displayName = addDisplayName;
            cards = new LinkedList<Card>(addCards);
        }

        public void Shuffle()
        {
            Card[] temp = new Card[cards.Count];
            cards.CopyTo(temp, 0);
            int[] newOrder = new int[temp.Length];
            Random numGen = new Random();
            for(int i = 0; i < temp.Length; i++)
            {
                newOrder[i] = numGen.Next();
            }
            Array.Sort(newOrder, temp);
            cards = new LinkedList<Card>(temp);
        }

        public Card DrawTopCard()
        {
            if (cards.Count != 0)
            {
                Card topCard = cards.First<Card>();
                cards.RemoveFirst();
                return topCard;
            }
            else
            {
                return null;
            }
        }

        public Card[] CardsInDeck()
        {
            Card[] temp = new Card[cards.Count];
            cards.CopyTo(temp, 0);
            return temp;
        }

        public string GetDisplayName()
        {
            return displayName;
        }

        public void AddToDeck(Card cardToAdd)//Adding card to top of deck for purpose of discard pile(s)
        {
            cards.AddFirst(cardToAdd);
        }

        public Card Display()//returns top card of deck for display purposes
        {
            if (cards.Count > 0)
            {
                return cards.First<Card>();
            }
            return null;
        }
    }
}
