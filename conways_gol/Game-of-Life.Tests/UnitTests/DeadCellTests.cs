using Xunit;

namespace Game_of_Life.Tests
{
    public class DeadCellTests
    {
        DeadCell deadCell = new DeadCell();

        [Theory]
        [InlineData(3)]
        public void AliveNextGeneration_ReturnsTrue_If_FertileNumberOfNeighbours(int fertileNumberOfNeighbours)
        {
            Assert.True(deadCell.AliveNextGeneration(fertileNumberOfNeighbours));
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        public void AliveNextGeneration_ReturnsFalse_If_NotFertileNumberOfNeighbours(int notFertileNumberOfNeighbours)
        {
            Assert.False(deadCell.AliveNextGeneration(notFertileNumberOfNeighbours));
        }

        [Fact]
        public void ToString_Returns_CellString()
        {
            Assert.Equal(".", deadCell.ToString());
        }

        [Fact]
        [Trait("Category", "NotThreadSafe")]
        public void SetString_Sets_CellString()
        {
            DeadCell.SetString("x");
            Assert.Equal("x", deadCell.ToString());
        }
    }
}