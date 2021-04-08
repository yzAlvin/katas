using System;
using Xunit;
using Moq;
using System.IO;

namespace game_of_life.Tests
{
    public class WorldTests
    {
        [Fact]
        public void New_World_Is_Empty()
        {
            var world = new World();
            Assert.True(world.IsEmpty());
        }

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        [InlineData(-1, 1)]
        public void World_Throws_Exception_If_Negative(int width, int height)
        {
            Assert.Throws<ArgumentException>(() => new World(width, height));
        }
    }
}
