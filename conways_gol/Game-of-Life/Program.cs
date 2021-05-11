using System.IO;
using System.Linq;
using System;

namespace Game_of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            switch (args[0])
            {
                case "console":
                    ConsoleGame();
                    break;
                case "file":
                    var fileName =
                        args.Length != 2 ? "exampleWorld.txt" : args[1];
                    FileGame(fileName);
                    break;
                default:
                    PrintProperUsage();
                    break;
            }
        }

        private static void FileGame(string fileName)
        {
            var pathToTestWorld = $"Game-of-Life/exampleWorlds/{fileName}";
            var fileReader = File.OpenText(pathToTestWorld);
            var sleeper = new Sleeper();
            var game = new Game(fileReader, Console.Out, sleeper);
            game.Run();
            fileReader.Close();
        }

        private static void ConsoleGame()
        {
            var sleeper = new Sleeper();
            var game = new Game(Console.In, Console.Out, sleeper);
            game.Run();
        }

        private static void PrintProperUsage()
        {
            Console.WriteLine("Please enter the input method argument.");
            Console.WriteLine("Usage: Life <file|console>");
        }
    }
}
