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

        public Card(string newName) : this(newName,Face.BACK)
        {
        }

        public Card(string newName,Face toShow) 
        {
            displayName = newName;
            showing = toShow;
        }

        public string GetDisplayName()
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
     
        public void SetFace(Face toShow)
        {
            showing = toShow;
        }

    }
}
