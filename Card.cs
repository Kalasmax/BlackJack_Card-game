using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Card
    {
        public CardSuitType Suit;
        public CardValue Value;

        public Card(CardValue value, CardSuitType suit)
        {
            Value = value;
            Suit = suit;
        }
        public override string ToString()
        {
            return $"{Value} of {Suit}";            
        }
    }
}
