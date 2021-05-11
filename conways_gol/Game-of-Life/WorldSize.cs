using System;

namespace Game_of_Life
{
    public class WorldSize
    {
        public int Width { get; }
        public int Height { get; }
        public int Depth { get; }

        public WorldSize(int height = 5, int width = 5, int depth = 1)
        {
            ValidateSize(width, height, depth);
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        private void ValidateSize(int width, int height, int depth)
        {
            if (width < 1 || height < 1 || depth < 1) throw new InvalidWorldSize("Dimensions must be greater than 0");
            if (width > 100 || height > 100 || depth > 5) throw new InvalidWorldSize("Width and height must be less than 100, depth must be less than 5");
        }

        public override bool Equals(object obj)
        {
            WorldSize otherWorldSize = obj as WorldSize;
            if (otherWorldSize == null) return false;
            return Width == otherWorldSize.Width
                && Height == otherWorldSize.Height
                && Depth == otherWorldSize.Depth;
        }

    }
}