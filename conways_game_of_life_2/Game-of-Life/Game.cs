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
        private readonly Sleeper sleeper;
        private World world;

        public Game(TextReader reader, TextWriter writer, Sleeper sleeper)
        {
            this.reader = reader;
            this.writer = writer;
            this.sleeper = sleeper;
        }

        public void Run()
        {
            var worldSize = GetWorldSize();
            var locationOfLiveCells = GetLocationOfLiveCells(worldSize);
            world = new World(worldSize, locationOfLiveCells);
            PlayWorld();
        }

        private void PlayWorld()
        {
            writer.WriteLine(WorldRenderer.RenderWorld(world));
            while (!world.IsEmpty() || !world.IsStagnant())
            {
                world = world.NextWorld();
                // Console.Clear();
                writer.WriteLine(WorldRenderer.RenderWorld(world));
                sleeper.Sleep();
            }
        }

        private ILocation[] GetLocationOfLiveCells(WorldSize ws)
        {
            PromptWorld();
            var lifeCoords = PromptUntilValidLocations(ws);
            var coords = lifeCoords.Split(".");
            var locationOfLife = new List<ILocation>();
            foreach (var c in coords)
            {
                var co = c.Split(",").Select(int.Parse).ToArray();
                //BAD ?
                if (co.Length == 2) locationOfLife.Add(new Location2D(co[0], co[1]));
                if (co.Length == 3) locationOfLife.Add(new Location3D(co[0], co[1], co[2]));
            }
            return locationOfLife.ToArray();
        }

        private string PromptUntilValidLocations(WorldSize ws)
        {
            var lifeCoords = CleanCoords(reader.ReadLine());
            while (!ValidCoords(lifeCoords, ws))
            {
                lifeCoords = CleanCoords(reader.ReadLine());
            }

            return lifeCoords;
        }

        private string CleanCoords(string coords) => String.Join("", (coords.Where(ValidCoordChars)));

        private void PromptWorld() => writer.WriteLine("Enter world one row at a time: ");

        private bool ValidCoords(string coords, WorldSize worldSize) => coords.All(ValidCoordChars) && LegitCoords(coords, worldSize);

        private bool ValidCoordChars(char c) => Char.IsDigit(c) || c == '.' || c == ',';

        private bool LegitCoords(string coords, WorldSize worldSize)
        {
            var coordsArary = coords.Split(".");

            foreach (var c in coordsArary)
            {
                var coordsStringArray = c.Split(",");
                if (!coordsStringArray.All(IsValidInt)) return false;
                var coordsIntArray = coordsStringArray.Select(int.Parse).ToArray();
                if (coordsIntArray.Length != 2 && coordsIntArray.Length != 3) return false;
                int width = coordsIntArray[0];
                int height = coordsIntArray[1];
                int depth = coordsStringArray.Length == 3 ? coordsIntArray[2] : 1;
                if (OutOfBounds(width, height, depth, worldSize)) return false;
            }
            return true;
        }

        private bool OutOfBounds(int width, int height, int depth, WorldSize upperBound) => width < 0 || width > upperBound.Width
                                                                    || height < 0 || height > upperBound.Height
                                                                    || depth < 0 || depth > upperBound.Depth; 

        private WorldSize GetWorldSize()
        {
            PromptWorldSize();
            var size = PromptUntilValid();
            var worldSize = size.Split("x").Select(int.Parse).ToArray();
            // BAD?
            worldSize = worldSize.Length == 3 ? worldSize : new int[] { worldSize[0], worldSize[1], 1 };
            return new WorldSize(worldSize[0], worldSize[1], worldSize[2]);
        }

        private string PromptUntilValid()
        {
            var worldSize = reader.ReadLine();
            while (!ValidWorldSize(worldSize.Split("x")))
            {
                PromptWorldSize();
                worldSize = reader.ReadLine();
            }
            return worldSize;
        }

        private void PromptWorldSize() =>  writer.Write("Enter world size in the format 'nxn': ");

        private bool ValidWorldSize(string[] worldSize) => SizeIs2DOr3D(worldSize) && SizesAreValid(worldSize);

        private bool SizesAreValid(string[] worldSize) => worldSize.All(IsValidInt);

        private bool SizeIs2DOr3D(string[] worldSize) => worldSize.Length == 2 || worldSize.Length == 3;

        private bool IsValidInt(string size) => int.TryParse(size, out var _);
    }
}