using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Hand
    {
        private string name;
        private List<Card> cardsInHand;

        public string Name { get => name; set => name = value; }

        public Hand() : this("Default Hand") { }

        public Hand(string handName) : this(handName,new Card[0]) { }

        public Hand(string handName,Card[] startingHand)
        {
            Name = handName;
            cardsInHand = new List<Card>(startingHand);
        }

        public int NumCardsInHand()
        {
            return cardsInHand.Count;
        }

        public Card[] CardsInHand()
        {
            Card[] toReturn = new Card[cardsInHand.Count];
            Array.Copy(cardsInHand.ToArray(), toReturn, cardsInHand.Count);
            foreach(Card card in toReturn)
            {
                card.SetFace(Card.Face.FRONT);
            }
            return toReturn;
        }

        public void addToHand(Card toAdd)
        {
            cardsInHand.Add(toAdd);
        }

        public void removeFromHand(Card toRemove)  
        {
            if(!cardsInHand.Remove(toRemove))
            {
                throw new CardNotFoundException(toRemove);
            }
        }
    }
}
