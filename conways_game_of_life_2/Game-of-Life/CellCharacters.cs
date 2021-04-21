using System;
using System.Collections.Generic;

namespace Game_of_Life
{
    public static class CellCharacters
    {
        public static Dictionary<Type, char> CellSymbols = new Dictionary<Type, char>
        {
            {typeof(LivingCell), '*'},
            {typeof(DeadCell), '.'},
        };
    }
}