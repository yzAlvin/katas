using System.IO;
using System.Linq;
using System;

namespace Game_of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length <= 0 || args.Length > 2)
            {
                PrintProperUsage();
                return;
            }
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
            Console.WriteLine("To play from console: ");
            Console.WriteLine("Usage: dotnet run --project ~/~.csproj console");
            Console.WriteLine("To play from file: ");
            Console.WriteLine("Usage: dotnet run --project ~/~.csproj file <name_of_file.txt>");
        }
    }
}
