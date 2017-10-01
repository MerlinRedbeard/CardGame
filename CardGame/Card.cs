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
        public enum Face { FRONT, BACK };
        private Face showing;

        public Card() : this("Default Card Text",Face.FRONT) { }

        public Card(string newName) : this(newName,Face.BACK) { }

        public Card(string newName,Face toShow) 
        {
            displayName = newName;
            showing = toShow;
        }

        public string GetDisplayName()
        {
            return displayName;
        }

        public string GetVisibleDisplayName()
        {
            if (showing == Face.FRONT)
            {
                return displayName;
            }
            else
            {
                return "<back>";
            }
        }
     
        public Card SetFace(Face toShow)
        {
            showing = toShow;
            return this;
        }

    }
}
