using System;
using System.Linq;

namespace Game_of_Life
{
    public static class Validation
    {
        private const char coordinateSeparator = '.';
        private const char coordinatePairSeparator = ',';
        private const string worldSizeSeparator = "x";

        public static bool ValidWorldSize(string worldSize) =>
            SizeIs2DOr3D(worldSize.Split(worldSizeSeparator))
            && worldSize.Split(worldSizeSeparator).All(IsValidInt);

        public static bool ValidCoords(string coords, WorldSize worldSize) =>
            FormatCoords(coords).All(ValidCoordChars)
            && LegitCoords(FormatCoords(coords), worldSize)
            && !coords.Any(c => c == '-');

        private static string FormatCoords(string coords) =>
            String.Join("", (coords.Where(ValidCoordChars)));

        private static bool SizeIs2DOr3D(string[] worldSize) =>
            worldSize.Length == 2
            || worldSize.Length == 3;

        private static bool IsValidInt(string size) =>
            int.TryParse(size, out var n) && n >= 0;

        private static bool ValidCoordChars(char c) =>
            Char.IsDigit(c)
            || c == coordinateSeparator
            || c == coordinatePairSeparator;

        private static bool LegitCoords(string coordString, WorldSize worldSize)
        {
            var coordStringArray = coordString.Split(coordinateSeparator);

            foreach (var coordPair in coordStringArray)
            {
                var coord = coordPair.Split(coordinatePairSeparator);
                if (!(coord.All(IsValidInt) && SizeIs2DOr3D(coord))) return false;
                var coordIntPair = coord.Select(int.Parse).ToArray();
                Coordinate coordinate = new Coordinate(
                        coordIntPair[0],
                        coordIntPair[1],
                        coord.Length == 3 ? coordIntPair[2] : 0
                );
                if (OutOfBounds(coordinate, worldSize)) return false;
            }
            return true;
        }

        private static bool OutOfBounds(Coordinate c, WorldSize upperBound) =>
            c.X < 0 || c.X >= upperBound.Width
            || c.Y < 0 || c.Y >= upperBound.Height
            || c.Z < 0 || c.Z >= upperBound.Depth;
    }
}