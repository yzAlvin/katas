using Xunit;

namespace Game_of_Life.Tests
{
    public class WorldRendererTests
    {
        [Fact]
        public void WorldRenderer_Writes_Empty_World()
        {
            var expectedOutput = "...\n...\n...\n";
            var emptyWorld = new World(3, 3);
            Assert.Equal(expectedOutput, WorldRenderer.DisplayWorld(emptyWorld));

        }

        [Fact]
        public void WorldRenderer_Writes_World_With_Life()
        {
            var expectedOutput = ".*.\n*..\n..*\n";
            var worldWithLife = new World(3, 3);
            // should I overload the SetLivingAtLocation to take in an enumerable of locations and populate all of them? thereby condensing the next 6 lines into 2k
            var firstLiveCell = new Location(0, 1);
            var secondLiveCell = new Location(1, 0);
            var thirdLiveCell = new Location(2, 2);
            worldWithLife.SetLivingAt(firstLiveCell);
            worldWithLife.SetLivingAt(secondLiveCell);
            worldWithLife.SetLivingAt(thirdLiveCell);            
            var actualOutput = WorldRenderer.DisplayWorld(worldWithLife);

            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}