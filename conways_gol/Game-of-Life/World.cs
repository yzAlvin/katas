using System;
using System.Collections.Generic;
using System.Linq;

namespace Game_of_Life
{
    public class World
    {
        public WorldSize Size { get; }
        public List<Location> Locations { get; private set; }

        public World(WorldSize worldSize = default, Coordinate[] livingCoords = default)
        {
            if (worldSize == default) worldSize = new WorldSize(5, 5, 1);
            if (livingCoords == default) livingCoords = new Coordinate[0];
            this.Size = worldSize;
            InitialiseWorld();
            PopulateWorld(livingCoords);
        }

        public bool IsStagnant() => this.Equals(NextWorld());

        public World NextWorld() =>
            new World(Size, NextWorldLocations());

        public override bool Equals(object obj)
        {
            World otherWorld = obj as World;
            if (otherWorld == null) return false;
            return Size.Equals(otherWorld.Size)
                && Locations.SequenceEqual(otherWorld.Locations);
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

        private void PopulateWorld(Coordinate[] livingCoords) =>
            Locations =
            livingCoords.All(c => Locations.Select(l => l.Coordinate).Contains(c)) ?
            Locations.Select(l => livingCoords.Contains(l.Coordinate) ? l.BecomeAlive() : l).ToList()
            : throw new InvalidLocation();

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

        private Coordinate[] NextWorldLocations() =>
        Locations.Where(IsAlive).Aggregate(
            Locations.Where(IsAlive).ToList(),
            (acc, cur) =>
                {
                    acc.AddRange(GetNeighboursInWorld(cur.Coordinate));
                    return acc;
                }
        )
        .Distinct()
        .Where(LocationAliveNextGeneration)
        .Select(l => l.Coordinate)
        .ToArray();

        private bool IsAlive(Location l) => l.Cell.GetType() == typeof(LivingCell);

    }
}