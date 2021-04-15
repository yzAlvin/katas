using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Game_of_Life
{
    public static class WorldRenderer
    {

        public static string DisplayWorld(World world)
        {
            var locations = world.GetLocations();
            return RenderWorld(world, locations);
        }

        // constraint to keep public methods to 5 lines is this cheating 
        private static string RenderWorld(World world, IEnumerable<Location> locations)
        {
            var stringBuilder = new StringBuilder();
            var cellsAdded = 0;
            foreach (var location in locations)
            {
                stringBuilder.Append(location.Cell.GetType() == typeof(LivingCell) ? "*" : ".");
                cellsAdded++;
                if (world.Width == cellsAdded)
                {
                    stringBuilder.AppendLine();
                    cellsAdded = 0;
                }
            }
            return stringBuilder.ToString();
        }
    }
}