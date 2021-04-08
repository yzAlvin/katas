using System.Collections.Generic;

namespace game_of_life
{
    public class World
    {
        private List<LivingCell> _livingCells = new List<LivingCell>();
        public World()
        {

        }

        public bool IsEmpty()
        {
            return true;
        }
    }
}