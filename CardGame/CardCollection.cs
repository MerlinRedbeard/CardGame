using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    abstract class CardCollection
    {        
        public enum CollectionLocation { TOP, FRONT, BOTTOM, BACK, SHUFFLE}

        public CardCollection() { }

        /// <summary>
        /// Adds a given card to a specified location within the collection
        /// </summary>
        /// <param name="toAdd">Card to add</param>
        /// <param name="toWhere">CollectionLocation to add the Card to</param>
        abstract public void AddToCollection(Card toAdd, CollectionLocation toWhere = CollectionLocation.TOP);
        
        /// <summary>
        /// Add all of the cards in a CardCollection to the current CardCollection at the given location.  Default location is TOP.
        /// </summary>
        /// <param name="newCollection">Collection to be added</param>
        /// <param name="toWhere">Location for Collection to be added.  Defaults to TOP</param>
        virtual public void AddToCollection(CardCollection newCollection, CollectionLocation toWhere = CollectionLocation.TOP)
        {
            AddToCollection(newCollection.CardsInCollection(),toWhere);
        }

        /// <summary>
        /// Add all of the cards in a Card array to the current CardCollection.
        /// </summary>
        /// <param name="newCollection">Array of Card objects to add to the current CardCollection</param>
        /// <param name="toWhere">Location in CardCollection to add Card objects</param>
        virtual public void AddToCollection(Card[] newCards,CollectionLocation toWhere = CollectionLocation.TOP)
        {
            for (int i = 0; i < newCards.Length; i++)
            {
                this.AddToCollection(newCards[i],toWhere);
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
        public virtual bool IsEmpty()
        {
            //if (NumCardsInCollection() < 20)
            if (NumCardsInCollection() == 0)
            {
                return true;
            }

            return false;
        }
    }
}
