using System;
using System.Collections.Generic;
using System.Linq;

namespace Game_of_Life
{
    public class World
    {

        public int Width {get;}
        public int Height {get;}
        private List<Location> Locations = new List<Location>();

        public World(int width, int height)
        {
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
            for (var x = 0; x < Height; x++)
            {
                for (var y = 0; y < Width; y++)
                {
                    Locations.Add(new Location(x, y));
                }
            }
        }

        //private? but important to test? unsure..
        public IEnumerable<Location> GetNeighbours(Location location)
        {
            var neighbouringCells = new List<Location>
            {
                GetLocation(location.TopLeft()),
                GetLocation(location.Top()),
                GetLocation(location.TopRight()),
                GetLocation(location.Left()),
                GetLocation(location.Right()),
                GetLocation(location.BottomLeft()),
                GetLocation(location.Bottom()),
                GetLocation(location.BottomRight())
            };
            return neighbouringCells;
        }

        private IEnumerable<Location> GetAliveNeighbours(Location location) => GetNeighbours(location).Where(l => l.Cell.GetType() == typeof(LivingCell));

        private Location GetLocation(Location location)
        {
            location = WrapLocation(location);
            return Locations.Single(l => l.Equals(location));
        }

        private Location WrapLocation(Location location)
        {
            if (location.X < 0) location.X = this.Height + location.X;
            if (location.Y < 0) location.Y = this.Width + location.Y;
            if (location.X > this.Height - 1) location.X = location.X - this.Height;
            if (location.Y > this.Width - 1) location.Y = location.Y - this.Width;
            return location;
        }

        public void SetLivingAt(Location someLocation) => Locations.SingleOrDefault(l => l.Equals(someLocation)).BecomeAlive();

        public bool IsEmpty() => Locations.Where(c => c.Cell.GetType() == typeof(LivingCell)).Count() == 0;

        public void Tick()
        {
            var nextGenerationLocations = new List<Location>();
            foreach (var location in this.Locations)
            {
                var nextGenerationLocation = new Location(location.X, location.Y);
                nextGenerationLocations.Add(nextGenerationLocation);
                if (location.Cell.AliveNextGeneration(GetAliveNeighbours(location).Count()))
                {
                    nextGenerationLocation.BecomeAlive();
                }
                else
                {
                    nextGenerationLocation.BecomeDead();
                }
            }
            this.Locations = nextGenerationLocations;
        }

        //get world?
        public IEnumerable<Location> GetLocations()
        {
            return this.Locations;
        }
    }
}