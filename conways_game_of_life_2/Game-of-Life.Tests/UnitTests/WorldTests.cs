using System;
using System.Linq;
using Xunit;

namespace Game_of_Life.Tests
{
    public class WorldTests
    {
        [Theory]
        [InlineData(-1, -1)]
        [InlineData(0, -1)]
        [InlineData(-1, 0)]
        public void World_ThrowsArgumentException_With_Negative_Sizes(int badWidth, int badHeight)
        {
            Assert.Throws<ArgumentException>(() => new World(badWidth, badHeight));
        }

        [Fact]
        public void IsEmpty_ReturnsTrue_With_NewWorld()
        {
            var emptyWorld = new World(1, 1);
            Assert.True(emptyWorld.IsEmpty());
        }

        [Fact]
        public void SetLivingAt_CreatesLivingCell_At_Location()
        {
            var worldWithLife = new World(3, 3);
            var locationOfLife = new Location2D(0, 0);
            worldWithLife.SetLivingAt(locationOfLife);
            Assert.IsType<LivingCell>(worldWithLife.Locations.Single(l => l.Equals(locationOfLife)).Cell);
        }

        [Fact]
        public void SetLivingAt_ThrowsArgumentException_At_LocationOutOfBounds()
        {
            var world = new World(3, 3);
            var outOfBounds = new Location2D(5, 5);
            Assert.Throws<ArgumentException>(() => world.SetLivingAt(outOfBounds));
        }

        [Fact]
        public void IsEmpty_ReturnsFalse_With_WorldWithLivingCells()
        {
            var world = new World(3, 3);
            var someLocation = new Location2D(1, 1);
            world.SetLivingAt(someLocation);
            Assert.False(world.IsEmpty());
        }

        [Fact]
        public void Tick_EmptyWorld_Is_Empty_NextGeneration()
        {
            var world = new World(3, 3);
            world.Tick();
            Assert.True(world.IsEmpty());
        }

        [Fact]
        public void Tick_WorldWithLife_Updates_NextGeneration()
        {
            var world = new World(3, 3);
            var topLeft = new Location2D(0, 0);
            world.SetLivingAt(topLeft);
            Assert.False(world.IsEmpty());
            world.Tick();
            Assert.True(world.IsEmpty());
        }

        [Fact]
        public void Tick_WorldWithLifeOnEdges_Updates_NextGeneration()
        {
            var world = new World(5, 5);
            var liveCellLocations = new Location2D[]{new Location2D(0, 0), new Location2D(0, 1), new Location2D(4, 4)};
            world.SetLivingAt(liveCellLocations);

            Array.ForEach(liveCellLocations, locationOfLife => Assert.IsType<LivingCell>(world.Locations.Single(l => l.Equals(locationOfLife)).Cell));
            
            world.Tick();
            var locationOfStillLife = new Location2D(0, 0);
            var locationOfNewLife = new Location2D(4, 0);
            Assert.IsType<LivingCell>(world.Locations.Single(l => l.Equals(locationOfNewLife)).Cell);
            Assert.IsType<LivingCell>(world.Locations.Single(l => l.Equals(locationOfStillLife)).Cell);

            world.Tick();
            Assert.True(world.IsEmpty());
        }
    }
}
