using System.Collections.Generic;

namespace Game_of_Life
{
    public class Location
    {
        public int X {get; set;}
        public int Y {get; set;}
        public ICell Cell {get; set;}

        public Location(int x, int y)
        {
            this.X = x;
            this.Y = y;
            Cell = new DeadCell();
        }

        public void BecomeAlive() => this.Cell = new LivingCell();
        public void BecomeDead() => this.Cell = new DeadCell();

        public override bool Equals(object obj)
        {
            Location otherCoord = obj as Location;
            if (otherCoord == null) return false;
            return X == otherCoord.X && Y == otherCoord.Y;
        }

        public Location Clone() => new Location(this.X, this.Y);

        public IEnumerable<Location> Neighbours() => new Location[]
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

        private Location TopLeft() => new Location(this.X - 1, this.Y - 1);
        private Location Top() => new Location(this.X - 1, this.Y);
        private Location TopRight() => new Location(this.X - 1, this.Y + 1);
        private Location Left() => new Location(this.X, this.Y - 1);
        private Location Right() => new Location(this.X, this.Y + 1);
        private Location BottomLeft() => new Location(this.X + 1, this.Y - 1);
        private Location Bottom() => new Location(this.X + 1, this.Y);
        private Location BottomRight() => new Location(this.X + 1, this.Y + 1);

    }
}