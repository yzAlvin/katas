using System;
using Xunit;

namespace Game_of_Life.Tests
{
    public class WorldSizeTests
    {
        [Theory]
        [InlineData(-1, -1, -1)]
        [InlineData(0, 0, 0)]
        [InlineData(101, 101, 6)]
        public void World_ThrowsArgumentException_With_Negative_Sizes(int badWidth, int badHeight, int badDepth)
        {
            Assert.Throws<InvalidWorldSize>(() => new WorldSize(width: badWidth));
            Assert.Throws<InvalidWorldSize>(() => new WorldSize(height: badHeight));
            Assert.Throws<InvalidWorldSize>(() => new WorldSize(depth: badDepth));
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(100, 100, 5)]
        public void WorldSize_GoodSize(int goodWidth, int goodHeight, int goodDepth)
        {
            var worldSize = new WorldSize(goodWidth, goodHeight, goodDepth);
            Assert.Equal(goodWidth, worldSize.Width);
            Assert.Equal(goodHeight, worldSize.Height);
            Assert.Equal(goodDepth, worldSize.Depth);
        }
    }
}