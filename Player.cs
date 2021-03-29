using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Player
    {
        //-----Properties-----
        public List<Card> Hand = new List<Card>();
        public Card LastDrawnCard;

        //-----Methods-----
        public int LowValue()
        {
            int sum = 0;
            foreach (Card card in Hand)
            {
                int value = Convert.ToInt32(card.Value);
                if (value > 10)
                {
                    value = 10;
                }
                sum += value;
            }
            return sum;
        }
        public int HighValue()
        {
            int sum = 0;
            foreach (Card card in Hand)
            {
                int value = Convert.ToInt32(card.Value);
                if (value == 1)
                {
                    value = 11;
                }
                if (value > 10)
                {
                    value = 10;
                }
                sum += value;
            }
            return sum;
        }
        public int BestValue(int low, int high)
        {
            if (high > 21)
            {
                return low;
            }
            else
            {
                return high;
            }           
        }       
        public override string ToString()
        {
            string trosor = "";
            foreach (Card card in Hand)
            {
                trosor += card.ToString() + "\n";
            }           
            return trosor;
        }
    }
}
