using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class StandardCard : Card
    {
        private int cardValue;
        public enum Suit {SPADE,HEART,DIAMOND,CLUB};
        private Suit cardSuit;

        public StandardCard() : this(0,Suit.SPADE,Face.FRONT)
        {
            //program kept griping about not having a default constructor.  Should it have one?
        }

        public StandardCard(int Value, Suit newSuit) : this(Value, newSuit, Face.BACK)
        {
        }

        public StandardCard(int value, Suit newSuit, Face setFace) : this(string.Concat(value, " ", newSuit.ToString()), value, newSuit, setFace)
        {
        }

        public StandardCard(string setName, int value, Suit newSuit, Face setFace) : base(setName, setFace)
        {
            cardValue = value;
            cardSuit = newSuit;
        }

        public int GetValue() => cardValue;

        public Suit GetSuit() => cardSuit;
    }
}
