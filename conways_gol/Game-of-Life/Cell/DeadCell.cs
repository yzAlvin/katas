using System;

namespace Game_of_Life
{
    public class DeadCell : ICell
    {
        private const int FertileThreshold = 3;
        protected static string CellString = ".";

        public bool AliveNextGeneration(int numberOfNeighbours) =>
            FertileNeighbourhood(numberOfNeighbours);

        private bool FertileNeighbourhood(int numberOfNeighbours) =>
            numberOfNeighbours == FertileThreshold;

        public override string ToString() => CellString;

        public static void SetString(string s) => CellString = s;
    }
}