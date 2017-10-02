using System;
using System.Collections.Generic;

namespace CardGame
{
    class WarGame : Game
    {
        private List<WarGameOption> gameOptions;

        public WarGame(string GameName, string RulesToDisplay) : base(GameName, RulesToDisplay)
        {
            gameOptions = new List<WarGameOption>();
            gameOptions.Add(WarGameOption.ACE_HIGH);
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
            string userInput = "PLAY";
            string[] config;
            while (userInput != "PLAY") {
                Console.WriteLine("Please select the game options.  Select \"Play\" when you are ready to play the game.");
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
                Console.ReadLine();
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
            AddNewDeck(new PokerDeck("Draw Deck",false));

            // shuffle the deck
            gameDecks[0].Shuffle();

            // deal the cards to each player's deck
            Deck[] playerDecks = new Deck[players.Count];
            int totalCards = gameDecks[0].NumCardsInCollection();
            int j = 0;
            for(int i = 0; i < players.Count; i++)
            {
                playerDecks[i] = new Deck("Deck " + (i+1),new Card[0]);
            }
            for (int i = 0; i < totalCards; i++)
            {
                playerDecks[j].AddToCollection(gameDecks[0].DrawTopCard());

                if (j < players.Count - 1) { j++; }
                else { j = 0; }
            }

            for (int i = 0; i < players.Count; i++)
            {
                players[i].SetPlayerCollection(playerDecks[i]);
                players[i].AddPlayerCollection(new Hand("Play"));
            }
            int playerCount = players.Count;
            CardCollection cardsAtRisk;
            Player winner;
            StandardCard[] inPlay;
            // finally, play the game
            while (playerCount > 1)
            {
                cardsAtRisk = new Hand("cardsAtRisk");
                inPlay = new StandardCard[playerCount];
                //Display Player names
                for (int i = 0; i < playerCount; i++)
                {
                    Console.Write("{0}\t", players[i].GetName());
                }
                Console.WriteLine();
                //Display number of cards in each player's deck
                for (int i = 0; i < playerCount; i++)
                {
                    Console.Write("Cards: {0}\t", players[i].GetPlayerCollection().NumCardsInCollection());
                }
                Console.WriteLine();
                
                winner = FindWinner(players,ref cardsAtRisk);
                Card[] cardsWon = cardsAtRisk.CardsInCollection();
                foreach (Player originalPlayer in players)
                {
                    if (originalPlayer.Equals(winner))
                    {

                        foreach(Card won in cardsWon)
                        {
                            ((Deck)originalPlayer.GetPlayerCollection()).AddToBottom(won.SetFace(Card.Face.BACK));
                        }
                        break;
                    }
                }

                //Display Cards played for each Player for the round
                bool isEmpty = false;
                Card toDisplay;
                while (!isEmpty)
                {
                    isEmpty = true;
                    for (int i = 0; i < playerCount; i++)
                    {
                        if (players[i].GetPlayerCollection("Play").NumCardsInCollection() > 0)
                        {
                            toDisplay = players[i].GetPlayerCollection("Play").CardsInCollection()[0];
                            isEmpty = false;
                            Console.Write("{0}\t", toDisplay.GetVisibleDisplayName());
                            players[i].GetPlayerCollection("Play").RemoveFromCollection(toDisplay);
                        }
                        else
                        {
                            Console.Write("\t\t");
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("------------------------------------------");

                for (int i = 0; i < playerCount; i++)
                {
                    if (players[i].GetPlayerCollection().IsEmpty())
                    {
                        Console.WriteLine("Player {0} Eliminated", players[i].GetName());
                        RemovePlayer(players[i]);
                    }
                    playerCount = players.Count;
                }
            }
        }

        public override void PlayGUIGame()
        {
            throw new NotImplementedException();
        }

        private Player FindWinner(List<Player> playersInBattle, ref CardCollection cardsWon)
        {
            StandardCard[] onTable = new StandardCard[playersInBattle.Count];
            for (int i = 0; i < playersInBattle.Count; i++)
            {
                onTable[i] = (StandardCard)((Deck)playersInBattle[i].GetPlayerCollection()).DrawTopCard().SetFace(Card.Face.FRONT);
                playersInBattle[i].AddToPlayerCollection(onTable[i], "Play");
                cardsWon.AddToCollection(onTable[i]);
            }
            List<Player> warringPlayers = new List<Player>
            {
                playersInBattle[0]
            };

            int winnerIndex = 0;
            int cardCompare;
            for (int i = 1; i < playersInBattle.Count; i++)
            {
                cardCompare = CompareCard(onTable[i], onTable[winnerIndex]);
                if (cardCompare < 0)
                {
                    winnerIndex = i;
                    warringPlayers = new List<Player>
                    {
                        playersInBattle[i]
                    };
                }
                else if (cardCompare == 0)
                {
                    warringPlayers.Add(playersInBattle[i]);
                }
            }
            Player winner = players[winnerIndex];
            StandardCard temp;
            //This logic will need to be upgraded
            if (warringPlayers.Count > 1)
            {
                foreach(Player atWar in warringPlayers)
                {
                    if (atWar.GetPlayerCollection().NumCardsInCollection() > 2)
                    {
                        temp = (StandardCard)((Deck)atWar.GetPlayerCollection()).DrawTopCard();
                        cardsWon.AddToCollection(temp);
                        atWar.AddToPlayerCollection(temp.SetFace(Card.Face.BACK), "Play");

                        temp = (StandardCard)((Deck)atWar.GetPlayerCollection()).DrawTopCard();
                        cardsWon.AddToCollection(temp);
                        atWar.AddToPlayerCollection(temp.SetFace(Card.Face.BACK), "Play");
                    }
                    else
                    {
                        cardsWon.AddToCollection(atWar.GetPlayerCollection());
                        atWar.SetPlayerCollection(new Deck("Losing deck",new Card[0]));
                        warringPlayers.Remove(atWar);
                    }
                }
                if(warringPlayers.Count > 1)
                {
                    winner = FindWinner(warringPlayers, ref cardsWon);
                }
            }

            return winner;
        }

        private int CompareCard(StandardCard a, StandardCard b)
        {
            int a_Value = a.GetValue();
            int b_Value = b.GetValue();
            //Implementing ACE_HIGH
            if (gameOptions[0] == WarGameOption.ACE_HIGH)
            {
                if (a_Value == 1 && b_Value > 1)
                {
                    return -1;
                }
                else if (a_Value > 1 && b_Value == 1)
                {
                    return 1;
                }
            }
            //Default of ACE_LOW
            return b_Value.CompareTo(a_Value);
        }
    }
}
