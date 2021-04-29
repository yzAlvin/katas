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

            // BAD
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

        private ICell GetCell(World world, Location location) => world.Locations.Single(l => l.Equals(location)).Cell;

    }
}