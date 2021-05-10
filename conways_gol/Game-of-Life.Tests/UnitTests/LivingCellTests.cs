using Xunit;

namespace Game_of_Life.Tests
{
    public class LivingCellTests
    {
        LivingCell livingCell = new LivingCell();

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void AliveNextGeneration_ReturnsFalse_If_NumberOfNeighboursIsUnderpopulation(int underpopulationNumberOfNeighbours)
        {
            Assert.False(livingCell.AliveNextGeneration(underpopulationNumberOfNeighbours));
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void AliveNextGeneration_ReturnsTrue_If_NumberOfNeighboursIsSurvival(int survivalNumberOfNeighbours)
        {
            Assert.True(livingCell.AliveNextGeneration(survivalNumberOfNeighbours));
        }

        [Theory]
        [InlineData(4)]
        public void AliveNextGeneration_ReturnsFalse_If_NumberOfNeighboursIsOvercrowding(int overcrowdingNumberOfNeighbours)
        {
            Assert.False(livingCell.AliveNextGeneration(overcrowdingNumberOfNeighbours));
        }

        [Fact]
        public void ToString_Returns_CellString()
        {
            Assert.Equal("*", livingCell.ToString());
        }

        [Fact]
        [Trait("Category", "NotThreadSafe")]
        public void SetString_Sets_CellString()
        {
            LivingCell.SetString("o");
            Assert.Equal("o", livingCell.ToString());
        }
    }
}