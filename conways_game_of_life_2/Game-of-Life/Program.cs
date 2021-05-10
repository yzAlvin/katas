using System.IO;
using System.Linq;
using System;

namespace Game_of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] possibleInputMethods = new string[] { "file", "console" };

            if (args.Length != 1 || !possibleInputMethods.Contains(args[0]))
            {
                PrintProperUsage();
                return;
            }

            var sleeper = new Sleeper();

            if (args[0] == "console")
            {
                var game = new Game(Console.In, Console.Out, sleeper);
                game.Run();
            }

            if (args[0] == "file")
            {
                // DeadCell.SetString("@");
                // LivingCell.SetString("#");
                var pathToTestWorld = @"/Users/Alvin.Zhao/Projects/katas/conways_game_of_life_2/Game-of-Life/exampleWorlds/exampleWorld.txt";
                var fileReader = File.OpenText(pathToTestWorld);
                var game = new Game(fileReader, Console.Out, sleeper);
                game.Run();
                fileReader.Close();
            }
        }

        private static void PrintProperUsage()
        {
            Console.WriteLine("Please enter the input method argument.");
            Console.WriteLine("Usage: Life <file|console>");
        }
    }
}
