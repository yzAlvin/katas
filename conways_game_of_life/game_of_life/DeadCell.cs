namespace game_of_life
{
    public class DeadCell : ICell
    {
        public DeadCell()
        {

        }

        public bool AliveNextGeneration(int numberOfNeighbours) => FertileNeighbourhood(numberOfNeighbours);
        
        private bool FertileNeighbourhood(int numberOfNeighbours) => numberOfNeighbours == 3;
    }
}