using System;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the table!");
            //skapar en kortlek avv klassen Deck men en(1) kortlek
            Deck deck = new Deck(1);
            deck.Shuffle();
            
            foreach (var card in deck.Cards)
            {
                Console.WriteLine(card.ToString());
                
            }  
          
            Console.ReadKey();
        }                                    
    }
}
