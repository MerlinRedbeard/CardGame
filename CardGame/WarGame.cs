using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class WarGame : Game
    {
        public enum GameOption { ACE_HIGH, ACE_LOW, TWO_BEATS_ACE_HIGH }
        private GameOption aceOption;
        // other game options?
        // number of decks?
        // with/without jokers?

        public WarGame(string GameName, string RulesToDisplay) : base(GameName, RulesToDisplay)
        {
            aceOption = GameOption.ACE_HIGH;
        }

        public void SetGameOption(GameOption optionToSet)
        {
            aceOption = optionToSet;
        }

        public override string DisplayConfig()
        {
            return "The name of the game is " + base.GameName + "\n" +
                "with ace option of " + aceOption.ToString();
        }

        public override void PlayGame()
        {
            // make sure we have at least 2 players

            // create our original deck, without jokers
            base.AddNewDeck(new PokerDeck("Draw Deck",false));

            // shuffle the deck
            base.gameDecks[0].Shuffle();

            // deal the cards to each player's deck

            // finally, play the game

        }
    }
}
