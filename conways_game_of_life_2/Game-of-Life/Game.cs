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

        private WorldSize GetWorldSize()
        {
            PromptWorldSize();
            var size = PromptUntilValidWorldSize();
            var worldSize = size.Split("x").Select(int.Parse).ToArray();
            worldSize = worldSize.Length == 3 ? worldSize : new int[] { worldSize[0], worldSize[1], 1 };
            return new WorldSize(worldSize[0], worldSize[1], worldSize[2]);
        }

        private Location[] GetLocationOfLiveCells(WorldSize ws)
        {
            PromptLiveLocations();
            var lifeCoords = PromptUntilValidLocations(ws);
            var coords = lifeCoords.Split(".");
            var locationsOfLife = new List<Location>();
            foreach (var c in coords)
            {
                var co = c.Split(",").Select(int.Parse).ToArray();
                if (co.Length == 2) locationsOfLife.Add(new Location(co[0], co[1], 0));
                if (co.Length == 3) locationsOfLife.Add(new Location(co[0], co[1], co[2]));
            }
            return locationsOfLife.ToArray();
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

        private void PromptWorldSize() => writer.Write("Enter world size in the format 'nxn': ");

        private string PromptUntilValidWorldSize()
        {
            var worldSize = reader.ReadLine();
            while (!Validation.ValidWorldSize(worldSize.Split("x")))
            {
                PromptWorldSize();
                worldSize = reader.ReadLine();
            }
            return worldSize;
        }

        private void PromptLiveLocations() => writer.WriteLine("Enter coordinates of live cells: ");

        private string PromptUntilValidLocations(WorldSize ws)
        {
            var lifeCoords = Validation.CleanCoords(reader.ReadLine());
            while (!Validation.ValidCoords(lifeCoords, ws))
            {
                lifeCoords = Validation.CleanCoords(reader.ReadLine());
            }

            return lifeCoords;
        }

    }
}