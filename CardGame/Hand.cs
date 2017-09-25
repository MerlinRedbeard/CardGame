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
        private List<Card> cardsInHand;

        public string Name {set => name = value; }

        public Hand() : this("Default Hand") { }

        public Hand(string handName) : this(handName,new Card[0]) { }

        public Hand(string handName,Card[] startingHand)
        {
            Name = handName;
            cardsInHand = new List<Card>(startingHand);
        }

        public override void AddToCollection(Card toAdd)
        {
            cardsInHand.Add(toAdd);
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
            return cardsInHand[0];
        }

        public override int NumCardsInCollection()
        {
            return cardsInHand.Count;
        }
    }
}
