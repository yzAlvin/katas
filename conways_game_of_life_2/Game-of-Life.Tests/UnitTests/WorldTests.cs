using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Game_of_Life.Tests
{
    public class WorldTests
    {


        [Fact]
        public void IsEmpty_ReturnsTrue_With_NewWorld()
        {
            var emptyWorld = new World();
            Assert.True(emptyWorld.IsEmpty());
        }


        private ICell GetCell(World world, ILocation location) => world.Locations.Single(l => l.Equals(location)).Cell;
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
            var worldSize = new WorldSize(depth: 3);
            var worldWithLife = new World(worldSize: worldSize, locationOfLiveCells: locationOfLife);
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
            var worldSize = new WorldSize(depth: 3);
            Assert.Throws<ArgumentException>(() => new World(worldSize: worldSize, locationOfLiveCells: new ILocation[]{outOfBounds}));
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
            var worldSize = new WorldSize(depth: 3);
            var world = new World(worldSize: worldSize, locationOfLiveCells: locationOfLife);
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
            var worldSize = new WorldSize(depth: 3);
            var world = new World(worldSize: worldSize, locationOfLiveCells: new ILocation[]{location});
            var expectedNextWorld = new World(worldSize: worldSize, locationOfLiveCells: new ILocation[0]);
            var actualNextWorld = world.NextWorld();
            Assert.Equal(expectedNextWorld, actualNextWorld);
        }

        [Fact]
        public void Tick_WorldWithLifeOnEdges_Updates_NextGeneration()
        {
            var liveCellLocations = new Location2D[]{new Location2D(0, 0), new Location2D(0, 1), new Location2D(4, 4)};
            var worldSize = new WorldSize(width: 5, height: 5);
            var world = new World(worldSize: worldSize, locationOfLiveCells: liveCellLocations);

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
            var worldSize = new WorldSize(width: 4, height: 4, depth: 3);
            var world = new World(worldSize: worldSize, locationOfLiveCells: liveCellLocations);

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