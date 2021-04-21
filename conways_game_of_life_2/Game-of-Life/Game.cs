using System.IO;
using System.Linq;

namespace Game_of_Life
{
    public class Game
    {
        private readonly TextReader reader;
        private readonly TextWriter writer;
        private readonly ISleeper sleeper;
        private World world;

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
                writer.WriteLine(currentGenerationString);
                sleeper.Sleep();
                world.Tick();

                var nextGenerationString = WorldRenderer.RenderWorld(world);
                if (nextGenerationString == currentGenerationString) break;

            } while (!world.IsEmpty());

            WriteGeneration();
            writer.WriteLine(WorldRenderer.RenderWorld(world));
        }

        private void WriteGeneration()
        {
            writer.WriteLine($"Generation {world.Generation}: ");
        }

        private void GetWorld()
        {
            PromptWorld();
            for (var x = 0; x < world.Height; x++)
            {
                var row = reader.ReadLine().ToString();
                while (!ValidRow(row))
                {
                    writer.WriteLine("Previously entered row is invalid, it has been skipped.");
                    row = reader.ReadLine().ToString();
                }
                for(var y = 0; y < world.Width; y++)
                {
                    if (row[y] == CellCharacters.CellSymbols[typeof(LivingCell)]) world.SetLivingAt(new Location2D(x, y));
                }
            }
        }

        private void PromptWorld()
        {
            this.writer.WriteLine("Enter world one row at a time: ");
        }

        private bool ValidRow(string row)
        {
            return row.Length == world.Width && row.All(c => CellCharacters.CellSymbols.ContainsValue(c));
        }

        private void GetWorldSize()
        {
            PromptWorldSize();
            var size = reader.ReadLine().ToString();
            while (!ValidWorldSize(size))
            {
                PromptWorldSize();
                size = reader.ReadLine().ToString();
            }
            var worldSize = size.Split("x");
            world = new World(ParseSize(worldSize[0]), ParseSize(worldSize[1]));
        }

        private void PromptWorldSize()
        {
            writer.Write("Enter world size in the format 'nxn': ");
        }

        private bool ValidWorldSize(string input){
            var worldSize = input.Split("x");
            return IsValidInt(worldSize[0]) && IsValidInt(worldSize[1]);
        }

        private int ParseSize(string n) => int.Parse(n.ToString());

        private bool IsValidInt(string size) => int.TryParse(size.ToString(), out var dimension)  && dimension > 0 && dimension < 100;
    }
}