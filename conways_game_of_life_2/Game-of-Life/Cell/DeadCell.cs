using System;

namespace Game_of_Life
{
    public class DeadCell : ICell
    {
        private const int FertileThreshold = 3;
        private const string CellCharacter = ".";

        public bool AliveNextGeneration(int numberOfNeighbours) =>
            FertileNeighbourhood(numberOfNeighbours);

        public override string ToString() => CellCharacter;

        private bool FertileNeighbourhood(int numberOfNeighbours) =>
            numberOfNeighbours == FertileThreshold;
    }
}