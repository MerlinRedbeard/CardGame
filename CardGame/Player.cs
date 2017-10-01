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

        public void SetName(String newName)
        {
            name = newName;
        }

        public String GetName()
        {
            return name;
        }

        public void SetPlayerCollection(CardCollection newCollection)
        {
            playerCards = new List<CardCollection>();
            playerCards.Add(newCollection);
        }

        public void AddPlayerCollection(CardCollection newCollection)
        {
            playerCards.Add(newCollection);
        }

        public CardCollection GetPlayerCollection()
        {
            return playerCards[0];
        }

        public CardCollection GetPlayerCollection(string collectionName)
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

        public void AddToPlayerCollection(Card newCard)
        {
            playerCards[0].AddToCollection(newCard);
        }

        public void AddToPlayerCollection(Card newCard, string collectionName)
        {
            CardCollection hold;

            try
            {
                hold = GetPlayerCollection(collectionName);
                hold.AddToCollection(newCard);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
