using System;
using Xunit;

namespace minesweeper.Tests
{
    public class CellTests
    {
        [Fact]
        public void Cell_Default_Is_Not_Mine()
        {
            var location = new Location(0, 0);
            var cell = new Cell(location);
            Assert.False(cell.IsMine);
        }

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        [InlineData(-1, -1)]
        public void Cell_Throws_Exception_If_Negative_Position(int x, int y)
        {
            Assert.Throws<ArgumentException>(() => new Cell(new Location(x, y)));
        }
    }
}