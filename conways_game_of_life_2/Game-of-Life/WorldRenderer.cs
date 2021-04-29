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

            var cellsAdded = 0;
            foreach (var location in locations)
            {
                worldAsString.Append(CellCharacters.CellSymbols[location.Cell.GetType()]);
                cellsAdded++;

                var sliceSize = world.Size.Width * world.Size.Depth;
                bool EndOfWidthOfSlice = cellsAdded % world.Size.Width == 0 && cellsAdded != sliceSize;
                if (EndOfWidthOfSlice)
                {
                    worldAsString.Append("|");
                }
                if (sliceSize == cellsAdded)
                {
                    worldAsString.AppendLine();
                    cellsAdded = 0;
                }
            }
            return worldAsString.ToString(); 
        }

        private static string WorldToString2(World world, List<Location> locations)
        {
            var worldAsString = new StringBuilder();
            for (var h = 0; h < world.Size.Height; h++)
            {
                for (var d = 0; d < world.Size.Depth; d++)
                {
                    for (var w = 0; w < world.Size.Width; w++)
                    {
                        worldAsString.Append(CellCharacters.CellSymbols[locations.Single(l => l.Equals(new Location(h, w, d))).Cell.GetType()]);
                    }
                    if (d != world.Size.Depth - 1) worldAsString.Append("|");
                }
                worldAsString.AppendLine();
            }
            return worldAsString.ToString();
        }

    }
}