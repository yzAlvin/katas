namespace game_of_life
{
    public class LivingCell
    {
        public LivingCell()
        {

        }

        public bool StayingAlive(int numberOfNeighbours) => Survival(numberOfNeighbours);
        private bool Survival(int numberOfNeighbours) => (numberOfNeighbours == 2 || numberOfNeighbours == 3);
    }
}