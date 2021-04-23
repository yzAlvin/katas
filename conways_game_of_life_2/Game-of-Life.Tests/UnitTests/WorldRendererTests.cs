using Xunit;

namespace Game_of_Life.Tests
{
    public class WorldRendererTests
    {
        [Fact]
        public void RenderWorld_Returns_2DEmpty_World()
        {
            var expectedOutput = "...\n...\n...\n";
            var emptyWorld = new World(3, 3);
            
            var actualOutput = WorldRenderer.RenderWorld(emptyWorld);
            
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void RenderWorld_Returns_2DWorld_With_Life()
        {
            var expectedOutput = ".*.\n*..\n..*\n";
            var worldWithLife = new World(3, 3);
            var liveCellLocations = new Location2D[]{new Location2D(0, 1), new Location2D(1, 0), new Location2D(2, 2)};

            worldWithLife.SetLivingAt(liveCellLocations);
            var actualOutput = WorldRenderer.RenderWorld(worldWithLife);

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact (Skip = "t")]
        public void RenderWorld_Returns_3DEmpty_World()
        {
            var expectedWorld = "...\n...\n...\n";
            var empty3DWorld = new World(3, 3, 3);

            var actualWorld = WorldRenderer.RenderWorld(empty3DWorld);

            Assert.Equal(expectedWorld, actualWorld);
        }
    }
}