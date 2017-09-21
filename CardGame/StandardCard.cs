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
        public enum Suit {SPADE,HEART,DIAMOND,CLUB,JOKER};
        private Suit cardSuit;

        public StandardCard() : this(Face.BACK) { }//Creates face-down Joker

        public StandardCard(Card.Face setFace) : this(0, Suit.JOKER, setFace) { }//Creates Joker face up or down

        public StandardCard(int Value, Suit newSuit) : this(Value, newSuit, Face.BACK) { }

        public StandardCard(int value, Suit newSuit, Face setFace) : base(CreateDisplayName(value,newSuit),setFace)
        {
            cardValue = value;
            cardSuit = newSuit;
        }

        public int GetValue() => cardValue;

        public Suit GetSuit() => cardSuit;

        private static string CreateDisplayName(int value, Suit cardSuit)
        {
            switch (value)
            {
                case 0:
                    return "Joker";
                case 1:
                    return string.Concat("A ", cardSuit.ToString());
                case 11:
                    return string.Concat("J ", cardSuit.ToString());
                case 12:
                    return string.Concat("Q ", cardSuit.ToString());
                case 13:
                    return string.Concat("K ", cardSuit.ToString());
                default:
                    return string.Concat(value, " ", cardSuit.ToString());
            }
        }
    }
}
