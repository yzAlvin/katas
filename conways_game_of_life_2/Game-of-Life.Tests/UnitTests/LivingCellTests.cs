using Xunit;

namespace Game_of_Life.Tests
{
    public class LivingCellTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void AliveNextGeneration_ReturnsFalse_If_NumberOfNeighboursIsUnderpopulation(int underpopulationNumberOfNeighbours)
        {
            var livingCell = new LivingCell();
            Assert.False(livingCell.AliveNextGeneration(underpopulationNumberOfNeighbours));
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void AliveNextGeneration_ReturnsTrue_If_NumberOfNeighboursIsSurvival(int survivalNumberOfNeighbours)
        {
            var livingCell = new LivingCell();
            Assert.True(livingCell.AliveNextGeneration(survivalNumberOfNeighbours));
        }

        [Theory]
        [InlineData(4)]
        public void AliveNextGeneration_ReturnsFalse_If_NumberOfNeighboursIsOvercrowding(int overcrowdingNumberOfNeighbours)
        {
            var livingCell = new LivingCell();
            Assert.False(livingCell.AliveNextGeneration(overcrowdingNumberOfNeighbours));
        }
    }
}