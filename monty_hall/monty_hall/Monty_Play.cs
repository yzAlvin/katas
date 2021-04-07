using System;

namespace monty_hall
{
    public class Monty_Play
    {
        public static void SimulateGame(int numberOfSimulations, int numberOfDoors, bool switchDoor)
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
