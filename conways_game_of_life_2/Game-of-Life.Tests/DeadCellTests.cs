using Xunit;

namespace Game_of_Life.Tests
{
    public class DeadCellTests
    {
        [Theory]
        [InlineData(3)]
        public void Dead_Cell_Revives_With_Fertile_Neighbours(int numberOfNeighbours)
        {
            var deadCell = new DeadCell();
            Assert.True(deadCell.AliveNextGeneration(numberOfNeighbours));
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        public void Dead_Cell_Stays_Dead_With_Not_Fertile_Neighbourhood(int numberOfNeighbours)
        {
            var deadCell = new DeadCell();
            Assert.False(deadCell.AliveNextGeneration(numberOfNeighbours));
        }
    }
}