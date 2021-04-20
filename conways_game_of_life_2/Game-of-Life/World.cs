using System;
using System.Collections.Generic;
using System.Linq;

namespace Game_of_Life
{
    public class World
    {

        public int Width {get;}
        public int Height {get;}
        public List<Location> Locations {get; private set;}
        public int Generation {get; private set;}

        public World(int width, int height)
        {
            Generation = 1;
            ValidateSize(width, height);
            this.Width = width;
            this.Height = height;
            InitialiseLocations();
        }

        private void ValidateSize(int width, int height)
        {
            if (width < 0 || height < 0) throw new ArgumentException("World size must be positive integers");
        } 

        private void InitialiseLocations()
        {
            Locations = new List<Location>();
            for (var x = 0; x < Height; x++)
            {
                for (var y = 0; y < Width; y++)
                {
                    Locations.Add(new Location(x, y));
                }
            }
        }

        public bool IsEmpty() => Locations.Where(c => c.Cell.GetType() == typeof(LivingCell)).Count() == 0;

        public void SetLivingAt(Location someLocation)
        {
            var locationOfLife = Locations.SingleOrDefault(l => l.Equals(someLocation));
            if (locationOfLife == null) throw new ArgumentException("Location out of bounds");
            locationOfLife.BecomeAlive();
        } 
        public void SetLivingAt(Location[] liveCellLocations) => Array.ForEach(liveCellLocations, l => SetLivingAt(l));

        public void Tick()
        {
            var nextGenerationLocations = new List<Location>();
            foreach (var location in this.Locations)
            {
                var nextGenerationLocation = location.Clone();
                nextGenerationLocations.Add(nextGenerationLocation);

                SetNextGenerationCellState(location, nextGenerationLocation);
            }
            this.Locations = nextGenerationLocations;
            Generation++;
        }

        private void SetNextGenerationCellState(Location location, Location nextGenerationLocation)
        {
            if (location.Cell.AliveNextGeneration(NumberOfAliveNeighbours(location)))
            {
                nextGenerationLocation.BecomeAlive();
            }
            else
            {
                nextGenerationLocation.BecomeDead();
            }
        }

        private IEnumerable<Location> GetNeighbours(Location location)
        {
            var neighbouringCells = location.Neighbours();
            neighbouringCells = neighbouringCells.Select(l => WrapLocation(l));
            return Locations.Where(l => neighbouringCells.Contains(l));;
        }

        private Location WrapLocation(Location location)
        {
            if (location.X < 0) location.X = this.Height + location.X;
            if (location.Y < 0) location.Y = this.Width + location.Y;
            if (location.X > this.Height - 1) location.X = location.X - this.Height;
            if (location.Y > this.Width - 1) location.Y = location.Y - this.Width;
            return location;
        }

        private int NumberOfAliveNeighbours(Location location) => GetNeighbours(location).Where(l => l.Cell.GetType() == typeof(LivingCell)).Count();

    }
}