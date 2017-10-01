using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            //CardTest();
            //DeckTest();
            //HandTest();
            //StandardCardTest();
            //PokerDeckTest();
            //TestOutKeyword();
            //HandNotFound();

        }

        private static void CardTest()
        {
            Card defaultCard = new Card();
            Card myCard = new Card("Card1");
            Card myCard2 = new Card("Card2",Card.Face.FRONT);

            Console.WriteLine();
            Console.WriteLine("Basic Card Test...");
            Console.WriteLine();
            Console.WriteLine("Face Up Default Card: {0}",defaultCard.GetVisibleDisplayName());
            defaultCard.SetFace(Card.Face.BACK);
            Console.WriteLine("Facedown Default Card: {0}", defaultCard.GetVisibleDisplayName());
            Console.WriteLine("Forced Name Default Card: {0}", defaultCard.GetDisplayName());
            Console.WriteLine();
            Console.WriteLine("Facedown myCard: {0}", myCard.GetVisibleDisplayName());
            Console.WriteLine("Forced Name myCard: {0}", myCard.GetDisplayName());
            myCard.SetFace(Card.Face.FRONT);
            Console.WriteLine("Faceup myCard: {0}", myCard.GetVisibleDisplayName());
            Console.WriteLine();
            Console.WriteLine("Faceup myCard2: {0}", myCard2.GetVisibleDisplayName());
            myCard2.SetFace(Card.Face.BACK);
            Console.WriteLine("Facedown myCard2: {0}", myCard2.GetVisibleDisplayName());
            Console.WriteLine("Forced Name myCard2: {0}", myCard2.GetDisplayName());
        }

        private static void StandardCardTest()
        {
            StandardCard defaultStandardCard = new StandardCard();
            StandardCard myStandardCard = new StandardCard(3, StandardCard.Suit.CLUB);
            StandardCard myStandardCard2 = new StandardCard(1, StandardCard.Suit.DIAMOND, Card.Face.FRONT);
            StandardCard myStandardCard3 = new StandardCard(11, StandardCard.Suit.HEART, Card.Face.FRONT);
            StandardCard myStandardCard4 = new StandardCard(12, StandardCard.Suit.SPADE, Card.Face.FRONT);
            StandardCard myStandardCard5 = new StandardCard(13, StandardCard.Suit.DIAMOND, Card.Face.FRONT);

            Console.WriteLine();
            Console.WriteLine("Standard Card Test...");

            Console.WriteLine();
            Console.WriteLine("Default Card: {0}",defaultStandardCard.GetVisibleDisplayName());
            Console.WriteLine("Forced Name Default Card: {0}", defaultStandardCard.GetDisplayName());
            defaultStandardCard.SetFace(Card.Face.FRONT);
            Console.WriteLine("Default Card flipped: {0}", defaultStandardCard.GetVisibleDisplayName());

            Console.WriteLine();
            Console.WriteLine("myStandardCard: {0}", myStandardCard.GetVisibleDisplayName());
            Console.WriteLine("Forced Name myStandardCard: {0}", myStandardCard.GetDisplayName());
            myStandardCard.SetFace(Card.Face.FRONT);
            Console.WriteLine("myStandardCard flipped: {0}", myStandardCard.GetVisibleDisplayName());

            Console.WriteLine();
            Console.WriteLine("myStandardCard2: {0}", myStandardCard2.GetVisibleDisplayName());
            myStandardCard2.SetFace(Card.Face.BACK);
            Console.WriteLine("myStandardCard2 flipped: {0}", myStandardCard2.GetVisibleDisplayName());
            Console.WriteLine("Forced Name myStandardCard2: {0}", myStandardCard2.GetDisplayName());

            Console.WriteLine();
            Console.WriteLine("myStandardCard3: {0}", myStandardCard3.GetVisibleDisplayName());
            myStandardCard3.SetFace(Card.Face.BACK);
            Console.WriteLine("myStandardCard3 flipped: {0}", myStandardCard3.GetVisibleDisplayName());
            Console.WriteLine("Forced Name myStandardCard3: {0}", myStandardCard3.GetDisplayName());

            Console.WriteLine();
            Console.WriteLine("myStandardCard4: {0}", myStandardCard4.GetVisibleDisplayName());
            myStandardCard4.SetFace(Card.Face.BACK);
            Console.WriteLine("myStandardCard4 flipped: {0}", myStandardCard4.GetVisibleDisplayName());
            Console.WriteLine("Forced Name myStandardCard4: {0}", myStandardCard4.GetDisplayName());

            Console.WriteLine();
            Console.WriteLine("myStandardCard5: {0}", myStandardCard5.GetVisibleDisplayName());
            myStandardCard5.SetFace(Card.Face.BACK);
            Console.WriteLine("myStandardCard5 flipped: {0}", myStandardCard5.GetVisibleDisplayName());
            Console.WriteLine("Forced Name myStandardCard5: {0}", myStandardCard5.GetDisplayName());
        }

        private static void HandTest()
        {
            Hand defaultHand = new Hand();
            Hand hand1 = new Hand("hand1");
            Card[] testCards = new Card[5];
            for(int i = 0; i < 5; i++)
            {
                testCards[i] = new Card(Convert.ToString(i));
            }
            Hand hand2 = new Hand("hand2", testCards);
            for (int i = 0; i < 5; i++)
            {
                testCards[i] = new StandardCard(i, (StandardCard.Suit)i);
            }
            Hand hand3 = new Hand("hand3", testCards);
            DisplayCards(defaultHand);

            DisplayCards(hand1);
            Console.WriteLine("Adding Card to Hand...");
            hand1.AddToCollection(testCards[0]);
            DisplayCards(hand1);
            Console.WriteLine("Removing Card from Hand...");
            try
            {
                hand1.RemoveFromCollection(testCards[0]);
            }
            catch (CardNotFoundException e)
            {
                Console.WriteLine("ERROR: {0} not found", e.Message);
            }
            Console.WriteLine("Removing Card from empty Hand...");
            try
            {
                hand1.RemoveFromCollection(testCards[0]);
            }
            catch(CardNotFoundException e)
            {
                Console.WriteLine("SUCCESS: {0} not found", e.Message);
            }

            DisplayCards(hand2);
            DisplayCards(hand3);
        }

        private static void DeckTest()
        {
            Console.WriteLine();
            Console.WriteLine("Basic Deck Test");
            Card[] testCards = new Card[10];
            Card test;
            for(int i = 0; i < 10; i++)
            {
                testCards[i] = new Card(Convert.ToString(i));
                testCards[i].SetFace(Card.Face.FRONT);
            }
            Deck myDeck = new Deck("testDeck", testCards);

            Console.WriteLine("Shuffle Deck...");
            myDeck.Shuffle();//test shuffle method
            DisplayCards(myDeck);//prove shuffle worked. Started as 0-9
            Console.WriteLine("Add Card to Deck...");
            myDeck.AddToCollection(new Card("This is a Test Card",Card.Face.FRONT));

            Console.WriteLine("Display top Card");
            Console.WriteLine(myDeck.Display().GetVisibleDisplayName());

            Console.WriteLine("Draw Cards...");
            for (int i = 0; i < 11; i++)
            {
                Console.WriteLine("Card {0}: {1}",i+1,myDeck.DrawTopCard().GetVisibleDisplayName());//print card drawn
            }
            Console.WriteLine();
            Console.WriteLine("Shuffle Empty Deck...");
            myDeck.Shuffle();//shuffle empty deck
            Console.WriteLine();
            Console.WriteLine("Draw from Empty Deck...");
            if ((test = myDeck.DrawTopCard()) != null)
            {
                Console.WriteLine("ERROR: Card Drawn from Empty Deck: {0}",test.GetVisibleDisplayName());//draw on empty deck test
            }

            Console.WriteLine();
            Console.WriteLine("Adding a collection to an existing Deck...");
            Deck secondDeck = new Deck("Second deck", testCards);
            myDeck.AddToCollection(secondDeck);
            DisplayCards(myDeck);
        }

        private static void PokerDeckTest()
        {
            Console.WriteLine();
            Console.Write("Poker Deck Test");

            PokerDeck testPokerDeck = new PokerDeck("With Jokers", true, Card.Face.FRONT);
            PokerDeck testPokerDeck2 = new PokerDeck("Without Jokers", false, Card.Face.FRONT);

            Console.WriteLine();
            Console.WriteLine("Joker Deck...");
            DisplayCards(testPokerDeck);

            Console.WriteLine();
            Console.WriteLine("No Joker Deck...");
            DisplayCards(testPokerDeck2);

            testPokerDeck.Shuffle();
            testPokerDeck2.Shuffle();

            Console.WriteLine();
            Console.WriteLine("Joker Deck Shuffled...");
            DisplayCards(testPokerDeck);

            Console.WriteLine();
            Console.WriteLine("No Joker Deck Shuffled...");
            DisplayCards(testPokerDeck2);
        }
        
        private static void DisplayCards(CardCollection toDisplay)
        {
            Console.WriteLine();
            Console.WriteLine("{0} {1}: ", toDisplay.GetType().Name,toDisplay.GetDisplayName());
            int i = 0;
            Card[] cardsToDisplay = toDisplay.CardsInCollection();
            foreach(Card toShow in cardsToDisplay)
            {
                if (i < 11)
                {
                    Console.Write("{0}, ", toShow.GetVisibleDisplayName());
                    i++;
                }
                else
                {
                    Console.WriteLine("{0}, ", toShow.GetVisibleDisplayName());
                    i = 0;
                }
                
            }
            Console.WriteLine();
        }

        private static void TestOutKeyword()
        {
            CardCollection myHand = new Hand();
            myHand.AddToCollection(new Card("card 1"));
            myHand.AddToCollection(new Card("card 2"));

            TestOut(ref myHand);

            Card[] cardArray = myHand.CardsInCollection();

            foreach (Card asdf in cardArray)
            {
                Console.WriteLine(asdf.GetDisplayName());
            }
        }

        private static void TestOut(ref CardCollection cardsWon)
        {
            cardsWon.AddToCollection(new Card("card 3"));
        }

        private static void HandNotFound()
        {
            Player myPlayer = new Player("Me", new Deck("deckname", new Card[0]));

            try
            {
                myPlayer.getPlayerCollection("notfound");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("The deck was not found");
            }
        }
    }
}
