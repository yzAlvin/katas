namespace Game_of_Life
{
    public interface ICell
    {
        bool AliveNextGeneration(int numberOfNeighbours);
        string ToString();
    }
}