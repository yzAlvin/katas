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
            var liveLocations = GetLocationOfLiveCells(worldSize);
            world = new World(worldSize, liveLocations);
            SetCellString();
            PlayWorld();
        }

        private WorldSize GetWorldSize()
        {
            var size = PromptUntil(Validation.ValidWorldSize, PromptWorldSize);
            var worldSize = size.Split("x").Select(int.Parse).ToArray();
            worldSize = worldSize.Length == 3 ? worldSize : new int[] { worldSize[0], worldSize[1], 1 };
            return new WorldSize(worldSize[0], worldSize[1], worldSize[2]);
        }

        private Location[] GetLocationOfLiveCells(WorldSize ws)
        {
            var coordsofLife = PromptUntilValidLocations(ws);
            if (String.IsNullOrEmpty(coordsofLife)) return new Location[0];
            var coords = coordsofLife.Split(".");
            var liveLocations = new List<Location>();
            foreach (var c in coords)
            {
                var coord = c.Split(",").Select(int.Parse).ToArray();
                if (coord.Length == 2) liveLocations.Add(new Location(new Coordinate(coord[0], coord[1], 0)));
                if (coord.Length == 3) liveLocations.Add(new Location(new Coordinate(coord[0], coord[1], coord[2])));
            }
            return liveLocations.ToArray();
        }

        private void SetCellString()
        {
            DeadCell.SetString(GetNonEmptyString(PromptDeadCellCharacter, "."));
            LivingCell.SetString(GetNonEmptyString(PromptDeadCellCharacter, "*"));
        }

        private string GetNonEmptyString(Action prompt, string fallback)
        {
            prompt();
            var userInput = reader.ReadLine();
            if (String.IsNullOrEmpty(userInput)) userInput = fallback;
            return userInput;
        }

        private void PlayWorld()
        {
            writer.WriteLine(WorldRenderer.RenderWorld(world));
            while (!(world.IsEmpty() && world.IsStagnant()))
            {
                world = world.NextWorld();
                writer.WriteLine(WorldRenderer.RenderWorld(world));
                sleeper.Sleep();
            }
        }

        private string PromptUntil(Func<string, bool> valid, Action prompt)
        {
            prompt();
            var userInput = reader.ReadLine();
            while (!valid(userInput))
            {
                prompt();
                userInput = reader.ReadLine();
            }
            return userInput;
        }

        private string PromptUntilValidLocations(WorldSize ws)
        {
            PromptLiveLocations();
            var lifeCoords = reader.ReadLine();
            while (!Validation.ValidCoords(lifeCoords, ws))
            {
                PromptLiveLocations();
                lifeCoords = reader.ReadLine();
            }

            return lifeCoords;
        }

        private void PromptWorldSize() =>
            writer.Write("Enter world size in the format 'nxn': ");

        private void PromptLiveLocations() =>
            writer.WriteLine("Enter coordinates of live cells: ");

        private void PromptDeadCellCharacter() =>
            writer.Write("Enter dead cell string representation (or leave blank): ");

        private void PromptLiveCellCharacter() =>
            writer.Write("Enter live cell string representation (or leave blank): ");

    }
}