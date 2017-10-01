using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class WarGame : Game
    {
        private List<WarGameOption> gameOptions;

        public WarGame(string GameName, string RulesToDisplay) : base(GameName, RulesToDisplay)
        {
            gameOptions[0] = WarGameOption.ACE_HIGH;
        }

        public override bool SetGameOption(GameOption optionToSet)
        {
            string option = optionToSet.ToString();
            switch (option)
            {
                case "ACE_HIGH":
                    goto case "ACE_LOW";
                case "ACE_LOW":
                    gameOptions[0] = (WarGameOption)optionToSet;
                    return true;
                default:
                    return false;
            }
        }

        public override string[] GetConfig()
        {
            string[] toReturn = new string[gameOptions.Count];
            for (int i = 0; i < gameOptions.Count; i++)
            {
                toReturn[i] = gameOptions[i].Value;
            }
            return toReturn;
        }

        public override string[] GetGameOptions()
        {
            GameOption[] options = WarGameOption.GetGameOptions();
            int size = options.Length;
            string[] toReturn = new string[size];
            for (int i=0; i < size; i++)
            {
                toReturn[i] = options[i].Value;
            }
            return toReturn;
        }

        public override void PlayTextGame()
        {
            // make sure we have at least 2 players
            if (base.players.Count<2)
            {
                throw new ArgumentException("Invalid number of players");
            }

            //Get Game Options
            string userInput = "";
            string[] config;
            while (userInput != "PLAY_GAME") {
                //Console.WriteLine("Please select the game options.  Select \"Play\" when you are ready to play the game.");
                Console.WriteLine("Current War Game Configuration:");
                config = GetConfig();
                foreach(string currentConfig in config)
                {
                    Console.WriteLine("\t-{0}",currentConfig);
                }

                Console.WriteLine("Type \"Play\" to play with the current configuration");
                Console.WriteLine("Type \"Help\" for a list of game options to set");
                Console.WriteLine("Type the name of a game option if you wish to toggle that option");

                config = GetGameOptions();
                userInput = Console.ReadLine().ToUpper().Trim().Replace("  "," ").Replace(' ','_');
                switch (userInput)
                {
                    case "HELP":
                        Console.WriteLine("Available Game Options:");
                        foreach(string currentConfig in config)
                        {
                            Console.WriteLine("\t-{0}", currentConfig);
                        }
                        break;
                    case "PLAY":
                        break;
                    default:
                        if (SetGameOption(WarGameOption.GetOption(userInput)))
                        {
                            Console.WriteLine("Option {0} set successfully", userInput);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Option");
                            goto case "HELP";
                        }
                }
            }

            // create our original deck, without jokers
            base.AddNewDeck(new PokerDeck("Draw Deck",false));

            // shuffle the deck
            base.gameDecks[0].Shuffle();

            // deal the cards to each player's deck

            // finally, play the game

        }

        public override void PlayGUIGame()
        {
            throw new NotImplementedException();
        }
    }
}
