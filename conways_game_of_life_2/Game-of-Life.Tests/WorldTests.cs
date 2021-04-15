using System;
using System.Linq;
using Xunit;

namespace Game_of_Life.Tests
{
    public class WorldTests
    {
        [Fact]
        public void New_World_Is_Empty()
        {
            var world = new World(1, 1);
            Assert.True(world.IsEmpty());
        }
        [Fact]
        public void World_Is_Not_Empty_After_Adding_Live_Cell()
        {
            var world = new World(3, 3);
            var someLocation = new Location(1, 1);
            world.SetLivingAt(someLocation);
            Assert.False(world.IsEmpty());
        }

        [Theory]
        [InlineData(-1, -1)]
        [InlineData(0, -1)]
        [InlineData(-1, 0)]
        public void World_Size_Must_Be_Positive(int badWidth, int badHeight)
        {
            Assert.Throws<ArgumentException>(() => new World(badWidth, badHeight));
        }

        [Theory]
        // This test could be better but lazy
        //corners
        [InlineData(0, 0)]
        [InlineData(2, 0)]
        [InlineData(0, 2)]
        [InlineData(2, 2)]
        //edges and not corner
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        //middle
        [InlineData(1, 1)]
        public void Field_Gets_Neighbouring_Cells_Of_A_Location_With_Wrap_Around(int x, int y)
        {
            var world = new World(3, 3);
            var location = new Location(x, y);
            var neighbouringLocations = world.GetNeighbours(location);
            
            Assert.Equal(8, neighbouringLocations.Count());
        }

        [Fact]
        // empty world is empty after tick?
        public void Empty_World_Is_Empty_Next_Generation()
        {
            var world = new World(3, 3);
            world.Tick();
            Assert.True(world.IsEmpty());
        }

        [Fact]
        public void World_With_One_Live_Cells_Dies_Next_Generation()
        {
            var world = new World(5, 3);
            var topLeft = new Location(0, 0);
            world.SetLivingAt(topLeft);
            Assert.False(world.IsEmpty());
            world.Tick();
            Assert.True(world.IsEmpty());
        }
    }
}
