using System;
using System.Collections.Generic;
using System.Linq;

namespace Game_of_Life
{
    public class World
    {
        public int Width { get; }
        public int Height { get; }
        public int Depth { get; }
        public List<ILocation> Locations { get; private set; }
        public int Generation { get; private set; }

        public World(int width, int height, int depth = 1)
        {
            Generation = 1;
            ValidateSize(width, height, depth);
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
            InitialiseWorld();
        }

        private void ValidateSize(int width, int height, int depth)
        {
            if (width < 0 || height < 0 || depth < 1) throw new ArgumentException("World size must be positive integers");
            if (width > 100 || height > 100 || depth > 3) throw new ArgumentException("World size must be less than 100");
        }

        // gross
        private void InitialiseWorld()
        {
            Locations = new List<ILocation>();
            if (Depth == 1)
            {
                for (var x = 0; x < Height; x++)
                {
                    for (var y = 0; y < Width; y++)
                    {
                        Locations.Add(new Location2D(x, y));
                    }
                }
            }
            else
            {
                for (var x = 0; x < Height; x++)
                {
                    for (var y = 0; y < Width; y++)
                    {
                        for (var z = 0; z < Depth; z++)
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
            var nextWorld = new World(Width, Height, Depth);
            foreach (var location in Locations)
            {
                if (LocationAliveNextGeneration(location)) nextWorld.SetLivingAt(location);
            }
            nextWorld.Generation = Generation+1;
            return nextWorld;
        }

        private bool LocationAliveNextGeneration(ILocation location) => location.Cell.AliveNextGeneration(NumberOfAliveNeighbours(location));

        private IEnumerable<ILocation> GetNeighboursInWorld(ILocation location) => Locations.Where(location.Neighbours()
                                                                                                    .Select(l => l.WrapLocation(Width, Height, Depth))
                                                                                                    .Contains);

        private int NumberOfAliveNeighbours(ILocation location) => GetNeighboursInWorld(location).Where(IsAlive)
                                                                                        .Count();

        private bool IsAlive(ILocation l) => l.Cell.GetType() == typeof(LivingCell);

    }
}