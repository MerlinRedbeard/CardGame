using System;
using System.Collections.Generic;

namespace CardGame
{
    class Player
    {
        private string name;
        private List<CardCollection> playerCards;

        public Player() : this(string.Concat("Player ", DateTime.Now.Ticks.ToString("####"))) { }

        public Player(string newName) : this(newName,new Hand()) { }

        public Player(string newName, CardCollection startingCards)
        {
            name = newName;
            playerCards = new List<CardCollection>();
            playerCards.Add(startingCards);
        }

        public void setName(String newName)
        {
            name = newName;
        }

        public String getName()
        {
            return name;
        }

        public void setPlayerCollection(CardCollection newCollection)
        {
            playerCards = new List<CardCollection>();
            playerCards.Add(newCollection);
        }

        public void addPlayerCollection(CardCollection newCollection)
        {
            playerCards.Add(newCollection);
        }

        public CardCollection getPlayerCollection()
        {
            return playerCards[0];
        }

        public CardCollection getPlayerCollection(string collectionName)
        {
            foreach (CardCollection hand in playerCards)
            {
                if (hand.GetDisplayName() == collectionName)
                {
                    return hand;
                }
            }

            throw new Exception(message: "Player " + name + " does not have a collection of cards named " + collectionName);
        }
        public void addToPlayerCards(Card newCard)
        {
            playerCards[0].AddToCollection(newCard);
        }

        public void AddToPlayerCards(Card newCard, string collectionName)
        {
            CardCollection hold;

            try
            {
                hold = getPlayerCollection(collectionName);
                hold.AddToCollection(newCard);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
