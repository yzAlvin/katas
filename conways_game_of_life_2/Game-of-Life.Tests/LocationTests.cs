using Xunit;

namespace Game_of_Life.Tests
{
    public class LocationTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void Living_Cell_Dies_By_Underpopulation(int numberOfNeighbours)
        {
            var livingCell = new LivingCell();
            Assert.False(livingCell.AliveNextGeneration(numberOfNeighbours));
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        // 0, 1, 2, 3 and 4 are implementation details, put in a separate file? make them global constants or something
        public void Living_Cell_Survives_With_Nice_Neighbourhood(int numberOfNeighbours)
        {
            var livingCell = new LivingCell();
            Assert.True(livingCell.AliveNextGeneration(numberOfNeighbours));
        }

        [Theory]
        [InlineData(4)]
        public void Living_Cell_Dies_By_Overcrowding(int numberOfNeighbours)
        {
            var livingCell = new LivingCell();
            Assert.False(livingCell.AliveNextGeneration(numberOfNeighbours));
        }
    }
}