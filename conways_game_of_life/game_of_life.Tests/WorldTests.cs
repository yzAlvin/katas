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

        [Fact]
        public void World_Is_Not_Empty_After_Adding_Live_Cell()
        {
            var world = new World(3, 3);
            world.SetLivingAt(new Coordinate(1, 1));
            Assert.False(world.IsEmpty());
        }

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        [InlineData(-1, 1)]
        public void World_Throws_Exception_If_Negative(int width, int height)
        {
            Assert.Throws<ArgumentException>(() => new World(width, height));
        }

        [Fact]
        public void World_Gets_Neighbours()
        {
            var world = new World(3, 3);
            world.SetLivingAt(new Coordinate(0, 1));
            world.SetLivingAt(new Coordinate(1, 0));
            

        }
    }
}
