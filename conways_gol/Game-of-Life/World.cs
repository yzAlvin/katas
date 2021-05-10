using System;
using System.Collections.Generic;
using System.Linq;

namespace Game_of_Life
{
    public class World
    {
        public WorldSize Size { get; }
        public List<Location> Locations { get; private set; }

        public World(WorldSize worldSize = default, Location[] locationOfLiveCells = default)
        {
            if (worldSize == default) worldSize = new WorldSize(5, 5, 1);
            if (locationOfLiveCells == default) locationOfLiveCells = new Location[0];
            this.Size = worldSize;
            InitialiseWorld();
            PopulateWorld(locationOfLiveCells);
        }

        public bool IsEmpty() => Locations.Count(IsAlive) == 0;

        public bool IsStagnant() => this.Equals(NextWorld());

        public World NextWorld() =>
            new World(Size, NextWorldLocations());

        public override bool Equals(object obj)
        {
            World otherWorld = obj as World;
            if (otherWorld == null) return false;
            return Size.Equals(otherWorld.Size) &&
                Locations.SequenceEqual(otherWorld.Locations);
        }

        private void InitialiseWorld()
        {
            Locations = new List<Location>();
            for (var x = 0; x < Size.Height; x++)
            {
                for (var y = 0; y < Size.Width; y++)
                {
                    for (var z = 0; z < Size.Depth; z++)
                    {
                        Locations.Add(new Location(new Coordinate(x, y, z)));
                    }
                }
            }
        }

        private void PopulateWorld(Location[] locationOfLiveCells) =>
            Locations =
                locationOfLiveCells.All(x => Locations.Contains(x)) ?
                    Locations.Select(l => locationOfLiveCells.Contains(l) ? l.BecomeAlive() : l).ToList()
                    : throw new ArgumentException("Tried to access a location that was not in the world.");

        private bool LocationAliveNextGeneration(Location location) =>
            location.Cell.AliveNextGeneration(NumberOfAliveNeighbours(location.Coordinate));

        private Location[] GetNeighboursInWorld(Coordinate coordinate) =>
            Locations.Where(l => coordinate.Neighbours()
            .Select(c => c.WrapCoordinate(Size))
            .Where(c => !c.Equals(coordinate))
            .Contains(l.Coordinate))
            .ToArray();

        private int NumberOfAliveNeighbours(Coordinate coordinate) =>
            GetNeighboursInWorld(coordinate)
            .Count(IsAlive);

        private Location[] NextWorldLocations() =>
            Locations.Where(IsAlive).Aggregate(
                Locations.Where(IsAlive).ToList(),
                (acc, cur) =>
                    {
                        acc.AddRange(GetNeighboursInWorld(cur.Coordinate));
                        return acc;
                    }
            )
            .Distinct().Where(LocationAliveNextGeneration).ToArray();

        private bool IsAlive(Location l) => l.Cell.GetType() == typeof(LivingCell);

    }
}