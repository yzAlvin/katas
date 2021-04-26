using System;
using System.Collections.Generic;
using System.Linq;

namespace Game_of_Life
{
    public class World
    {
        public WorldSize Size {get;}
        public List<ILocation> Locations { get; private set; }

        
        public World(WorldSize worldSize = default, ILocation[] locationOfLiveCells = default)
        {
            if (worldSize == default) worldSize = new WorldSize(5, 5, 1);
            if (locationOfLiveCells == default) locationOfLiveCells = new ILocation[0];
            this.Size = worldSize;
            InitialiseWorld();
            Array.ForEach(locationOfLiveCells, SetLivingAt);
        }

        // gross
        private void InitialiseWorld()
        {
            Locations = new List<ILocation>();
            if (Size.Depth == 1)
            {
                for (var x = 0; x < Size.Height; x++)
                {
                    for (var y = 0; y < Size.Width; y++)
                    {
                        Locations.Add(new Location2D(x, y));
                    }
                }
            }
            else
            {
                for (var x = 0; x < Size.Height; x++)
                {
                    for (var y = 0; y < Size.Width; y++)
                    {
                        for (var z = 0; z < Size.Depth; z++)
                        {
                            Locations.Add(new Location3D(x, y, z));
                        }
                    }
                }
            }
        }

        public bool IsEmpty() => Locations.Where(IsAlive)
                                        .Count() == 0;

        public void SetLivingAt(ILocation someLocation)
        {
            var locationOfLife = Locations.SingleOrDefault(someLocation.Equals);
            if (locationOfLife == null) throw new ArgumentException("Location out of bounds");
            locationOfLife.BecomeAlive();
        }
        public void SetLivingAt(ILocation[] liveCellLocations) => Array.ForEach(liveCellLocations, SetLivingAt);

        public World NextWorld()
        {
            var nextWorld = new World(Size);
            foreach (var location in Locations)
            {
                if (LocationAliveNextGeneration(location)) nextWorld.SetLivingAt(location);
            }
            return nextWorld;
        }

        private bool LocationAliveNextGeneration(ILocation location) => location.Cell.AliveNextGeneration(NumberOfAliveNeighbours(location));

        private IEnumerable<ILocation> GetNeighboursInWorld(ILocation location) => Locations.Where(location.Neighbours()
                                                                                                    .Select(l => l.WrapLocation(Size.Width, Size.Height, Size.Depth))
                                                                                                    .Contains);

        private int NumberOfAliveNeighbours(ILocation location) => GetNeighboursInWorld(location).Count(IsAlive);

        private bool IsAlive(ILocation l) => l.Cell.GetType() == typeof(LivingCell);
        // private Func<ILocation, bool> IsAlive = l => l.Cell.GetType() == typeof(LivingCell);

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