using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Deck : CardCollection
    {
        private string displayName;
        protected LinkedList<Card> cards;

        public Deck(string addDisplayName, Card[] addCards)
        {
            displayName = addDisplayName;
            cards = new LinkedList<Card>(addCards);
        }

        public virtual void Shuffle()
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

        public virtual Card DrawTopCard()
        {
            try
            {
                Card topCard = cards.First<Card>();
                this.RemoveFromCollection(topCard);
                return topCard;
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (CardNotFoundException e)
            {
                return null;
            }
            catch (System.InvalidOperationException f)
            {
                return null;
            }
#pragma warning restore CS0168 // Variable is declared but never used
        }

        public override string GetDisplayName()
        {
            return displayName;
        }

        public override Card Display()
        {
            if (cards.Count > 0)
            {
                return cards.First<Card>();
            }
            return null;
        }

        public override void RemoveFromCollection(Card toRemove)
        {
            if (cards.Count > 0)
            {
                cards.Remove(toRemove);
            }
            else
            {
                throw new CardNotFoundException(toRemove);
            }
        }

        public override Card[] CardsInCollection()
        {
            Card[] temp = new Card[cards.Count];
            cards.CopyTo(temp, 0);
            return temp;
        }

        public override int NumCardsInCollection()
        {
            return cards.Count;
        }

        public override void AddToCollection(Card toAdd)
        {
            cards.AddFirst(toAdd);
        }

        public virtual void AddToBottom(Card toAdd)
        {
            cards.AddLast(toAdd);
        }
    }
}
