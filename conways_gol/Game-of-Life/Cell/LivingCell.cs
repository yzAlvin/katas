namespace Game_of_Life
{
    public class LivingCell : ICell
    {
        private const int LowerPopulationBound = 2;
        private const int UpperPopulationBound = 3;
        private static string CellString = "*";

        public bool AliveNextGeneration(int numberOfNeighbours) =>
            Survival(numberOfNeighbours)
            && !Underpopulation(numberOfNeighbours)
            && !Overcrowding(numberOfNeighbours);

        private bool Survival(int numberOfNeighbours) =>
            numberOfNeighbours == LowerPopulationBound
            || numberOfNeighbours == UpperPopulationBound;

        private bool Underpopulation(int numberOfNeighbours) =>
            numberOfNeighbours < LowerPopulationBound;

        private bool Overcrowding(int numberOfNeighbours) =>
            numberOfNeighbours > UpperPopulationBound;

        public override string ToString() => CellString;

        public static void SetString(string s) => CellString = s;
    }
}