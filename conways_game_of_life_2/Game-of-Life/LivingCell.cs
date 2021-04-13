namespace Game_of_Life
{
    public class LivingCell : ICell
    {
        private const int lowerPopulationBound = 2;
        private const int upperPopulationBound = 3;

        public LivingCell()
        {
        }

        public bool AliveNextGeneration(int numberOfNeighbours) => Survival(numberOfNeighbours)
                                                            && !Underpopulation(numberOfNeighbours)
                                                            && !Overcrowding(numberOfNeighbours);

        private bool Survival(int numberOfNeighbours) => numberOfNeighbours == lowerPopulationBound || numberOfNeighbours == upperPopulationBound;
        private bool Underpopulation(int numberOfNeighbours) => numberOfNeighbours < lowerPopulationBound;
        private bool Overcrowding(int numberOfNeighbours) => numberOfNeighbours > upperPopulationBound;
        
    }
}