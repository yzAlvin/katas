using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Game_of_Life.Tests
{
    public class WorldTests
    {
        private ICell GetCell(World world, Coordinate location) =>
            world.Locations.Single(l => l.Coordinate.Equals(location)).Cell;

        [Fact]
        public void World_Starts_With_Living_Cells_At_Locations()
        {
            var locationOfLivingCell = new Coordinate();
            var worldWithLife = new World(livingCoords: new Coordinate[] { locationOfLivingCell });
            Assert.IsType<LivingCell>(GetCell(worldWithLife, locationOfLivingCell));
        }

        [Theory]
        [InlineData(-1, -1, -1)]
        [InlineData(3, 3, 3)]
        public void PopulateWorld_ThrowsArgumentException_At_LocationOutOfBounds(int outOfBoundsX, int outOfBoundsY, int outOfBoundsZ)
        {
            var outOfBounds = new Coordinate(outOfBoundsX, outOfBoundsY, outOfBoundsZ);
            var worldSize = new WorldSize(3, 3, 3);
            Assert.Throws<InvalidLocation>(() => new World(worldSize: worldSize, livingCoords: new Coordinate[] { outOfBounds }));
        }

        [Fact]
        public void IsStagnant_ReturnsTrue_With_StagnantWorld()
        {
            var stagnantWorld = new World();
            Assert.True(stagnantWorld.IsStagnant());
        }

        [Fact]
        public void IsStagnant_ReturnsFalse_With_ProgressingWorld()
        {
            var worldSize = new WorldSize(3, 3);
            var locationOfLiveCells = new Coordinate[]
            {
                new Coordinate(0, 0),
             };
            var progressingWorld = new World(worldSize: worldSize, livingCoords: locationOfLiveCells);
            Assert.False(progressingWorld.IsStagnant());
        }

        [Fact]
        public void NextWorld_ReturnsEmptyWorld_On_EmptyWorld()
        {
            var emptyWorld = new World();
            Assert.Equal(emptyWorld, emptyWorld.NextWorld());
        }

        [Fact]
        public void NextWorld_ReturnsStagnantWorld_On_StagnantWorld()
        {
            var worldSize = new WorldSize(5, 5);
            var locationOfLiveCells = new Coordinate[]
            {
                new Coordinate(0, 0),
                new Coordinate(0, 1),
                new Coordinate(1, 0),
                new Coordinate(1, 1),
            };
            var stagnantWorld = new World(worldSize: worldSize, livingCoords: locationOfLiveCells);
            Assert.Equal(stagnantWorld, stagnantWorld.NextWorld());
        }

        [Fact]
        public void NextWorld_ReturnsEmptyWorld_On_UnderpopulatedWorld()
        {
            var locationOfLiveCell = new Coordinate(2, 2);
            var world = new World(livingCoords: new Coordinate[] { locationOfLiveCell });
            var expectedNextWorld = new World(livingCoords: new Coordinate[0]);
            var actualNextWorld = world.NextWorld();
            Assert.Equal(expectedNextWorld, actualNextWorld);
        }

        [Fact]
        public void NextWorld_ReturnsWorldWithLife_On_WorldWithLifeOnEdges()
        {
            var worldSize = new WorldSize(width: 3, height: 3, depth: 3);
            var locationOfLiveCells = new Coordinate[]
            {
                new Coordinate(0, 0, 0),
                new Coordinate(1, 1, 1),
                new Coordinate(2, 2, 2),
            };

            var worldWithLifeOnEdges = new World(worldSize, locationOfLiveCells);
            Array.ForEach(locationOfLiveCells, l =>
                Assert.IsType<LivingCell>(GetCell(worldWithLifeOnEdges, l)));

            var worldAllLocationsAlive = worldWithLifeOnEdges.NextWorld();
            Array.ForEach(worldAllLocationsAlive.Locations.ToArray(), l =>
                Assert.IsType<LivingCell>(GetCell(worldAllLocationsAlive, l.Coordinate)));

            var emptyWorld = worldAllLocationsAlive.NextWorld();
            Array.ForEach(emptyWorld.Locations.ToArray(), l =>
                Assert.IsType<DeadCell>(GetCell(emptyWorld, l.Coordinate)));
        }
    }
}