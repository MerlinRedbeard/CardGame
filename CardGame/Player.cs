using System;
using System.Collections.Generic;

namespace CardGame
{
    class Player
    {
        private string name;
        private List<CardCollection> playerCards;

        public Player() : this(string.Concat("Player ", (new Random((int)DateTime.Now.Ticks)).Next(9999))) { }

        public Player(string newName) : this(newName,new Hand()) { }

        public Player(string newName, CardCollection startingCards)
        {
            name = newName;
            playerCards = new List<CardCollection>
            {
                startingCards
            };
        }

        public void SetName(String newName)
        {
            name = newName;
        }

        public String GetName()
        {
            return name;
        }

        public void SetPlayerCollections(CardCollection[] newCollection)
        {
            playerCards = new List<CardCollection>(newCollection);
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

            return null;
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
