using System;
using System.Linq;

namespace Game_of_Life
{
    public static class Validation
    {
        public static bool ValidWorldSize(string[] worldSize) =>
            SizeIs2DOr3D(worldSize) && worldSize.All(IsValidInt);

        public static bool ValidCoords(string coords, WorldSize worldSize) =>
            coords.All(ValidCoordChars) && LegitCoords(coords, worldSize);

        public static string CleanCoords(string coords) =>
            String.Join("", (coords.Where(ValidCoordChars)));

        private static bool SizeIs2DOr3D(string[] worldSize) =>
            worldSize.Length == 2 || worldSize.Length == 3;

        private static bool IsValidInt(string size) =>
            int.TryParse(size, out var _);

        private static bool ValidCoordChars(char c) =>
            Char.IsDigit(c) || c == '.' || c == ',';

        private static bool LegitCoords(string coords, WorldSize worldSize)
        {
            var coordsArary = coords.Split(".");

            foreach (var c in coordsArary)
            {
                var coordinatePair = c.Split(",");
                if (!coordinatePair.All(IsValidInt) || !SizeIs2DOr3D(coordinatePair)) return false;
                var coordinatesAsIntegers = coordinatePair.Select(int.Parse).ToArray();
                Coordinate a = new Coordinate(
                        coordinatesAsIntegers[0],
                        coordinatesAsIntegers[1],
                        coordinatePair.Length == 3 ? coordinatesAsIntegers[2] : 0
                );
                if (OutOfBounds(a, worldSize)) return false;
            }
            return true;
        }

        private static bool OutOfBounds(Coordinate c, WorldSize upperBound) =>
            c.X < 0 || c.X > upperBound.Width
            || c.Y < 0 || c.Y > upperBound.Height
            || c.Z < 0 || c.Z > upperBound.Depth;
    }
}