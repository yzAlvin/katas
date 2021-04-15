using System.Threading;
using System;
using System.IO;
using System.Linq;

namespace Game_of_Life
{
    public class Game
    {
        private readonly TextReader _consoleReader;
        private readonly TextWriter _consoleWriter;
        private World world;
        private char livingCellCharacter = '*';
        private char deadCellCharacter = '.';
        private int generation = 1;

        public Game(TextReader consoleReader, TextWriter consoleWriter)
        {
            _consoleReader = consoleReader;
            _consoleWriter = consoleWriter;
        }

        public void Run()
        {
            GetWorldSize();
            GetWorld();
            StartWorld();
        }

        private void StartWorld()
        {
            do
            {
                WriteGeneration();
                Thread.Sleep(1500);
                _consoleWriter.WriteLine(WorldRenderer.DisplayWorld(world));
                world.Tick();
            } while (!world.IsEmpty());
            WriteGeneration();
            _consoleWriter.WriteLine(WorldRenderer.DisplayWorld(world));
        }

        private void WriteGeneration()
        {
            _consoleWriter.WriteLine($"Generation {generation}: ");
            generation++;
        }

        private void GetWorld()
        {
            for (var x = 0; x < world.Height; x++)
            {
                var row = _consoleReader.ReadLine().ToString();
                while (!ValidRow(row))
                {
                    row = _consoleReader.ReadLine().ToString();
                }
                for(var y = 0; y < world.Width; y++)
                {
                    if (row[y] == livingCellCharacter) world.SetLivingAt(new Location(x, y));
                }
            }
        }

        private bool ValidRow(string row)
        {
            return row.Length == world.Width && row.All(c => c == livingCellCharacter || c == deadCellCharacter);
        }

        private void GetWorldSize()
        {
            var size = _consoleReader.ReadLine().ToString();
            while (!ValidFieldSize(size))
            {
                size = _consoleReader.ReadLine().ToString();
            }
            this.world = new World(ParseSize(size[0]), ParseSize(size[2]));
        }

        private bool EndOfInput(string input)
        {
            const string endOfInputCode = "d";
            return input == endOfInputCode;
        }

        private bool ValidFieldSize(string input) => input.Length == 3 && IsValidInt(input[0]) && IsValidInt(input[2]);

        private int ParseSize(char n) => int.Parse(n.ToString());

        private bool IsValidInt(char size) => int.TryParse(size.ToString(), out var dimension)  && dimension > 0 && dimension < 50;
    }
}