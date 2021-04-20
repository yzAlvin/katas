using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Game_of_Life
{
    public static class WorldRenderer
    {
        private static Dictionary<Type, char> CellCharacters = new Dictionary<Type, char>
        {
            {typeof(LivingCell), '*'},
            {typeof(DeadCell), '.'},
        };

        public static string StringifyWorld(World world)
        {
            var locations = world.Locations;
            var stringBuilder = new StringBuilder();
            var cellsAdded = 0;
            foreach (var location in locations)
            {
                stringBuilder.Append(CellCharacters[location.Cell.GetType()]);
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