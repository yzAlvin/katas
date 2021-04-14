using Xunit;

namespace Game_of_Life.Tests
{
    public class LivingCellTests
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

        // Should I test (and therefore also add to codebase) that the alive next Generation method throws an exception if it somehow receives a negative value?
        // Thoughts: the behaviour is that it will stay dead next generation anyway, but technically it should never receive a negative value based on behaviour so maybe it SHOULD throw an exception
        // should I have AliveNextGeneration it the test names because that is the method I am testing, but since I am thinking about 'behaviour' I have not included it in test name
    }
}