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
            //StandardCardTest();
            //PokerDeckTest();
        }

        private static void CardTest()
        {
            Card defaultCard = new Card();
            Card myCard = new Card("Card1");
            Card myCard2 = new Card("Card2",Card.Face.FRONT);

            Console.WriteLine();
            Console.WriteLine("Basic Card Test...");
            Console.WriteLine("Default Card: {0}",defaultCard.GetDisplayName());
            defaultCard.SetFace(Card.Face.BACK);
            Console.WriteLine("Default Card: {0}", defaultCard.GetDisplayName());
            Console.WriteLine("myCard: {0}", myCard.GetDisplayName());
            Console.WriteLine("myCard2: {0}", myCard2.GetDisplayName());
            myCard.SetFace(Card.Face.FRONT);
            Console.WriteLine("myCard: {0}", myCard.GetDisplayName());
            myCard2.SetFace(Card.Face.BACK);
            Console.WriteLine("myCard2: {0}", myCard2.GetDisplayName());
            Console.WriteLine();
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
            Console.WriteLine("Default Card: {0}",defaultStandardCard.GetDisplayName());
            Console.WriteLine("myStandardCard: {0}", myStandardCard.GetDisplayName());
            Console.WriteLine("myStandardCard2: {0}", myStandardCard2.GetDisplayName());
            Console.WriteLine("myStandardCard3: {0}", myStandardCard3.GetDisplayName());
            Console.WriteLine("myStandardCard4: {0}", myStandardCard4.GetDisplayName());
            Console.WriteLine("myStandardCard5: {0}", myStandardCard5.GetDisplayName());
            defaultStandardCard.SetFace(Card.Face.FRONT);
            myStandardCard.SetFace(Card.Face.FRONT);
            myStandardCard2.SetFace(Card.Face.BACK);
            myStandardCard3.SetFace(Card.Face.BACK);
            Console.WriteLine("Default Card flipped: {0}", defaultStandardCard.GetDisplayName());
            Console.WriteLine("myStandardCard flipped: {0}", myStandardCard.GetDisplayName());
            Console.WriteLine("myStandardCard2 flipped: {0}", myStandardCard2.GetDisplayName());
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
            DisplayDeck(myDeck);//prove shuffle worked. Started as 0-9
            Console.WriteLine("Add Card to Deck...");
            myDeck.AddToDeck(new Card("This is a Test Card",Card.Face.FRONT));

            Console.WriteLine("Display top Card");
            Console.WriteLine(myDeck.Display().GetDisplayName());

            Console.WriteLine("Draw Cards...");
            for (int i = 0; i < 11; i++)
            {
                Console.WriteLine("Card {0}: {1}",i+1,myDeck.DrawTopCard().GetDisplayName());//print card drawn
            }
            Console.WriteLine();
            Console.WriteLine("Shuffle Empty Deck...");
            myDeck.Shuffle();//shuffle empty deck
            Console.WriteLine();
            Console.WriteLine("Draw from Empty Deck...");
            if ((test = myDeck.DrawTopCard()) != null)
            {
                Console.WriteLine("ERROR: Card Drawn from Empty Deck: {0}",test.GetDisplayName());//draw on empty deck test
            }
            Console.WriteLine();
        }

        private static void PokerDeckTest()
        {
            Console.WriteLine();
            Console.Write("Poker Deck Test");

            PokerDeck testPokerDeck = new PokerDeck("With Jokers", true);
            PokerDeck testPokerDeck2 = new PokerDeck("Without Jokers", false);

            Card[] jokerDeckCards = testPokerDeck.CardsInDeck();
            Card[] noJokerCards = testPokerDeck2.CardsInDeck();

            Console.WriteLine();
            Console.WriteLine("Joker Deck...");
            foreach (Card jokerCard in jokerDeckCards)
            {
                jokerCard.SetFace(Card.Face.FRONT);
                Console.WriteLine(jokerCard.GetDisplayName());
            }

            Console.WriteLine();
            Console.WriteLine("No Joker Deck...");
            foreach (Card notJokerCard in noJokerCards)
            {
                notJokerCard.SetFace(Card.Face.FRONT);
                Console.WriteLine(notJokerCard.GetDisplayName());
            }

            testPokerDeck.Shuffle();
            testPokerDeck2.Shuffle();
            jokerDeckCards = testPokerDeck.CardsInDeck();
            noJokerCards = testPokerDeck2.CardsInDeck();

            Console.WriteLine();
            Console.WriteLine("Joker Deck Shuffled...");
            foreach (Card jokerCard in jokerDeckCards)
            {
                jokerCard.SetFace(Card.Face.FRONT);
                Console.WriteLine(jokerCard.GetDisplayName());
            }

            Console.WriteLine();
            Console.WriteLine("No Joker Deck Shuffled...");
            foreach (Card notJokerCard in noJokerCards)
            {
                notJokerCard.SetFace(Card.Face.FRONT);
                Console.WriteLine(notJokerCard.GetDisplayName());
            }
        }

        private static void DisplayDeck(Deck toDisplay)
        {
            Console.WriteLine();
            Card[] cardsToDisplay = toDisplay.CardsInDeck();
            Console.Write("Deck {0}: ", toDisplay.GetDisplayName());
            foreach(Card toShow in cardsToDisplay)
            {
                Console.Write("{0} ",toShow.GetDisplayName());
            }
            Console.WriteLine();
        }
    }
}
