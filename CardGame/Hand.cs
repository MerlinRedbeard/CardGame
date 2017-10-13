using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Hand : CardCollection
    {
        private string name;
        private LinkedList<Card> cardsInHand;

        public string Name {set => name = value; }

        public Hand() : this("Default Hand") { }

        public Hand(string handName) : this(handName,new Card[0]) { }

        public Hand(string handName,Card[] startingHand)
        {
            Name = handName;
            cardsInHand = new LinkedList<Card>(startingHand);
        }

        public override void AddToCollection(Card toAdd, CollectionLocation toWhere = CollectionLocation.TOP)
        {
            switch (toWhere)
            {
                case CollectionLocation.BACK:
                    cardsInHand.AddLast(toAdd);
                    break;
                case CollectionLocation.BOTTOM:
                    goto case CollectionLocation.BACK;
                case CollectionLocation.TOP:
                    cardsInHand.AddFirst(toAdd);
                    break;
                case CollectionLocation.FRONT:
                    goto case CollectionLocation.TOP;
                default:
                    goto case CollectionLocation.TOP;
            }
        }

        public override void RemoveFromCollection(Card toRemove)
        {
            if (!cardsInHand.Remove(toRemove))
            {
                throw new CardNotFoundException(toRemove);
            }
        }

        public override Card[] CardsInCollection()
        {
            Card[] toReturn = new Card[cardsInHand.Count];
            Array.Copy(cardsInHand.ToArray(), toReturn, cardsInHand.Count);
            foreach (Card card in toReturn)
            {
                card.SetFace(Card.Face.FRONT);
            }
            return toReturn;
        }

        public override string GetDisplayName()
        {
            return name;
        }

        public override Card Display()
        {
            return cardsInHand.First.Value;
        }

        public override int NumCardsInCollection()
        {
            return cardsInHand.Count;
        }
    }
}
