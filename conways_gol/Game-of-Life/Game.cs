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
            SetCellString();
            PlayWorld();
        }

        private void SetCellString()
        {
            PromptDeadCellCharacter();
            var deadCellString = reader.ReadLine();
            if (String.IsNullOrEmpty(deadCellString)) deadCellString = ".";
            PromptLiveCellCharacter();
            var aliveCellString = reader.ReadLine();
            if (String.IsNullOrEmpty(aliveCellString)) aliveCellString = "*";
            DeadCell.SetString(deadCellString);
            LivingCell.SetString(aliveCellString);
        }

        private void PromptDeadCellCharacter() => writer.Write("Enter dead cell string representation (or leave blank): ");

        private void PromptLiveCellCharacter() => writer.Write("Enter live cell string representation (or leave blank): ");

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
            if (String.IsNullOrEmpty(lifeCoords)) return new Location[0];
            var coords = lifeCoords.Split(".");
            var locationsOfLife = new List<Location>();
            foreach (var c in coords)
            {
                var coord = c.Split(",").Select(int.Parse).ToArray();
                if (coord.Length == 2) locationsOfLife.Add(new Location(new Coordinate(coord[0], coord[1], 0)));
                if (coord.Length == 3) locationsOfLife.Add(new Location(new Coordinate(coord[0], coord[1], coord[2])));
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
            var lifeCoords = reader.ReadLine();
            while (!Validation.ValidCoords(Validation.FormatCoords(lifeCoords), ws)
                && !String.IsNullOrEmpty(lifeCoords))
            {
                lifeCoords = reader.ReadLine();
            }

            return lifeCoords;
        }

    }
}