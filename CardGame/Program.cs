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

            CardTest();
            DeckTest();
        }

        private static void CardTest()
        {
            Card myCard = new Card("A Spades");
            Card myCard2 = new Card("2 Spades",Card.Face.FRONT);

            Console.WriteLine();
            Console.WriteLine(myCard.GetDisplayName());
            Console.WriteLine(myCard2.GetDisplayName());
            myCard.SetFace(Card.Face.FRONT);
            Console.WriteLine(myCard.GetDisplayName());
            myCard2.SetFace(Card.Face.BACK);
            Console.WriteLine(myCard2.GetDisplayName());
            Console.WriteLine();
        }

        private static void DeckTest()
        {
            Console.WriteLine();
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
            myDeck.AddToDeck(new Card("ASDFASDFASDF",Card.Face.FRONT));

            Console.WriteLine("Display top Card");
            test = myDeck.Display();
            Console.WriteLine(test.GetDisplayName());

            Console.WriteLine("Draw Cards...");
            for (int i = 0; i < 11; i++)
            {
                Console.WriteLine(myDeck.DrawTopCard().GetDisplayName());//print card drawn
            }
            Console.WriteLine();
            Console.WriteLine("Shuffle Empty Deck...");
            myDeck.Shuffle();//shuffle empty deck
            Console.WriteLine();
            Console.WriteLine("Draw from Empty Deck...");
            if ((test = myDeck.DrawTopCard()) != null)
            {
                Console.WriteLine(string.Concat("ERROR: Card Drawn from Empty Deck: ",test.GetDisplayName()));//draw on empty deck test
            }
            Console.WriteLine();
        }

        private static void DisplayDeck(Deck toDisplay)
        {
            Console.WriteLine();
            Card[] cardsToDisplay = toDisplay.CardsInDeck();
            Console.WriteLine(string.Concat("Deck ", toDisplay.GetDisplayName(), ":"));
            foreach(Card toShow in cardsToDisplay)
            {
                Console.WriteLine(toShow.GetDisplayName());
            }
            Console.WriteLine();
        }
    }
}
