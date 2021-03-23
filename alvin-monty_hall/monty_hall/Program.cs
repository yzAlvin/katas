using System.Reflection;
using System.Reflection.Metadata;
using System;

namespace monty_hall
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to a Monty Hall Simulation");
            Console.WriteLine("How many simulations would you like to run: ");
            var numberOfSimulations = Int32.Parse(Console.ReadLine());
            Console.WriteLine("How many doors would you like to simulate: ");
            var numberOfDoors = Int32.Parse(Console.ReadLine());

            SimulateGame(numberOfSimulations, numberOfDoors, false);

            SimulateGame(numberOfSimulations, numberOfDoors, true);
        }

        private static void SimulateGame(int numberOfSimulations, int numberOfDoors, bool switchDoor)
        {
            Random random = new Random();
            int numberOfWins = 0;

            for (var i = 0; i < numberOfSimulations; i++)
            {
                Monty game = new Monty(numberOfDoors);
                game.PickDoor(random.Next(0, numberOfDoors));
                if (switchDoor)
                {
                    game.RevealDoors();
                    game.SwitchDoor();
                }
                if (game.IsWin())
                {
                    numberOfWins++;
                }
            }
            
            Console.WriteLine($"\nOver {numberOfSimulations} simulations:\n");
            Console.WriteLine(switchDoor ? "If you DID switch" : "If you DIDN'T switch");
            Console.WriteLine($"There were {numberOfWins} wins and {numberOfSimulations - numberOfWins} losses.");

        }
    }
}
