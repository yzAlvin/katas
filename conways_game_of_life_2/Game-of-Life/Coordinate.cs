using System.Collections.Generic;

namespace Game_of_Life
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Coordinate(int x = 0, int y = 0, int z = 0)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Coordinate[] Neighbours()
        {
            var neighbourOps = new int[] { -1, 0, 1 };
            var neighbours = new List<Coordinate>();
            foreach (var i in neighbourOps)
            {
                foreach (var j in neighbourOps)
                {
                    foreach (var k in neighbourOps)
                    {
                        if (i == 0 && j == 0 && k == 0) continue;
                        neighbours.Add(new Coordinate(X + i, Y + j, Z + k));
                    }
                }
            }
            return neighbours.ToArray();
        }

        public Coordinate WrapCoordinate(WorldSize upperBound)
        {
            var wrappedX = X;
            var wrappedY = Y;
            var wrappedZ = Z;
            if (X < 0) wrappedX = upperBound.Height + X;
            if (Y < 0) wrappedY = upperBound.Width + Y;
            if (Z < 0) wrappedZ = upperBound.Depth + Z;
            if (X > upperBound.Height - 1) wrappedX = X - upperBound.Height;
            if (Y > upperBound.Width - 1) wrappedY = Y - upperBound.Width;
            if (Z > upperBound.Depth - 1) wrappedZ = Z - upperBound.Depth;
            return new Coordinate(wrappedX, wrappedY, wrappedZ);
        }

        public override bool Equals(object obj)
        {
            Coordinate otherCoord = obj as Coordinate;
            if (otherCoord == null) return false;
            return X == otherCoord.X && Y == otherCoord.Y && Z == otherCoord.Z;
        }

    }
}

// public Location[] Neighbours()=> new Location[]
// {
//     this.BackTopLeft(),
//     this.BackTopMid(),
//     this.BackTopRight(),
//     this.BackMidLeft(),
//     this.BackMidMid(),
//     this.BackMidRight(),
//     this.BackBottomLeft(),
//     this.BackBottomMid(),
//     this.BackBottomRight(),

//     this.MidTopLeft(),
//     this.MidTopMid(),
//     this.MidTopRight(),
//     this.MidMidLeft(),
//     this.MidMidRight(),
//     this.MidBottomLeft(),
//     this.MidBottomMid(),
//     this.MidBottomRight(),

//     this.FrontTopLeft(),  
//     this.FrontTopMid(),  
//     this.FrontTopRight(),
//     this.FrontMidLeft(),  
//     this.FrontMidMid(),  
//     this.FrontMidRight(),  
//     this.FrontBottomLeft(),  
//     this.FrontBottomMid(),  
//     this.FrontBottomRight(),  
// };

// private Location BackTopLeft() => new Location(this.X - 1, this.Y - 1, this.Z - 1);
// private Location BackTopMid() => new Location(this.X - 1, this.Y - 1, this.Z);
// private Location BackTopRight() => new Location(this.X - 1, this.Y - 1, this.Z + 1);
// private Location BackMidLeft() => new Location(this.X - 1, this.Y, this.Z - 1);
// private Location BackMidMid() => new Location(this.X - 1, this.Y, this.Z );
// private Location BackMidRight() => new Location(this.X - 1, this.Y, this.Z + 1);
// private Location BackBottomLeft() => new Location(this.X -1, this.Y + 1, this.Z - 1);
// private Location BackBottomMid() => new Location(this.X -1, this.Y + 1, this.Z);
// private Location BackBottomRight() => new Location(this.X -1, this.Y + 1, this.Z + 1);
// private Location MidTopLeft() => new Location(this.X, this.Y - 1, this.Z - 1);
// private Location MidTopMid() => new Location(this.X, this.Y - 1, this.Z);
// private Location MidTopRight() => new Location(this.X, this.Y - 1, this.Z + 1);
// private Location MidMidLeft() => new Location(this.X, this.Y, this.Z - 1);
// private Location MidMidRight() => new Location(this.X, this.Y, this.Z + 1);
// private Location MidBottomLeft() => new Location(this.X, this.Y + 1, this.Z - 1);
// private Location MidBottomMid() => new Location(this.X, this.Y + 1, this.Z);
// private Location MidBottomRight() => new Location(this.X, this.Y + 1, this.Z + 1);
// private Location FrontTopLeft() => new Location(this.X + 1, this.Y - 1, this.Z - 1);
// private Location FrontTopMid() => new Location(this.X + 1, this.Y - 1, this.Z);
// private Location FrontTopRight() => new Location(this.X + 1, this.Y - 1, this.Z + 1);
// private Location FrontMidLeft() => new Location(this.X + 1, this.Y, this.Z - 1);
// private Location FrontMidMid() => new Location(this.X + 1, this.Y, this.Z);
// private Location FrontMidRight() => new Location(this.X + 1, this.Y, this.Z + 1);
// private Location FrontBottomLeft() => new Location(this.X + 1, this.Y + 1, this.Z - 1);
// private Location FrontBottomMid() => new Location(this.X + 1, this.Y + 1, this.Z);
// private Location FrontBottomRight() => new Location(this.X + 1, this.Y + 1, this.Z + 1);