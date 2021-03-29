using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Card
    {
        //-----Properties-----
        public cardSuitType Suit;
        public cardValue Value;

        public Card(int value, int suit)
        {
            Value = (cardValue)value;
            Suit = (cardSuitType)suit;
        }

        //-----Methods-----
        public override string ToString()
        {           
            return $"{Value} of {Suit}";
        }

        //-----Enums----- 
        public enum cardValue
        {
            Ace = 1,
            Deuce = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13,

        }      
        public enum cardSuitType
        {
            Spades = 1,
            Hearts = 2,
            Diamond = 3,
            Clubs = 4,
        }
    }
}
