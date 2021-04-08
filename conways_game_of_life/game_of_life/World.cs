using System;
using System.Collections.Generic;

namespace game_of_life
{
    public class World
    {
        private List<Coordinate> _livingCells = new List<Coordinate>();
        public World(int width = 0, int height = 0)
        {
            if (width < 0 || height < 0) throw new ArgumentException("World size must be positive.");
        }

        public bool IsEmpty()
        {
            return _livingCells.Count == 0;
        }
    }
}