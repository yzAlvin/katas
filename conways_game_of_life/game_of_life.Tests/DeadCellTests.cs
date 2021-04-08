using System;
using Xunit;

namespace game_of_life.Tests
{
    public class DeadCellTests
    {
        [Theory]
        [InlineData(3)]
        public void Dead_Cell_Revives_With_Three_Live_Neighbours(int numberOfNeighbours)
        {
            var deadCell = new DeadCell();
            Assert.True(deadCell.AliveNextGeneration(numberOfNeighbours));
        }
    }
}