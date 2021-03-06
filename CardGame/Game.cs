﻿using System;
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
        protected List<Player> players;
        protected List<Deck> gameDecks;

        public string GameName { get => gameName; }

        public Game(string GameName, string RulesToDisplay)
        {
            players = new List<Player>();
            gameDecks = new List<Deck>();
            rules = RulesToDisplay;
            gameName = GameName;
        }

        public virtual void AddNewDeck(Deck newDeck)
        {
            gameDecks.Add(newDeck);
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
        /// Gets the current game configuration
        /// </summary>
        /// <returns>string[] representing current GameOption choices</returns>
        public abstract string[] GetConfig();

        /// <summary>
        /// Displays appropriate GameOption choices
        /// </summary>
        /// <returns>string of choices for GameOptions to set</returns>
        public abstract string[] GetGameOptions();

        /// <summary>
        /// Plays console game with current configuration/players
        /// </summary>
        /// <exception cref="System.ArgumentNullException">When one or more mandatory game mechanics is not initialized.  Should be handled in game.</exception>
        public abstract void PlayTextGame();

        /// <summary>
        /// Plays GUI game with current configuration/players
        /// </summary>
        /// <exception cref="System.ArgumentNullException">When one or more mandatory game mechanics is not initialized.  Should be handled in game.</exception>
        public abstract void PlayGUIGame();

        /// <summary>
        /// Applies a specific game option.  Must be used before game start.
        /// </summary>
        /// <param name="gameOption">Game option to be set</param>
        /// <returns>true if option was set successfully</returns>
        public abstract bool SetGameOption(GameOption gameOption);
    }
}
