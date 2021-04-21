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

        private static string WorldToString(World world, List<Location2D> locations)
        {
            var worldAsString = new StringBuilder();

            var cellsAdded = 0;
            foreach (var location in locations)
            {
                worldAsString.Append(CellCharacters.CellSymbols[location.Cell.GetType()]);
                cellsAdded++;
                if (world.Width == cellsAdded)
                {
                    worldAsString.AppendLine();
                    cellsAdded = 0;
                }
            }
            return worldAsString.ToString();
        }

        private static void WorldToString(World world, List<Location3D> locations)
        {
            throw new NotImplementedException();
        }
    }
}