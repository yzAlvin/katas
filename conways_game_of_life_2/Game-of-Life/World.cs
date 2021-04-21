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
        public List<Location2D> Locations { get; private set; }
        public int Generation { get; private set; }

        public World(int width, int height, int depth = 1)
        {
            Generation = 1;
            ValidateSize(width, height, depth);
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
            InitialiseLocations();
        }

        private void ValidateSize(int width, int height, int depth)
        {
            if (width < 0 || height < 0 || depth < 1) throw new ArgumentException("World size must be positive integers");
        }

        private void InitialiseLocations()
        {
            Locations = new List<Location2D>();
            for (var x = 0; x < Height; x++)
            {
                for (var y = 0; y < Width; y++)
                {
                    for (var z = 0; z < Depth; z++)
                    {
                        Locations.Add(new Location2D(x, y));
                    }
                }
            }
        }

        public bool IsEmpty() => Locations.Where(IsAlive)
                                        .Count() == 0;

        public void SetLivingAt(Location2D someLocation)
        {
            var locationOfLife = Locations.SingleOrDefault(l => l.Equals(someLocation));
            if (locationOfLife == null) throw new ArgumentException("Location out of bounds");
            locationOfLife.BecomeAlive();
        }
        public void SetLivingAt(Location2D[] liveCellLocations) => Array.ForEach(liveCellLocations, SetLivingAt);

        public void Tick()
        {
            var nextGenerationLocations = new List<Location2D>();
            foreach (var location in Locations)
            {
                var nextGenerationLocation = location.Clone();
                nextGenerationLocations.Add(nextGenerationLocation);

                SetNextGenerationCellState(location, nextGenerationLocation);
            }
            Locations = nextGenerationLocations;
            Generation++;
        }

        private void SetNextGenerationCellState(Location2D location, Location2D nextGenerationLocation)
        {
            if (location.Cell.AliveNextGeneration(NumberOfAliveNeighbours(location))) nextGenerationLocation.BecomeAlive();
        }

        private IEnumerable<Location2D> GetNeighbours(Location2D location) => Locations.Where(location.Neighbours()
                                                                                                    .Select(WrapLocation)
                                                                                                    .Contains);


        private Location2D WrapLocation(Location2D location)
        {
            if (location.X < 0) location.X = this.Height + location.X;
            if (location.Y < 0) location.Y = this.Width + location.Y;
            if (location.X > this.Height - 1) location.X = location.X - this.Height;
            if (location.Y > this.Width - 1) location.Y = location.Y - this.Width;
            return location;
        }

        private int NumberOfAliveNeighbours(Location2D location) => GetNeighbours(location).Where(IsAlive)
                                                                                        .Count();

        private bool IsAlive(ILocation l) => l.Cell.GetType() == typeof(LivingCell);

    }
}