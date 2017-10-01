using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    abstract class CardCollection
    {        
        public CardCollection() { }

        /// <summary>
        /// Add a Card to the CardCollection
        /// </summary>
        /// <param name="toAdd"></param>
        abstract public void AddToCollection(Card toAdd);

        virtual public void AddToCollection(CardCollection newCollection)
        {
            Card[] newCards = newCollection.CardsInCollection();

            for (int i = 0; i < newCollection.NumCardsInCollection(); i++)
            {
                this.AddToCollection(newCards[i]);
            }
        }

        /// <summary>
        /// Remove a Card from the CardCollection
        /// </summary>
        /// <param name="toRemove"></param>
        /// <exception cref="CardNotFoundException">Thrown when CardCollection is empty</exception>
        abstract public void RemoveFromCollection(Card toRemove);

        /// <summary>
        /// Returns the Cards in the current CardCollection
        /// </summary>
        /// <returns>Array of Card objects in CardCollection.  Order not guaranteed.</returns>
        abstract public Card[] CardsInCollection();

        /// <summary>
        /// returns the number of Card objects in the current CardCollection
        /// </summary>
        /// <returns>Number of Card objects</returns>
        abstract public int NumCardsInCollection();
        
        /// <summary>
        /// Returns CardCollection display name
        /// </summary>
        /// <returns>Display name for the current CardCollection</returns>
        abstract public string GetDisplayName();

        /// <summary>
        /// Returns the Card object to display for the CardCollection for GUI purposes
        /// </summary>
        /// <returns>Top Card object of CardCollection</returns>
        abstract public Card Display();

        /// <summary>
        /// Returns True if the collection is empty.
        /// </summary>
        /// <returns></returns>
        public virtual bool isEmpty()
        {
            if (NumCardsInCollection() == 0)
            {
                return true;
            }

            return false;
        }
    }
}
