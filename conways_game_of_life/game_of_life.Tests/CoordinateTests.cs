using System;
using Xunit;

namespace game_of_life.Tests
{
    public class CoordinateTests
    {
        [Theory]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        [InlineData(-1, 1)]
        public void Coordinate_Throws_Exception_If_Negative(int x, int y)
        {
            Assert.Throws<ArgumentException>(() => new Coordinate(x, y));
        }
        
        // remove this test because it is an implementation detail?
        [Fact]
        public void Coordinate_Defaults_Dead_Cell()
        {
            Assert.IsType<DeadCell>(new Coordinate(0, 0).Cell);
        }
    }
}