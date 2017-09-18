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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            // Card myCard = new Card("A Spades");
            //
            // Console.WriteLine(myCard.GetDisplayName());
            // myCard.FlipFaceUp();
            // Console.WriteLine(myCard.GetDisplayName());
            // myCard.FlipFaceDown();
            // Console.WriteLine(myCard.GetDisplayName());
        }
    }
}
