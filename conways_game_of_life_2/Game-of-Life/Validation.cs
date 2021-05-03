using System;
using System.Linq;

namespace Game_of_Life
{
    public static class Validation
    {
        public static bool ValidWorldSize(string[] worldSize) => SizeIs2DOr3D(worldSize) && worldSize.All(IsValidInt);

        public static bool ValidCoords(string coords, WorldSize worldSize) => coords.All(ValidCoordChars) && LegitCoords(coords, worldSize);

        public static string CleanCoords(string coords) => String.Join("", (coords.Where(ValidCoordChars)));

        private static bool SizeIs2DOr3D(string[] worldSize) => worldSize.Length == 2 || worldSize.Length == 3;

        private static bool IsValidInt(string size) => int.TryParse(size, out var _);

        private static bool ValidCoordChars(char c) => Char.IsDigit(c) || c == '.' || c == ',';

        private static bool LegitCoords(string coords, WorldSize worldSize)
        {
            var coordsArary = coords.Split(".");

            foreach (var c in coordsArary)
            {
                var coordsStringArray = c.Split(",");
                if (!coordsStringArray.All(IsValidInt)) return false;
                var coordsIntArray = coordsStringArray.Select(int.Parse).ToArray();
                if (coordsIntArray.Length != 2 && coordsIntArray.Length != 3) return false;
                int x = coordsIntArray[0];
                int y = coordsIntArray[1];
                int z = coordsStringArray.Length == 3 ? coordsIntArray[2] : 0;
                if (OutOfBounds(x, y, z, worldSize)) return false;
            }
            return true;
        }

        private static bool OutOfBounds(int x, int y, int z, WorldSize upperBound) =>
            x < 0 || x > upperBound.Width
            || y < 0 || y > upperBound.Height
            || z < 0 || z > upperBound.Depth;
    }
}