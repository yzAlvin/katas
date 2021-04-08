namespace game_of_life
{
    public class LivingCell : ICell
    {
        public LivingCell()
        {

        }

        public bool AliveNextGeneration(int numberOfNeighbours) => Survival(numberOfNeighbours)
                                                            && !Underpopulation(numberOfNeighbours)
                                                            && !Overcrowding(numberOfNeighbours);

        private bool Survival(int numberOfNeighbours) => (numberOfNeighbours == 2 || numberOfNeighbours == 3);
        private bool Underpopulation(int numberOfNeighbours) => (numberOfNeighbours < 2);
        private bool Overcrowding(int numberOfNeighbours) => (numberOfNeighbours > 3);
    }
}