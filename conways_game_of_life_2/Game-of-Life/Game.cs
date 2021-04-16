using System.Threading;
using System;
using System.IO;
using System.Linq;

namespace Game_of_Life
{
    public class Game
    {
        private readonly TextReader _reader;
        private readonly TextWriter _writer;
        private World world;
        private char livingCellCharacter = '*';
        private char deadCellCharacter = '.';
        private int generation = 1;

        public Game(TextReader reader, TextWriter writer)
        {
            _reader = reader;
            _writer = writer;
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
                Thread.Sleep(100);
                _writer.WriteLine(WorldRenderer.DisplayWorld(world));
                world.Tick();
            } while (!world.IsEmpty());
            WriteGeneration();
            _writer.WriteLine(WorldRenderer.DisplayWorld(world));
        }

        private void WriteGeneration()
        {
            _writer.WriteLine($"Generation {generation}: ");
            generation++;
        }

        private void GetWorld()
        {
            for (var x = 0; x < world.Height; x++)
            {
                var row = _reader.ReadLine().ToString();
                while (!ValidRow(row))
                {
                    row = _reader.ReadLine().ToString();
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
            var size = _reader.ReadLine().ToString();
            while (!ValidWorldSize(size))
            {
                size = _reader.ReadLine().ToString();
            }
            var worldSize = size.Split("x");
            this.world = new World(ParseSize(worldSize[0]), ParseSize(worldSize[1]));
        }

        private bool EndOfInput(string input)
        {
            const string endOfInputCode = "d";
            return input == endOfInputCode;
        }

        private bool ValidWorldSize(string input){
            var worldSize = input.Split("x");
            return IsValidInt(worldSize[0]) && IsValidInt(worldSize[1]);
        }

        private int ParseSize(string n) => int.Parse(n.ToString());

        private bool IsValidInt(string size) => int.TryParse(size.ToString(), out var dimension)  && dimension > 0 && dimension < 50;
    }
}