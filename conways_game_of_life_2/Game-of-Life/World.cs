using System;
using System.Collections.Generic;
using System.Linq;

namespace Game_of_Life
{
    public class World
    {

        private int Width {get;}
        private int Height {get;}
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
            if (location.X < 0) location.X = this.Width + location.X;
            if (location.Y < 0) location.Y = this.Height + location.Y;
            if (location.X > this.Width - 1) location.X = location.X - this.Width;
            if (location.Y > this.Height - 1) location.Y = location.Y - this.Height;
            return location;
        }

        public void SetLivingAt(Location someLocation) => Locations.SingleOrDefault(l => l.Equals(someLocation)).BecomeAlive();

        public bool IsEmpty() => Locations.Where(c => c.Cell.GetType() == typeof(LivingCell)).Count() == 0;

        public void Tick()
        {
            foreach (var location in Locations)
            {
                if (location.Cell.AliveNextGeneration(GetAliveNeighbours(location).Count()))
                {
                    location.BecomeAlive();
                }
                else
                {
                    location.BecomeDead();
                }
            }
        }
    }
}