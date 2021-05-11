using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Game_of_Life
{
    public class WorldRenderer
    {
        private const string sliceSeparator = "|";

        public static string RenderWorld(World world)
        {
            var worldAsString = new StringBuilder();
            for (var height = 0; height < world.Size.Height; height++)
            {
                for (var depth = 0; depth < world.Size.Depth; depth++)
                {
                    for (var width = 0; width < world.Size.Width; width++)
                    {
                        worldAsString.Append(
                            GetCell(world.Locations, height, width, depth).ToString()
                        );
                    }
                    if (depth != world.Size.Depth - 1) worldAsString.Append(sliceSeparator);
                }
                worldAsString.AppendLine();
            }
            return worldAsString.ToString();
        }

        private static ICell GetCell(List<Location> locations, int h, int w, int d) =>
            locations.Single(l => l.Coordinate.Equals(new Coordinate(h, w, d))).Cell;
    }
}