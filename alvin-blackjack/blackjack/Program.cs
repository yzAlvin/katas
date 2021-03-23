using System;
using System.Linq;

namespace blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Blackjack!");

            Hand dealerHand = new Hand();
            Hand playerHand = new Hand();
            Deck deck = new Deck();
            deck.CreateDeck();

            playerHand.AddCard(deck.Draw());
            playerHand.AddCard(deck.Draw());
            dealerHand.AddCard(deck.Draw());
            dealerHand.AddCard(deck.Draw());

            Console.WriteLine("Dealer's Hand: ");
            Console.WriteLine(dealerHand.ToString());

            Console.WriteLine("Player's Hand: ");
            Console.WriteLine(playerHand.ToString());

            Console.WriteLine("==========================");
            var winner = "";

            while (true)
            {
                var card = Hit(dealerHand, deck);
                Console.WriteLine($"\nDealer draws {card}");
                Console.WriteLine($"Dealer is at {dealerHand.ToString()} [{dealerHand.Value}]");
                if (dealerHand.IsBust()) break;

                var choice = promptPlayer();
                if (choice == "1")
                {
                    Hit(playerHand, deck);
                    Console.WriteLine($"\nPlayer draws {card}");
                    Console.WriteLine($"Player is at {playerHand.ToString()} [{playerHand.Value}]");
                    if (playerHand.IsBust()) break;
                }
                else
                {
                    break;
                }
            }
            winner = calcWinner(dealerHand, playerHand);
            Console.WriteLine(winner);
        }

        static private Card Hit(Hand player, Deck deck)
        {
            var card = deck.Draw();
            player.AddCard(card);
            return card;
        }

        static private string promptPlayer()
        {
            var choice = "";
            while (choice != "1" && choice != "0")
            {
                Console.WriteLine("\n Hit or stay? (Hit = 1, Stay = 0) ");
                choice = Console.ReadLine();
            }
            return choice;
        }

        static private string calcWinner(Hand dealer, Hand player)
        {
            if (dealer.IsBust()) return "Player Wins!";
            if (player.IsBust()) return "Dealer Wins!";
            return dealer.Value > player.Value ? "Dealer Wins!" : "Player Wins!";
        }
    }
}
