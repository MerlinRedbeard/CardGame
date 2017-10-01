using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class WarGameOption : GameOption
    {
        public static readonly WarGameOption ACE_HIGH = new WarGameOption("ACE_HIGH");
        public static readonly WarGameOption ACE_LOW = new WarGameOption("ACE_LOW");
        //These will be implemented at a later time
        //public static readonly WarGameOption ADD_ON = new WarGameOption("ADD_ON");
        //public static readonly WarGameOption THREES_BEAT_FACES = new WarGameOption("THREES_BEAT_FACES");
        //public static readonly WarGameOption FOURS_BEATS_ACES = new WarGameOption("FOURS_BEATS_ACES");
        //public static readonly WarGameOption UNDERDOG = new WarGameOption("UNDERDOG");
        //public static readonly WarGameOption PEACE = new WarGameOption("PEACE");
        //public static readonly WarGameOption STRATEGY = new WarGameOption("STRATEGY");
        //public static readonly WarGameOption WAR_IRL = new WarGameOption("WAR_IRL");
        //public static readonly WarGameOption INSTANT_WAR = new WarGameOption("WAR_IRL");
        //public static readonly WarGameOption FIVE_STRAIGHT_BATTLES = new WarGameOption("FIVE_STRAIGHT_BATTLES");
        //public static readonly WarGameOption SIMPLE_MATH = new WarGameOption("SIMPLE_MATH");
        //public static readonly WarGameOption TWO_CARD_WAR = new WarGameOption("TWO_CARD_WAR");

        protected WarGameOption(string value) : base(value)
        {
        }

        public static GameOption[] GetGameOptions()
        {
            return GameOption.GetConstantOptions(typeof(WarGameOption));
        }

        public static GameOption GetOption(string optionName)
        {
            return GameOption.GetOption(optionName, typeof(WarGameOption));
        }
    }
}
