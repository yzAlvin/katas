using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Game_of_Life
{
    public class WorldRenderer
    {
        public static string RenderWorld(World world) => WorldToString(world, world.Locations);

        private static string WorldToString(World world, List<Location> locations)
        {
            var worldAsString = new StringBuilder();
            for (var height = 0; height < world.Size.Height; height++)
            {
                for (var depth = 0; depth < world.Size.Depth; depth++)
                {
                    for (var width = 0; width < world.Size.Width; width++)
                    {
                        worldAsString.Append(
                            GetCell(locations, height, width, depth).ToString()
                        );
                    }
                    if (depth != world.Size.Depth - 1) worldAsString.Append("|");
                }
                worldAsString.AppendLine();
            }
            return worldAsString.ToString();
        }

        private static ICell GetCell(List<Location> locations, int height, int width, int depth) =>
            locations.Single(l => l.Coordinate.Equals(new Coordinate(height, width, depth))).Cell;
    }
}