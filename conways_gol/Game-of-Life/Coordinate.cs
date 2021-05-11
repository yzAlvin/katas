using System.Collections.Generic;
using System.Linq;

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
            var displacementOfNeighbours = new int[] { -1, 0, 1 };
            var neighbours = new List<Coordinate>();
            foreach (var xDisplacement in displacementOfNeighbours)
            {
                foreach (var yDisplacement in displacementOfNeighbours)
                {
                    foreach (var zDisplacement in displacementOfNeighbours)
                    {
                        if (
                            xDisplacement == 0
                            && yDisplacement == 0
                            && zDisplacement == 0
                        ) continue;

                        neighbours.Add(new Coordinate(
                            X + xDisplacement,
                            Y + yDisplacement,
                            Z + zDisplacement
                        ));
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