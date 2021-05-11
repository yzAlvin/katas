using System;
using Xunit;

namespace Game_of_Life.Tests
{
    public class WorldRendererTests
    {
        [Fact]
        public void RenderWorld_Returns_2DEmpty_World()
        {
            var expectedOutput = "...\n...\n...\n";
            var worldSize = new WorldSize(width: 3, height: 3);
            var emptyWorld = new World(worldSize: worldSize);

            var actualOutput = WorldRenderer.RenderWorld(emptyWorld);

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void RenderWorld_Returns_2DWorld_With_Life()
        {
            var expectedOutput = ".*.\n*..\n..*\n";
            var worldSize = new WorldSize(width: 3, height: 3);
            var liveLocations = new Location[] { new Location(new Coordinate(0, 1)), new Location(new Coordinate(1, 0)), new Location(new Coordinate(2, 2)) };
            var worldWithLife = new World(worldSize: worldSize, liveLocations: liveLocations);
            var actualOutput = WorldRenderer.RenderWorld(worldWithLife);

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void RenderWorld_Returns_3DEmpty_World()
        {
            var expectedWorld = "..|..|..|..\n..|..|..|..\n";
            var worldSize = new WorldSize(width: 2, height: 2, depth: 4);
            var empty3DWorld = new World(worldSize: worldSize);

            var actualWorld = WorldRenderer.RenderWorld(empty3DWorld);
            Assert.Equal(expectedWorld, actualWorld);
        }

        [Fact]
        public void RenderWorld_Returns_3DWorld_With_Life()
        {
            var expectedWorld = "*..|...|...\n...|.*.|.*.\n*..|..*|..*\n";
            var worldSize = new WorldSize(width: 3, height: 3, depth: 3);
            var liveLocations = new Location[]
            {
                new Location(new Coordinate(0, 0, 0)),
                new Location(new Coordinate(2, 0, 0)),
                new Location(new Coordinate(1, 1, 1)),
                new Location(new Coordinate(2, 2, 1)),
                new Location(new Coordinate(1, 1, 2)),
                new Location(new Coordinate(2, 2, 2)),

            };
            var worldWithLife = new World(worldSize: worldSize, liveLocations: liveLocations);

            var actualWorld = WorldRenderer.RenderWorld(worldWithLife);
            Assert.Equal(expectedWorld, actualWorld);
        }
    }
}