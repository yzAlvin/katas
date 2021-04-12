using System;
using System.Collections.Generic;
using System.Linq;

namespace game_of_life
{
    public class World
    {
        private List<Coordinate> _coordinates = new List<Coordinate>();
        private int Width {get; set;}
        private int Height {get; set;}

        public World(int width = 0, int height = 0)
        {
            if (width < 0 || height < 0) throw new ArgumentException("World size must be positive.");
            Width = width;
            Height = height;
            InitialiseCells();
        }

        private void InitialiseCells()
        {
            for (var x = 0; x < Height; x++)
            {
                for (var y = 0; y < Width; y++)
                {
                    _coordinates.Add(new Coordinate(x, y));
                }
            }
        }

        public void SetLivingAt(Coordinate coordinate)
        {
            _coordinates.Single(c => c.Equals(coordinate)).BecomeAlive();
        }

        public Coordinate GetCoordinate(int x, int y)
        {
            return _coordinates.SingleOrDefault(c => c);
        }

        public bool IsEmpty()
        {
            return _coordinates.Where(c => c.Cell.GetType() == typeof(DeadCell)).Count() == Width*Height;
        }
    }
}