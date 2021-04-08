using System;
using Xunit;

namespace game_of_life.Tests
{
    public class LivingCellsTests
    {
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void Living_Cell_Stays_Alive(int numberOfNeighbours)
        {
            var livingCell = new LivingCell();
            Assert.True(livingCell.StayingAlive(numberOfNeighbours));
        }
        

    }
}