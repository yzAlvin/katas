using System;
using Xunit;

namespace Game_of_Life.Tests
{
    public class WorldSizeTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(101)]
        public void World_ThrowsArgumentException_With_Negative_Sizes(int badSize)
        {
            Assert.Throws<ArgumentException>(() => new WorldSize(width: badSize));
            Assert.Throws<ArgumentException>(() => new WorldSize(height: badSize));
            Assert.Throws<ArgumentException>(() => new WorldSize(depth: badSize));
        }
    }
}