using System;
using System.Collections.Generic;
using System.Linq;

namespace Game_of_Life
{
    public class World
    {
        public WorldSize Size {get;}
        public List<Location> Locations { get; private set; }

        public World(WorldSize worldSize = default, Location[] locationOfLiveCells = default)
        {
            if (worldSize == default) worldSize = new WorldSize(5, 5, 1);
            if (locationOfLiveCells == default) locationOfLiveCells = new Location[0];
            this.Size = worldSize;
            InitialiseWorld();
            PopulateWorld(locationOfLiveCells);
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
                        var newLocation = new Location(x, y, z);
                        Locations.Add(newLocation);
                    }
                }
            }
        }

        private void PopulateWorld(Location[] locationOfLiveCells) =>
            Array.ForEach(locationOfLiveCells, SetLivingAt);

        public bool IsStagnant() => NextWorld().Equals(this);

        public bool IsEmpty() => Locations.Count(IsAlive) == 0;

        private void SetLivingAt(Location someLocation)
        {
            var locationOfLife = Locations.SingleOrDefault(someLocation.Equals);
            if (locationOfLife == null) throw new ArgumentException("Location out of bounds");
            locationOfLife.BecomeAlive();
        }

        public World NextWorld() => 
            new World(Size, Locations.Where(LocationAliveNextGeneration).ToArray());

        private bool LocationAliveNextGeneration(Location location) => 
            location.Cell.AliveNextGeneration(NumberOfAliveNeighbours(location));

        private Location[] GetNeighboursInWorld(Location location) => 
            Locations.Where(location.Neighbours()
            .Select(l => l.WrapLocation(Size))
            .Contains)
            .ToArray();

        private int NumberOfAliveNeighbours(Location location) => 
            GetNeighboursInWorld(location)
            .Count(IsAlive);

        private bool IsAlive(Location l) => l.Cell.GetType() == typeof(LivingCell);

        public override bool Equals(object obj)
        {
            World otherWorld = obj as World;
            if (otherWorld == null) return false;
            return Size.Width == otherWorld.Size.Width && 
                Size.Height == otherWorld.Size.Height &&
                Size.Depth == otherWorld.Size.Depth &&
                Locations.SequenceEqual(otherWorld.Locations);
        }
    }
}