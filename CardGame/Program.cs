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
            //StandardCardTest();
            //DeckTest();
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
            StandardCard defaultStandardCard = new StandardCard();//Why?
            StandardCard myStandardCard = new StandardCard(1, StandardCard.Suit.CLUB);
            StandardCard myStandardCard2 = new StandardCard(2, StandardCard.Suit.DIAMOND, Card.Face.FRONT);

            Console.WriteLine();
            Console.WriteLine("Standard Card Test...");
            Console.WriteLine("Default Card: {0}",defaultStandardCard.GetDisplayName());
            Console.WriteLine("myStandardCard: {0}", myStandardCard.GetDisplayName());
            Console.WriteLine("myStandardCard2: {0}", myStandardCard2.GetDisplayName());
            defaultStandardCard.SetFace(Card.Face.BACK);
            myStandardCard.SetFace(Card.Face.FRONT);
            myStandardCard2.SetFace(Card.Face.BACK);
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
