namespace game_of_life
{
    public interface ICell
    {
        public bool AliveNextGeneration(int numberOfNeighbours);
    }
}