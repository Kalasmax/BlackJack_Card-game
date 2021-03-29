using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{    
    class Game
    {
        //-----Properties-----
        public Player player = new Player();
        public Player dealer = new Player();
        public Deck deck = new Deck(4);

        public Game()
        {
            // Shuffle the deck before dealing
            deck.Shuffle();

            // Dealing out the entry hand for player & dealer
            Console.WriteLine($"Your 1st card: {playerDraw()}.");
            Console.WriteLine($"Dealer's 1st card: {dealerDraw()}.");
            Console.WriteLine($"Your 2nd card: {playerDraw()}.");
            Console.WriteLine("Dealers 2nd card is hidden.");
            string hiddenDraw = dealerDraw();

            // Game logistics & rules
            bool playerStop = false;
            bool activeGame = true;          
            while (activeGame)
            {
                int sum = 0;
                bool containsAce = false;
                foreach (Card card in player.Hand)
                {
                    int value = Convert.ToInt32(card.Value);
                    if (value == 1)
                    {
                        containsAce = true;
                    }
                    if (value > 10)
                    {
                        value = 10;
                    }
                    sum += value;
                }
                
                if (!playerStop)
                {
                    if (containsAce)
                    {
                        int lowValue = player.LowValue();
                        int highValue = player.HighValue();
                        if (lowValue > 21)
                        {
                            Console.WriteLine($"You busted on: {sum}, press any key to play again. . .");
                            activeGame = false;
                            break;
                        }
                        Console.WriteLine($"Your low value: {lowValue}.");
                        if (highValue < 21)
                        {
                            Console.WriteLine($"Your high value: {highValue}.");
                        }
                    }
                    else
                    {
                        if (sum > 21)
                        {
                            Console.WriteLine($"You busted on: {sum}, press any key to play again. . .");
                            activeGame = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Your current value: {sum}.");                            
                        }
                    }

                    Console.WriteLine("Draw another card?");
                    Console.WriteLine("1) Yes.");
                    Console.WriteLine("2) No.");
                    string playAgain = Console.ReadLine();

                    if (playAgain == "1")
                    {
                        playerDraw();
                    }
                    else
                    {
                        playerStop = true;
                        sum = player.BestValue(player.LowValue(), player.HighValue());
                    }
                } 
                
                int dealerValue = 0;
                do
                {                    
                    dealerValue = Convert.ToInt32(dealer.HighValue());
                    if (dealerValue > 21)
                    {
                        Console.WriteLine($"Dealer busted on: {dealerValue}, you won! ");
                        Console.WriteLine("Press any key to play again. . .");
                        activeGame = false;
                        break;
                    }
                    else if (dealerValue > sum && playerStop == true)
                    {                       
                        Console.WriteLine($"You lost, you have: {sum}. Dealer has: {dealerValue}.");
                        Console.WriteLine("Press any key to play again. . .");
                        activeGame = false;
                        break;
                    }
                    else if (dealerValue <= 16)
                    {
                        dealerDraw();                       
                    }

                    else if (dealerValue >= 17)
                    {
                        if (playerStop)
                        {
                            if (sum > dealerValue)
                            {
                                Console.WriteLine($"You won on: {sum}.");
                                Console.WriteLine("Press any key to play again. . .");
                            }
                            else if (dealerValue > sum)
                            {
                                Console.WriteLine($"Dealer won on: " + dealerValue);
                                Console.WriteLine("Press any key to play again. . .");
                            }
                            else if (dealerValue == 20 && sum == 20)
                            {
                                Console.WriteLine("It's a tie, both of you got 20.");
                                Console.WriteLine("Press any key to play again. . .");
                            }
                            else
                            {
                                Console.WriteLine($"Dealer won on, you both got: {dealerValue}.");
                                Console.WriteLine("Press any key to play again. . .");
                            }
                            activeGame = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Dealer stopped on: {dealerValue}.");
                        }
                    }
                }
                while (playerStop && dealerValue < 16);                                     
            }           
            Console.ReadLine();
        }

        //-----Methods-----
        public void Reset()
        {
            player.Hand.Clear();
            dealer.Hand.Clear();
        }
        public string playerDraw()
        {
            Card drawnCard = deck.Draw();
            player.LastDrawnCard = drawnCard;
            player.Hand.Add(drawnCard);
            return drawnCard.ToString();
        }
        public string dealerDraw()
        {
            Card drawnCard = deck.Draw();
            dealer.LastDrawnCard = drawnCard;
            dealer.Hand.Add(drawnCard);
            return drawnCard.ToString();
        }

        //-----Enum----- 
        //-----Decided not to use this-----
        public enum GameStatus
        {
           Won = 1,
           Lost = 2,
           Playing = 3,
           Tie = 4,
           BlackJack = 5,

        }
    }
}
