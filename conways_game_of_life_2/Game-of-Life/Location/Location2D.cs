using System.Collections.Generic;

namespace Game_of_Life
{
    public class Location2D : ILocation<Location2D>
    {
        public int X {get; set;}
        public int Y {get; set;}
        public ICell Cell {get; set;}

        public Location2D(int x, int y)
        {
            this.X = x;
            this.Y = y;
            Cell = new DeadCell();
        }

        public void BecomeAlive() => this.Cell = new LivingCell();
        
        public void BecomeDead() => this.Cell = new DeadCell();

        public override bool Equals(object obj)
        {
            Location2D otherCoord = obj as Location2D;
            if (otherCoord == null) return false;
            return X == otherCoord.X && Y == otherCoord.Y;
        }

        public Location2D Clone() => new Location2D(this.X, this.Y);

        public IEnumerable<Location2D> Neighbours() => new Location2D[]
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
    }
}