using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Game_of_Life.Tests
{
    public class WorldTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(101)]
        public void World_ThrowsArgumentException_With_Negative_Sizes(int badSize)
        {
            Assert.Throws<ArgumentException>(() => new World(width: badSize));
            Assert.Throws<ArgumentException>(() => new World(height: badSize));
            Assert.Throws<ArgumentException>(() => new World(depth: badSize));
        }

        [Fact]
        public void IsEmpty_ReturnsTrue_With_NewWorld()
        {
            var emptyWorld = new World();
            Assert.True(emptyWorld.IsEmpty());
        }


        public ICell GetCell(World world, ILocation location) => world.Locations.Single(l => l.Equals(location)).Cell;
        [Fact]
        public void World_CreatesLivingCell_At_Location()
        {
            var locationOfLife = new ILocation[]{new Location2D(1, 1)};
            var worldWithLife = new World(locationOfLiveCells: locationOfLife);
            Assert.IsType<LivingCell>(GetCell(worldWithLife, new Location2D(1, 1)));
        }

        [Fact]
        public void World_CreatesLivingCell_At_3DLocation()
        {
            var location = new Location3D(1, 1, 1);
            var locationOfLife = new ILocation[]{location};
            var worldWithLife = new World(depth: 3, locationOfLiveCells: locationOfLife);
            Assert.IsType<LivingCell>(GetCell(worldWithLife, location));
        }

        [Fact]
        public void SetLivingAt_ThrowsArgumentException_At_LocationOutOfBounds()
        {
            var outOfBounds = new Location2D(5, 5);
            Assert.Throws<ArgumentException>(() => new World(locationOfLiveCells: new ILocation[]{outOfBounds}));
        }

        [Fact]
        public void SetLivingAt_ThrowsArgumentException_At_3DLocationOutOfBounds()
        {
            var outOfBounds = new Location3D(0, 0, 4);
            Assert.Throws<ArgumentException>(() => new World(depth: 3, locationOfLiveCells: new ILocation[]{outOfBounds}));
        }

        [Fact]
        public void IsEmpty_ReturnsFalse_With_WorldWithLivingCells()
        {
            var location = new Location2D(0, 0);
            var locationOfLife = new ILocation[]{location};
            var world = new World(locationOfLiveCells: locationOfLife);
            Assert.False(world.IsEmpty());
        }

        [Fact]
        public void IsEmpty_ReturnsFalse_With_WorldWith3DLivingCells()
        {
            var location = new Location3D(0, 0, 2);
            var locationOfLife = new ILocation[]{location};
            var world = new World(depth: 3, locationOfLiveCells: locationOfLife);
            Assert.False(world.IsEmpty());
        }

        [Fact]
        public void Tick_EmptyWorld_Is_Empty_NextGeneration()
        {
            var world = new World();
            world = world.NextWorld();
            Assert.True(world.IsEmpty());
        }

        [Fact]
        public void Tick_WorldWithLife_Updates_NextGeneration()
        {
            var location = new Location2D(2, 2);
            var world = new World(locationOfLiveCells: new ILocation[]{location});
            var expectedNextWorld = new World(locationOfLiveCells: new ILocation[0]);
            var actualNextWorld = world.NextWorld();
            Assert.Equal(expectedNextWorld, actualNextWorld);
        }

        [Fact]
        public void Tick_3DWorldWithLife_Updates_NextGeneration()
        {
            var location = new Location3D(2, 2, 2);
            var world = new World(depth: 3, locationOfLiveCells: new ILocation[]{location});
            var expectedNextWorld = new World(depth: 3, locationOfLiveCells: new ILocation[0]);
            var actualNextWorld = world.NextWorld();
            Assert.Equal(expectedNextWorld, actualNextWorld);
        }

        [Fact]
        public void Tick_WorldWithLifeOnEdges_Updates_NextGeneration()
        {
            var liveCellLocations = new Location2D[]{new Location2D(0, 0), new Location2D(0, 1), new Location2D(4, 4)};
            var world = new World(5, 5, locationOfLiveCells: liveCellLocations);

            Array.ForEach(liveCellLocations, locationOfLife => Assert.IsType<LivingCell>(GetCell(world, locationOfLife)));
            
            world = world.NextWorld(); 
            var locationOfStillLife = new Location2D(0, 0);
            var locationOfNewLife = new Location2D(4, 0);
            Assert.IsType<LivingCell>(GetCell(world, locationOfNewLife));
            Assert.IsType<LivingCell>(GetCell(world, locationOfStillLife));

            world = world.NextWorld(); 
            Assert.True(world.IsEmpty());
        }

        [Fact]
        public void Tick_3DWorldWithLifeOnEdges_Updates_NextGeneration()
        {
            var liveCellLocations = new Location3D[]{new Location3D(0, 0, 0), new Location3D(0, 1, 0), new Location3D(1, 0, 0), new Location3D(0, 0, 1)};
            var world = new World(4, 4, 3, locationOfLiveCells: liveCellLocations);

            Array.ForEach(liveCellLocations, locationOfLife => Assert.IsType<LivingCell>(GetCell(world, locationOfLife)));
            
            world = world.NextWorld(); 
            var newLiveCellLocations = new Location3D[]{new Location3D(0, 3, 0), new Location3D(0, 3, 1), new Location3D(1, 3, 0), new Location3D(1, 3, 1), new Location3D(3, 0, 0), new Location3D(3, 0, 1), new Location3D(3, 1, 0), new Location3D(3, 1, 1)};
            var locationOfDead = new Location3D(1, 1, 1);
            Array.ForEach(liveCellLocations, locationOfLife => Assert.IsType<LivingCell>(GetCell(world, locationOfLife)));
            Array.ForEach(newLiveCellLocations, locationOfLife => Assert.IsType<LivingCell>(GetCell(world, locationOfLife)));
            Assert.IsType<DeadCell>(GetCell(world, locationOfDead));
        }
    }
}