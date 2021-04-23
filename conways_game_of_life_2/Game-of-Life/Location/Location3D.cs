using System;
using System.Collections.Generic;

namespace Game_of_Life
{
    public class Location3D : ILocation
    {
        public int X {get; set;}
        public int Y {get; set;}
        public int Z {get; set;}

        public Location3D(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override bool Equals(object obj)
        {
            Location3D otherCoord = obj as Location3D;
            if (otherCoord == null) return false;
            return X == otherCoord.X && Y == otherCoord.Y && Z == otherCoord.Z;
        }

        public override IEnumerable<Location3D> Neighbours()=> new Location3D[]
        {
            this.BackTopLeft(),
            this.BackTopMid(),
            this.BackTopRight(),
            this.BackMidLeft(),
            this.BackMidMid(),
            this.BackMidRight(),
            this.BackBottomLeft(),
            this.BackBottomMid(),
            this.BackBottomRight(),

            this.MidTopLeft(),
            this.MidTopMid(),
            this.MidTopRight(),
            this.MidMidLeft(),
            this.MidMidRight(),
            this.MidBottomLeft(),
            this.MidBottomMid(),
            this.MidBottomRight(),

            this.FrontTopLeft(),  
            this.FrontTopMid(),  
            this.FrontTopRight(),
            this.FrontMidLeft(),  
            this.FrontMidMid(),  
            this.FrontMidRight(),  
            this.FrontBottomLeft(),  
            this.FrontBottomMid(),  
            this.FrontBottomRight(),  
        };

        private Location3D BackTopLeft() => new Location3D(this.X - 1, this.Y - 1, this.Z - 1);
        private Location3D BackTopMid() => new Location3D(this.X - 1, this.Y - 1, this.Z);
        private Location3D BackTopRight() => new Location3D(this.X - 1, this.Y - 1, this.Z + 1);
        private Location3D BackMidLeft() => new Location3D(this.X - 1, this.Y, this.Z - 1);
        private Location3D BackMidMid() => new Location3D(this.X - 1, this.Y, this.Z );
        private Location3D BackMidRight() => new Location3D(this.X - 1, this.Y, this.Z + 1);
        private Location3D BackBottomLeft() => new Location3D(this.X -1, this.Y + 1, this.Z - 1);
        private Location3D BackBottomMid() => new Location3D(this.X -1, this.Y + 1, this.Z);
        private Location3D BackBottomRight() => new Location3D(this.X -1, this.Y + 1, this.Z + 1);
        private Location3D MidTopLeft() => new Location3D(this.X, this.Y - 1, this.Z - 1);
        private Location3D MidTopMid() => new Location3D(this.X, this.Y - 1, this.Z);
        private Location3D MidTopRight() => new Location3D(this.X, this.Y - 1, this.Z + 1);
        private Location3D MidMidLeft() => new Location3D(this.X, this.Y, this.Z - 1);
        private Location3D MidMidRight() => new Location3D(this.X, this.Y, this.Z + 1);
        private Location3D MidBottomLeft() => new Location3D(this.X, this.Y + 1, this.Z - 1);
        private Location3D MidBottomMid() => new Location3D(this.X, this.Y + 1, this.Z);
        private Location3D MidBottomRight() => new Location3D(this.X, this.Y + 1, this.Z + 1);
        private Location3D FrontTopLeft() => new Location3D(this.X + 1, this.Y - 1, this.Z - 1);
        private Location3D FrontTopMid() => new Location3D(this.X + 1, this.Y - 1, this.Z);
        private Location3D FrontTopRight() => new Location3D(this.X + 1, this.Y - 1, this.Z + 1);
        private Location3D FrontMidLeft() => new Location3D(this.X + 1, this.Y, this.Z - 1);
        private Location3D FrontMidMid() => new Location3D(this.X + 1, this.Y, this.Z);
        private Location3D FrontMidRight() => new Location3D(this.X + 1, this.Y, this.Z + 1);
        private Location3D FrontBottomLeft() => new Location3D(this.X + 1, this.Y + 1, this.Z - 1);
        private Location3D FrontBottomMid() => new Location3D(this.X + 1, this.Y + 1, this.Z);
        private Location3D FrontBottomRight() => new Location3D(this.X + 1, this.Y + 1, this.Z + 1);

        public override Location3D WrapLocation(int width, int height, int depth)
        {
            var wrappedX = X;
            var wrappedY = Y;
            var wrappedZ = Z;
            if (X < 0) wrappedX = height + X;
            if (Y < 0) wrappedY = width + Y;
            if (Z < 0) wrappedY = depth + Z;
            if (X > height - 1) wrappedX = X - height;
            if (Y > width - 1) wrappedY = Y - width;
            if (Z > depth - 1) wrappedY = Z - depth;
            return new Location3D(wrappedX, wrappedY, wrappedZ);
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }
    }
}