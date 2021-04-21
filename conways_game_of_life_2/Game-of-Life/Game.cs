using System.Threading;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Game_of_Life
{
    public class Game
    {
        private readonly TextReader reader;
        private readonly TextWriter writer;
        private readonly ISleeper sleeper;
        private World world;
        
        private static Dictionary<Type, char> CellCharacters = new Dictionary<Type, char>
        {
            {typeof(LivingCell), '*'},
            {typeof(DeadCell), '.'},
        };

        public Game(TextReader reader, TextWriter writer, ISleeper sleeper)
        {
            this.reader = reader;
            this.writer = writer;
            this.sleeper = sleeper;
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
                // Console.Clear();
                WriteGeneration();
                var currentGenerationString = WorldRenderer.RenderWorld(world);
                this.writer.WriteLine(currentGenerationString);
                this.sleeper.Sleep();
                world.Tick();

                var nextGenerationString = WorldRenderer.RenderWorld(world);
                if (nextGenerationString == currentGenerationString) break;

            } while (!world.IsEmpty());

            WriteGeneration();
            this.writer.WriteLine(WorldRenderer.RenderWorld(world));
        }

        private void WriteGeneration()
        {
            this.writer.WriteLine($"Generation {world.Generation}: ");
        }

        private void GetWorld()
        {
            PromptWorld();
            for (var x = 0; x < world.Height; x++)
            {
                var row = this.reader.ReadLine().ToString();
                while (!ValidRow(row))
                {
                    this.writer.WriteLine("Previously entered row is invalid, it has been skipped.");
                    row = this.reader.ReadLine().ToString();
                }
                for(var y = 0; y < world.Width; y++)
                {
                    if (row[y] == CellCharacters[typeof(LivingCell)]) world.SetLivingAt(new Location2D(x, y));
                }
            }
        }

        private void PromptWorld()
        {
            this.writer.WriteLine("Enter world a row at a time: ");
        }

        private bool ValidRow(string row)
        {
            return row.Length == world.Width && row.All(c => CellCharacters.ContainsValue(c));
        }

        private void GetWorldSize()
        {
            PromptWorldSize();
            var size = this.reader.ReadLine().ToString();
            while (!ValidWorldSize(size))
            {
                PromptWorldSize();
                size = this.reader.ReadLine().ToString();
            }
            var worldSize = size.Split("x");
            this.world = new World(ParseSize(worldSize[0]), ParseSize(worldSize[1]));
        }

        private void PromptWorldSize()
        {
            this.writer.Write("Enter world size in the format 'nxn': ");
        }

        private bool ValidWorldSize(string input){
            var worldSize = input.Split("x");
            return IsValidInt(worldSize[0]) && IsValidInt(worldSize[1]);
        }

        private int ParseSize(string n) => int.Parse(n.ToString());

        private bool IsValidInt(string size) => int.TryParse(size.ToString(), out var dimension)  && dimension > 0 && dimension < 50;
    }
}