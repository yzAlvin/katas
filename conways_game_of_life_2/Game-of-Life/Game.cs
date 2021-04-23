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
                // WriteGeneration();
                var currentGenerationString = WorldRenderer.RenderWorld(world);
                writer.WriteLine(currentGenerationString);
                sleeper.Sleep();
                world = world.NextWorld();

                var nextGenerationString = WorldRenderer.RenderWorld(world);
                if (nextGenerationString == currentGenerationString) break;

            } while (!world.IsEmpty());

            // WriteGeneration();
            writer.WriteLine(WorldRenderer.RenderWorld(world));
        }

        // private void WriteGeneration() => writer.WriteLine($"Generation {world.Generation}: ");

        //BAD CODE?
        private void GetWorld()
        {
            PromptWorld();
            for (var x = 0; x < world.Height; x++)
            {
                var row = reader.ReadLine();
                while (!ValidRow(row))
                {
                    row = reader.ReadLine();
                }
                for(var y = 0; y < world.Width; y++)
                {
                    if (world.Depth == 1)
                    {
                        if (row[y] == CellCharacters.CellSymbols[typeof(LivingCell)]) world.SetLivingAt(new Location2D(x, y));
                    }
                    else
                    {
                        for(var z = 0; z < world.Depth; y++)
                        {
                            if (row[y] == CellCharacters.CellSymbols[typeof(LivingCell)]) world.SetLivingAt(new Location3D(x, y, z));
                        }
                    }
                }
            }
        }

        private void PromptWorld() => writer.WriteLine("Enter world one row at a time: ");

        private bool ValidRow(string row) => row.Length == world.Width && row.All(CellCharacters.CellSymbols.ContainsValue);

        private void GetWorldSize()
        {
            PromptWorldSize();
            var size = reader.ReadLine();
            while (!ValidWorldSize(size))
            {
                PromptWorldSize();
                size = reader.ReadLine();
            }
            var worldSize = size.Split("x").Select(int.Parse).ToArray();
            if (worldSize.Length == 2) worldSize = new int[]{worldSize[0], worldSize[1], 1};
            world = new World(width: worldSize[0], height: worldSize[1], depth: worldSize[2]);
        }

        private void PromptWorldSize() =>  writer.Write("Enter world size in the format 'nxn': ");

        private bool ValidWorldSize(string size)
        {
            var worldSize = size.Split("x");
            return SizeIs2DOr3D(worldSize) && SizesAreValid(worldSize);
        }

        private bool SizesAreValid(string[] worldSize) => worldSize.All(IsValidInt);

        private bool SizeIs2DOr3D(string[] worldSize) => worldSize.Length == 2 || worldSize.Length == 3;

        private bool IsValidInt(string size) => int.TryParse(size, out var _);
    }
}