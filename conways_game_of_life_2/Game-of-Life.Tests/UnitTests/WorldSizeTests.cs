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

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(100, 100, 6)]
        public void WorldSize_GoodSize(int goodWidth, int goodHeight, int goodDepth)
        {
            var worldSize = new WorldSize(goodWidth, goodHeight, goodDepth);
            Assert.Equal(goodWidth, worldSize.Width);
            Assert.Equal(goodHeight, worldSize.Height);
            Assert.Equal(goodDepth, worldSize.Depth);
        }
    }
}