﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CardGame
{
    class WarGame : Game
    {
        private List<WarGameOption> gameOptions;
        private int numberOfTurns;
        private int turnsSinceLastElimination;
        private int numberOfWars;

        private static string rules =
                "The deck is divided evenly amongst all players, dealt one at a time, face down.\n\n" +
                "Each player turns up a card at the same time and the player " +
                "with the winning card takes all cards and puts them, face down, on the bottom of their stack.\n\n" +
                "If the cards are the same rank, it is War. Each player places two additional cards face down and " +
                "one card face up. The player with the winning new face up card takes all piles. " +
                "If the turned-up cards are again the same rank, each player places another two cards face down " +
                "and turns another card face up. This continues until one player has a winning card.\n\n" +
                "The game ends when one player has acquired all cards.";

        public WarGame(string GameName) : base(GameName, rules)
        {
            numberOfTurns = 0;
            turnsSinceLastElimination = 0;
            numberOfWars = 0;
            
            gameOptions = new List<WarGameOption>
            {
                WarGameOption.ACE_HIGH
            };
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
            Console.WriteLine("How many players?");
            Int32.TryParse(Console.ReadLine(), out int numPlayers);
            while (numPlayers < 2)
            {
                Console.WriteLine("Invalid Number of players, please try again");
                Int32.TryParse(Console.ReadLine(), out numPlayers);
            }

            string playerName;
            for (int i = 1; i <= numPlayers; i++)
            {
                Console.WriteLine("Player {0} name:", i);

                playerName = Console.ReadLine().Trim();
                if (!string.IsNullOrEmpty(playerName))
                {
                    AddPlayer(new Player(playerName));
                }
                else
                {
                    AddPlayer(new Player("Player " + i));
                }
            }

            // make sure we have at least 2 players
            if (base.players.Count<2)
            {
                throw new ArgumentException("Invalid number of players");
            }

            //Get Game Options
            string userInput = "";
            string[] options;
            string[] currentOptions;
            WarGameOption optionToSet;
            Console.Clear();
            while (userInput != "PLAY")
            {
                Console.WriteLine();
                switch (userInput)
                {
                    case "HELP":
                        Console.WriteLine("Available Game Options:");
                        options = GetGameOptions();
                        foreach (string config in options)
                        {
                            Console.WriteLine("\t{0}", config);
                        }
                        Console.WriteLine();
                        break;
                    case "PLAY":
                        break;
                    case "":
                        break;
                    case null:
                        break;
                    default:
                        optionToSet = (WarGameOption)WarGameOption.GetOption(userInput);
                        if (optionToSet != null)
                        {
                            SetGameOption(optionToSet);
                            Console.WriteLine("Option {0} set successfully", userInput);
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Invalid option. Please try again.");
                            Console.WriteLine();
                            goto case "HELP";
                        }
                        break;
                }
                Console.WriteLine("Please select the game options.  Select \"Play\" when you are ready to play the game.");
                Console.WriteLine();
                Console.WriteLine("Current War Game Configuration:");
                currentOptions = GetConfig();
                foreach(string currentConfig in currentOptions)
                {
                    Console.WriteLine("\t-{0}",currentConfig);
                }
                Console.WriteLine();
                Console.WriteLine("Type \"Play\" to play with the current configuration");
                Console.WriteLine("Type \"Help\" for a list of game options to set");
                Console.WriteLine("Type the name of a game option if you wish to toggle that option");
                Console.WriteLine();
                userInput = Console.ReadLine().ToUpper().Trim().Replace("  ", " ").Replace(' ', '_');
                Console.Clear();
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
                players[i].SetPlayerCollections(new CardCollection[] { playerDecks[i], new Hand("Play") });
            }
            int playerCount = players.Count;
            CardCollection cardsAtRisk;
            Player winner;
            StandardCard[] inPlay;
            // finally, play the game
            while (playerCount > 1)
            {
                numberOfTurns++;
                turnsSinceLastElimination++;
                
                cardsAtRisk = new Hand("cardsAtRisk");
                inPlay = new StandardCard[playerCount];

                Console.WriteLine("Turn number {0}", numberOfTurns);
                
                //Display Player names
                for (int i = 0; i < playerCount; i++)
                {
                    Console.Write("{0,15}\t", players[i].GetName());
                }
                Console.WriteLine();
                //Display number of cards in each player's deck
                string display = "";
                for (int i = 0; i < playerCount; i++)
                {
                    display = "Cards: " + players[i].GetPlayerCollection().NumCardsInCollection();
                    Console.Write(display.PadLeft(15)+"\t");
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
                            ((Deck)originalPlayer.GetPlayerCollection()).AddToCollection(won.SetFace(Card.Face.BACK),CardCollection.CollectionLocation.BOTTOM);
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
                            
                            if (players[i].Equals(winner))
                            {
                                Console.Write("{0,14}*", toDisplay.GetVisibleDisplayName());
                            }
                            else
                            {
                                Console.Write("{0,15}", toDisplay.GetVisibleDisplayName());
                            }
                            Console.Write("\t");
                            players[i].GetPlayerCollection("Play").RemoveFromCollection(toDisplay);
                        }
                        else
                        {
                            Console.Write("{0,15}\t","");
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("------------------------------------------");
                System.Threading.Thread.Sleep(100);

                // See if we want to continue watching this
                if (turnsSinceLastElimination % 250 == 0)
                {
                    Console.WriteLine("It's been {0} turns.\n", numberOfTurns);
                    Console.WriteLine("Do you want to continue? (Y/N)");

                    string timeToQuit = Console.ReadLine().ToUpper();
                         
                    if (timeToQuit[0] == 'N')
                    {
                        return;
                    }
                }

                for (int i = 0; i < playerCount; i++)
                {
                    if (players[i].GetPlayerCollection().IsEmpty())
                    {
                        Console.WriteLine("{0} Eliminated", players[i].GetName());
                        RemovePlayer(players[i]);
                        turnsSinceLastElimination = 0;

                        if (players.Count != 0)
                        {
                            Console.ReadLine();
                        }
                    }
                    if(players.Count < playerCount)
                    {
                        playerCount = players.Count;
                        i--;
                    }
                    
                }
            }

            if(playerCount > 0)
            {
                Console.WriteLine("{0} wins!", players[0].GetName());
            }
            else
            {
                Console.WriteLine("Tie! No one wins");
            }

            Console.WriteLine("Number of turns: {0}", numberOfTurns);
            Console.WriteLine("Number of wars: {0}", numberOfWars);

            Console.ReadLine();
        }

        public override void PlayGUIGame()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            WarForm mainForm = new WarForm();
            int numPlayers = 0;

            var result = mainForm.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }

            numPlayers = mainForm.returnNumberOfPlayers;
            Console.WriteLine("number of players is {0}", numPlayers);
            Console.ReadLine();
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
            Player winner = playersInBattle[winnerIndex];
            //Create copy of top contenders for if all are eliminated, commented out until requisite code is complete
            //List<Player> possibleWinners = warringPlayers;
            StandardCard temp;
            //This logic will need to be upgraded
            if (warringPlayers.Count > 1)
            {
                numberOfWars++;

                for(int i=0;i<warringPlayers.Count;i++)
                //foreach(Player atWar in warringPlayers)
                {
                    if (warringPlayers[i].GetPlayerCollection().NumCardsInCollection() > 2)
                    {
                        temp = (StandardCard)((Deck)warringPlayers[i].GetPlayerCollection()).DrawTopCard().SetFace(Card.Face.BACK);
                        cardsWon.AddToCollection(temp);
                        warringPlayers[i].AddToPlayerCollection(temp, "Play");

                        temp = (StandardCard)((Deck)warringPlayers[i].GetPlayerCollection()).DrawTopCard().SetFace(Card.Face.BACK);
                        cardsWon.AddToCollection(temp);
                        warringPlayers[i].AddToPlayerCollection(temp, "Play");
                    }
                    else
                    {
                        cardsWon.AddToCollection(warringPlayers[i].GetPlayerCollection());
                        warringPlayers[i].AddToPlayerCollection(warringPlayers[i].GetPlayerCollection().CardsInCollection(),"Play");
                        warringPlayers[i].SetPlayerCollections(
                            new CardCollection[] {
                                new Deck("Losing deck",new Card[0]),
                                warringPlayers[i].GetPlayerCollection("Play")
                            });
                        warringPlayers.Remove(warringPlayers[i]);
                        i--;
                    }
                }
                if(warringPlayers.Count > 0)
                {
                    winner = FindWinner(warringPlayers, ref cardsWon);
                }
                else
                {
                    //What should happen if the players tied for highest don't have enough cards to complete a war?


                    //for(int i=0;i<playersInBattle.Count;i++)
                    //{
                    //    if (!possibleWinners.Contains(playersInBattle[i]) && onTable[i] != null)
                    //    {
                    //        playersInBattle[i].AddToPlayerCollection(onTable[i]);
                    //        onTable[i] = null;
                    //    }
                    //    else
                    //    {
                    //        playersInBattle.RemoveAt(i);
                    //        i--;
                    //    }
                    //}
                    
                    //foreach(Player tryAgain in playersInBattle)
                    //{

                    //    tryAgain.AddToPlayerCollection(tryAgain.GetPlayerCollection("Play").CardsInCollection())
                    //}
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
