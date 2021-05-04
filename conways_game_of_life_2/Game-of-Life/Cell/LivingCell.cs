namespace Game_of_Life
{
    public class LivingCell : ICell
    {
        private const int LowerPopulationBound = 2;
        private const int UpperPopulationBound = 3;
        private const string CellCharacter = "*";

        public bool AliveNextGeneration(int numberOfNeighbours) =>
            Survival(numberOfNeighbours)
            && !Underpopulation(numberOfNeighbours)
            && !Overcrowding(numberOfNeighbours);

        public override string ToString() => CellCharacter;

        private bool Survival(int numberOfNeighbours) =>
            numberOfNeighbours == LowerPopulationBound
            || numberOfNeighbours == UpperPopulationBound;

        private bool Underpopulation(int numberOfNeighbours) =>
            numberOfNeighbours < LowerPopulationBound;

        private bool Overcrowding(int numberOfNeighbours) =>
            numberOfNeighbours > UpperPopulationBound;
    }
}