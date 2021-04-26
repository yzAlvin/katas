using System;

namespace Game_of_Life
{
    public class WorldSize
    {
        public int Width { get; }
        public int Height { get; }
        public int Depth { get; }

        public WorldSize(int width = 5, int height = 5, int depth = 1)
        {
            ValidateSize(width, height, depth);
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        private void ValidateSize(int width, int height, int depth)
        {
            if (width < 1 || height < 1 || depth < 1) throw new ArgumentException("World size must be greater than 0");
            if (width > 100 || height > 100 || depth > 6) throw new ArgumentException("World size must be less than 100");
        }

    }
}