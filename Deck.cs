using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Deck
    {
        //-----Properties-----
        private const int DECK_SIZE = 52;
        private const int SUIT_COUNT = 4;
        private const int CARD_COUNT = 13;
        private int nrOfDecks;

        public List<Card> Cards = new List<Card>();
        public int drawnCards = 0;

        //-----Constructor-----
        public Deck(int nrOfDecks)
        {
            this.nrOfDecks = nrOfDecks;
            Setup(nrOfDecks);                             
        }

        //-----Methods-----
        public void Shuffle()
        {
            var random = new Random();
            int count = Cards.Count; 
            while (count > 1)
            {
                count--;
                int randomNumber = random.Next(count + 1);
                Card card = Cards[randomNumber];
                Cards[randomNumber] = Cards[count];
                Cards[count] = card;
            }
            drawnCards = 0;
        }      
        public Card Draw()
        {
            if (drawnCards > (Cards.Count / 2))
            {
                Shuffle();
            }
            Card drawnCard = Cards[drawnCards];                       
            drawnCards ++;           
            return drawnCard;
        }
        public void Setup(int nrOfDecks)
        {
            if(Cards != null)            
                Cards.Clear();

            for (int k = 0; k < nrOfDecks; k++)
            {
                for (int i = 1; i <= SUIT_COUNT; i++)
                {
                    for (int j = 1; j <= CARD_COUNT; j++)
                    {
                        Card shuffledCardDeck = new Card(j, i);

                        Cards.Add(shuffledCardDeck);
                    }
                }
            }                     
        }
    }   
}
