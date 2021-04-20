using Xunit;

namespace Game_of_Life.Tests
{
    public class DeadCellTests
    {
        [Theory]
        [InlineData(3)]
        public void AliveNextGeneration_ReturnsTrue_If_FertileNumberOfNeighbours(int fertileNumberOfNeighbours)
        {
            var deadCell = new DeadCell();
            Assert.True(deadCell.AliveNextGeneration(fertileNumberOfNeighbours));
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        public void AliveNextGeneration_ReturnsFalse_If_NotFertileNumberOfNeighbours(int notFertileNumberOfNeighbours)
        {
            var deadCell = new DeadCell();
            Assert.False(deadCell.AliveNextGeneration(notFertileNumberOfNeighbours));
        }
    }
}