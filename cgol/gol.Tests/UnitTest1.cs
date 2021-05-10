using System.Collections;
using System;
using Xunit;
using System.Collections.Generic;

namespace gol.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Size_Of_World_Should_Not_Change()
        {
            var world = new World(3, 4, new List<Location>());
            Assert.Equal(world, world.NextGeneration());
        }

        [Fact]
        public void Live_Cell_Should_Stay_Alive_When_2_Neighbours_Around()
        {
            var liveCells = new List<Location>(){new Location(1, 2), new Location(2, 2), new Location(3, 2)};
            var world = new World(5, 4, liveCells).NextGeneration();
            Assert.Contains(new Location(2,2), world.liveCells);
        }

        [Fact]
        public void Live_Cell_Should_Die_When_Underpopulation()
        {
            var liveCells = new List<Location>(){new Location(1, 1), new Location(1, 2)};
            var world = new World(5, 4, liveCells).NextGeneration();
            Assert.DoesNotContain(new Location(1, 1), world.liveCells);
        }
    }
}
