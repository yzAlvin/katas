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
        
        private static string WorldToString(World world, List<ILocation> locations)
        {
            var worldAsString = new StringBuilder();

            // BAD
            var cellsAdded = 0;
            foreach (var location in locations)
            {
                worldAsString.Append(CellCharacters.CellSymbols[location.Cell.GetType()]);
                cellsAdded++;
                if (world.Size.Depth == 1)
                {
                    if (world.Size.Width == cellsAdded)
                    {
                        worldAsString.AppendLine();
                        cellsAdded = 0;
                    }
                }
                else
                {
                    var sliceSize = world.Size.Width * world.Size.Depth;
                    if (cellsAdded % world.Size.Width == 0 && cellsAdded != sliceSize)
                    {
                        worldAsString.Append("|");
                    }
                    if (sliceSize == cellsAdded)
                    {
                        worldAsString.AppendLine();
                        cellsAdded = 0;
                    }
                }
            }
            return worldAsString.ToString(); 
        }

        private ICell GetCell(World world, ILocation location) => world.Locations.Single(l => l.Equals(location)).Cell;

    }
}