using System;
using System.Collections.Generic;
using System.Linq;

namespace gol
{
    public class World
    {
        private int width;
        private int height;
        public List<Location> liveCells {get; private set;}

        public World(int width, int height, List<Location> liveCells)
        {
            this.width = width;
            this.height = height;
            this.liveCells = liveCells;
        }

        public World NextGeneration()
        {
            liveCells = liveCells.Where(AliveNextGeneration).ToList();
            return this;
        }

        private bool AliveNextGeneration(Location location)
        {
            if (location.Neighbours)
        }
    }
}