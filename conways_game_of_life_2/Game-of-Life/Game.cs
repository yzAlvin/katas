using System;
using System.Collections.Generic;
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
            // world = new World(ws[0], ws[1], ws[2], lc);
            StartWorld();
        }

        private void StartWorld()
        {
            do
            {
                // Console.Clear();
                var currentGenerationString = WorldRenderer.RenderWorld(world);
                writer.WriteLine(currentGenerationString);
                sleeper.Sleep();
                world = world.NextWorld();

                var nextGenerationString = WorldRenderer.RenderWorld(world);
                if (nextGenerationString == currentGenerationString) break;

            } while (!world.IsEmpty());

            writer.WriteLine(WorldRenderer.RenderWorld(world));
        }

        private void GetWorld()
        {
            PromptWorld();
            // 0, 1.2,1.2,3.3,3
            var lifeCoords = CleanCoords(reader.ReadLine());
            while (!ValidCoords(lifeCoords))
            {
                lifeCoords = CleanCoords(reader.ReadLine());
            }
            var coords = lifeCoords.Split(".");
            var locationOfLife = new List<ILocation>();
            foreach (var c in coords)
            {
                var co = c.Split(",").Select(int.Parse).ToArray();
                if (co.Length == 2) locationOfLife.Add(new Location2D(co[0], co[1]));
                if (co.Length == 3) locationOfLife.Add(new Location3D(co[0], co[1], co[2]));
            }
            world = new World(world.Size, locationOfLiveCells: locationOfLife.ToArray());
        }

        private string CleanCoords(string coords) => String.Join("", (coords.Where(c => !Char.IsWhiteSpace(c) && c != '(' && c != ')')));

        // private void GetWorld()
        // {
        //     PromptWorld();
        //     for (var x = 0; x < world.Height; x++)
        //     {
        //         var row = reader.ReadLine();
        //         while (!ValidRow(row))
        //         {
        //             row = reader.ReadLine();
        //         }
        //         for(var y = 0; y < world.Width; y++)
        //         {
        //             if (world.Depth == 1)
        //             {
        //                 if (row[y] == CellCharacters.CellSymbols[typeof(LivingCell)]) world.SetLivingAt(new Location2D(x, y));
        //             }
        //             else
        //             {
        //                 for(var z = 0; z < world.Depth; y++)
        //                 {
        //                     if (row[y] == CellCharacters.CellSymbols[typeof(LivingCell)]) world.SetLivingAt(new Location3D(x, y, z));
        //                 }
        //             }
        //         }
        //     }
        // }

        private void PromptWorld() => writer.WriteLine("Enter world one row at a time: ");

        private bool ValidRow(string row) => row.Length == world.Size.Width && row.All(CellCharacters.CellSymbols.ContainsValue);
        
        private bool ValidCoords(string coords) => coords.All(c => Char.IsDigit(c) || c == '.' || c == ',') && LegitCoords(coords);

        private bool LegitCoords(string coords)
        {
            var testCoords = coords.Split(".");
            foreach (var c in testCoords)
            {
                var co = c.Split(",").Select(int.Parse).ToArray();
                if (co.Length != 2 && co.Length != 3) return false;
                int width = co[0];
                int height = co[1];
                int depth = co.Length == 3 ? co[2] : 1;
                if (OutOfBounds(width, world.Size.Width)) return false;
                if (OutOfBounds(height, world.Size.Height)) return false;
                if (OutOfBounds(depth, world.Size.Depth)) return false;
            }
            return true;
        }

        private bool OutOfBounds(int n, int upperBound) => n < 0 || n > upperBound; 

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
            world = new World(new WorldSize(worldSize[0], worldSize[1], worldSize[2]));
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