using System;

namespace Game_of_Life
{
    public class DeadCell : ICell
    {
        private const int FertileThreshold = 3;

        public bool AliveNextGeneration(int numberOfNeighbours) => FertileNeighbourhood(numberOfNeighbours);

        private bool FertileNeighbourhood(int numberOfNeighbours) => numberOfNeighbours == FertileThreshold;
    }
}