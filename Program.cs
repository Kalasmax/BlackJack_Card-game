using System;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            //-----Menu ASCII art-----
            static void CoolPic()
            {
                Console.WriteLine("                                            _____  __   ");
                Console.WriteLine(" _____                       _____         / __  `/  |  ");
                Console.WriteLine("|2    |               _____ |6    |        `' / /'`| |  ");
                Console.WriteLine("|  ^  | _____        |5    || ^ ^ |          / /   | |  ");
                Console.WriteLine("|     ||3    | _____ | ^ ^ || ^ ^ | _____  _/ /__ _| |_ ");
                Console.WriteLine("|  ^  || ^ ^ ||4    ||  ^  || ^ ^ ||7    ||______||____|");
                Console.WriteLine("|____z||     || ^ ^ || ^ ^ ||____9|| ^ ^ | _____        ");
                Console.WriteLine("       |  ^  ||     ||____s|       |^ ^ ^||8    | _____ ");
                Console.WriteLine("       |____E|| ^ ^ |              | ^ ^ ||^ ^ ^||9    |");
                Console.WriteLine("              |____h|              |____L|| ^ ^ ||^ ^ ^|");
                Console.WriteLine("                                          |^ ^ ^||^ ^ ^|");
                Console.WriteLine("        B l a c k    J a c k              |____8||^ ^ ^|");
                Console.WriteLine("                                                 |____6|");
            }

            //-----Age verification-----
            CoolPic();
            Console.WriteLine("Are you 18 years old or above legal age?");

            //-----Menu-----
            string menuOpt = "0";
            while (menuOpt != "99")
            {               
                Console.WriteLine("1) Yes.");
                Console.WriteLine("2) No.");                
                menuOpt = Console.ReadLine();
                
                switch (menuOpt) 
                {
                    case "1":
                        bool boolMenuOpt = false;
                    do
                    {
                         Console.Clear();
                         playGame();
                          Console.Clear();
                          Console.WriteLine("Play again?");
                          Console.WriteLine("1) Yes.");
                          Console.WriteLine("2) No.");
                          string playAgain = Console.ReadLine();

                         if (playAgain == "1") 
                         {
                            boolMenuOpt = true;
                         }
                         else
                         {
                            break;
                         }

                    } while (boolMenuOpt);                        
                     break;

                    // Shuts the program down
                    case "2": 
                        Console.WriteLine("Welcome back another time. . .");
                        System.Environment.Exit(1); 
                         break;
                    // Catches the wrong input
                    default: 
                         Console.WriteLine("Wrong input, choose an alternative in the menu. . .");
                         break;
                }
            }
            //-----Methods-----
            static void playGame()
            {
                // Welcome message
                CoolPic();
                Console.WriteLine("Welcome to the table, please enter your name:  ");
                string playerName = Console.ReadLine();
                Console.Clear();
                CoolPic();
                Console.WriteLine($"Nice to meet you {playerName}, let's play!");
                Console.WriteLine("Press any key to continue. . .");
                Console.ReadKey();
                Console.Clear();
                CoolPic();
                
                Game game = new Game();
                
                
                //-----Not in use-----
                /*  //Loop to see if all 4 decks were complete and shuffled
                foreach (var card in deck.Cards)
                {
                    Console.WriteLine(card.ToString());
                }
                */
            }     
           
            Console.ReadKey();
        }                                    
    }
}
