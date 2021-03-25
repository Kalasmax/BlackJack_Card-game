using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Deck
    {
        private const int DECK_SIZE = 52;
        private const int SUIT_COUNT = 4;
        private const int CARD_COUNT = 13;

        private int nrOfDecks = 1;

        public List<Card> Cards { get; set; }

        //i konstruktorn så bestäms antalet kortlekar
        public Deck(int nrOfDecks)
        {
            this.nrOfDecks = nrOfDecks;
            Cards = Setup();                             
        }
        
        public void Shuffle()
        {
            var random = new Random();
            int count = Cards.Count; //52 som kortleken
            while (count > 1)
            {
                count--;
                int randomNumber = random.Next(count + 1);
                Card card = Cards[randomNumber];
                Cards[randomNumber] = Cards[count];
                Cards[count] = card;
            }
        }
        
        public Card Draw()
        {
            // ett försök att skapa kort slumpmässigt med Random
            Random random = new Random();

            int cardShuffler = random.Next(1, 53);
            CardValue cardvalue = new CardValue();
            CardSuitType cardsuit = new CardSuitType();

            if (cardShuffler <= 13)
            {
                cardsuit = CardSuitType.Spades;
                cardvalue = (CardValue)cardShuffler;
            }
            if (cardShuffler >= 14 && cardShuffler <= 26)
            {
                cardsuit = CardSuitType.Hearts;
                int newCardValue = cardShuffler - 13;
                cardvalue = (CardValue)newCardValue;
            }
            if (cardShuffler >= 27 && cardShuffler <= 39)
            {
                cardsuit = CardSuitType.Diamond;
                int newCardValue = cardShuffler - 26;
                cardvalue = (CardValue)newCardValue;
            }
            if (cardShuffler >= 40)
            {
                cardsuit = CardSuitType.Clubs;
                int newCardValue = cardShuffler - 39;
                 cardvalue = (CardValue)newCardValue;
            }

            // skapar objektet cards av klassen Card
            Card cards = new Card(cardvalue, cardsuit);
            return cards;
        }

        private List<Card> Setup()
        {
            var cards = new List<Card>();
            

            for (int i = 1; i <= SUIT_COUNT; i++)
            {
                for (int j = 1; j <= CARD_COUNT; j++)
                {
                    cards.Add(new Card((CardValue)j,(CardSuitType)i));
                }                               
            }

            return cards;
        }

    }   
}
