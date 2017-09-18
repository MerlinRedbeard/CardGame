using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Card
    {
        private string displayName;
        private bool isFaceUp;

        public Card(string newName)
        {
            displayName = newName;
            isFaceUp = false;
        }

        public string GetDisplayName()
        {
            if (isFaceUp)
            {
                return displayName;
            }
            else
            {
                return "<back>";
            }
        }
     
        public void FlipFaceUp()
        {
            isFaceUp = true;
        }

        public void FlipFaceDown()
        {
            isFaceUp = false;
        }

    }
}
