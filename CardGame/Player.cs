using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Player
    {
        private string name;
        public CardCollection playerCards;
        // Making this public, because outside sources will need to add cards to this collection?
        // Or is encapsulation more important?  If so, then we could make new methods in Player.cs 
        // to call the various methods of their CardCollection? (seems redundant to me at the moment)
        
        // private CardCollection playerCards;
        // public CardCollection PlayerCards { get => playerCards; set => playerCards = value; }

        public Player() : this(string.Concat("Player ", DateTime.Now.Ticks.ToString("####"))) { }

        public Player(string newName) : this(newName,new Hand()) { }

        public Player(string newName, CardCollection startingCards)
        {
            name = newName;
            playerCards = startingCards;
        }

    }
}
