using System.Collections.Generic;

namespace Game_of_Life
{
    public class Location2D : ILocation
    {
        public int X {get; set;}
        public int Y {get; set;}

        public Location2D(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override bool Equals(object obj)
        {
            Location2D otherCoord = obj as Location2D;
            if (otherCoord == null) return false;
            return X == otherCoord.X && Y == otherCoord.Y;
        }

        public override IEnumerable<Location2D> Neighbours() => new Location2D[]
        {
            this.TopLeft(),
            this.Top(),
            this.TopRight(),
            this.Left(),
            this.Right(),
            this.BottomLeft(),
            this.Bottom(),
            this.BottomRight()  
        };

        private Location2D TopLeft() => new Location2D(this.X - 1, this.Y - 1);
        private Location2D Top() => new Location2D(this.X - 1, this.Y);
        private Location2D TopRight() => new Location2D(this.X - 1, this.Y + 1);
        private Location2D Left() => new Location2D(this.X, this.Y - 1);
        private Location2D Right() => new Location2D(this.X, this.Y + 1);
        private Location2D BottomLeft() => new Location2D(this.X + 1, this.Y - 1);
        private Location2D Bottom() => new Location2D(this.X + 1, this.Y);
        private Location2D BottomRight() => new Location2D(this.X + 1, this.Y + 1);

        public override Location2D WrapLocation(int width, int height, int depth)
        {
            var wrappedX = X;
            var wrappedY = Y;
            if (X < 0) wrappedX = height + X;
            if (Y < 0) wrappedY = width + Y;
            if (X > height - 1) wrappedX = X - height;
            if (Y > width - 1) wrappedY = Y - width;
            return new Location2D(wrappedX, wrappedY);
        }
    }
}