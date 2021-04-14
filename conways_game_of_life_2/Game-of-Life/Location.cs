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
        
        // maybe these should be in their own class or something? I think this makes things more readable when you want to find neighbours, 
        // also abstracts away knowledge of location, maybe I can make location an interface later so different types of location calculate neighbours differently
        // Ideally I want GetNeighbours to be in the location class but I don't know how to deal with wrapping around the edges of the world because world size needs to belong to the world. 
        // I don't want to use a global variable
        public Location TopLeft() => new Location(this.X - 1, this.Y - 1);
        public Location Top() => new Location(this.X - 1, this.Y);
        public Location TopRight() => new Location(this.X - 1, this.Y + 1);
        public Location Left() => new Location(this.X, this.Y - 1);
        public Location Right() => new Location(this.X, this.Y + 1);
        // public Location Self() => new Location(this.X, this.Y); if I follow YAGNI I shouldn't implement this
        public Location BottomLeft() => new Location(this.X + 1, this.Y - 1);
        public Location Bottom() => new Location(this.X + 1, this.Y);
        public Location BottomRight() => new Location(this.X + 1, this.Y + 1);
    }
}