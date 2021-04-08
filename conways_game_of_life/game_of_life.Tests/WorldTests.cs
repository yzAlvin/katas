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
    }
}
