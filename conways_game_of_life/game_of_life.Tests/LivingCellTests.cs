using System;
using Xunit;

namespace game_of_life.Tests
{
    public class LivingCellTests
    {
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        // 2 and 3 are implementation details, put in a separate file, rename test to 'survives with nice neighbourhood?'
        public void Living_Cell_Survives_With_Two_Or_Three_Neighbours(int numberOfNeighbours)
        {
            var livingCell = new LivingCell();
            Assert.True(livingCell.AliveNextGeneration(numberOfNeighbours));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void Living_Cell_Dies_By_Underpopulation(int numberOfNeighbours)
        {
            var livingCell = new LivingCell();
            Assert.False(livingCell.AliveNextGeneration(numberOfNeighbours));
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