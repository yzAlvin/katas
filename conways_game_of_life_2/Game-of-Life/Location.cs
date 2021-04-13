using System;

namespace Game_of_Life
{
    public class Location
    {
        public int X {get; set;}
        public int Y {get; set;}
        public ICell Cell {get; set;}

        public Location(int x, int y)
        {
            X = x;
            Y = y;
            Cell = new DeadCell();
        }

        public void BecomeAlive() => this.Cell = new LivingCell();

        public void BecomeDead() => this.Cell = new DeadCell();

        public override bool Equals(object obj)
        {
            Location otherCoord = obj as Location;
            return X == otherCoord.X && Y == otherCoord.Y;
        }

        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return $"({this.X}, {this.Y}): {this.Cell.GetType().Name}";
        }
        
        public Location TopLeft() => new Location(this.X - 1, this.Y - 1);
        public Location Top() => new Location(this.X - 1, this.Y);
        public Location TopRight() => new Location(this.X - 1, this.Y + 1);
        public Location Left() => new Location(this.X, this.Y - 1);
        public Location Right() => new Location(this.X, this.Y + 1);
        public Location Self() => new Location(this.X, this.Y);
        public Location BottomLeft() => new Location(this.X + 1, this.Y - 1);
        public Location Bottom() => new Location(this.X + 1, this.Y);
        public Location BottomRight() => new Location(this.X + 1, this.Y + 1);
    }
}