using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    abstract class Game
    {
        private string rules;
        private string gameName;
        private List<Player> players;
        private Deck gameDeck;

        protected Game(string RulesToDisplay, string GameName, Player[] PlayersToAdd, Deck GameDeck)
        {
            rules = RulesToDisplay;
            gameName = GameName;
            players = new List<Player>(PlayersToAdd);
            gameDeck = GameDeck;
        }

        public virtual void AddPlayer(Player toAdd)
        {
            players.Add(toAdd);
        }

        public virtual void RemovePlayer(Player toKick)
        {
            players.Remove(toKick);
        }

        /// <summary>
        /// Returns the rules for the current game
        /// </summary>
        /// <returns>Rules of the current game as a string</returns>
        public virtual string ReadRules() => rules;

        /// <summary>
        /// Displays current game configuration, including additional options selected
        /// </summary>
        public abstract void DisplayConfig();

        /// <summary>
        /// Plays game with current configuration/players
        /// </summary>
        /// <exception cref="System.ArgumentNullException">When one or more mandatory game mechanics is not initialized.  Should be handled in game.</exception>
        public abstract void PlayGame();
    }
}
