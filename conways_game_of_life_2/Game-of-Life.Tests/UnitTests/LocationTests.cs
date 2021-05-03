using System;
using Xunit;

namespace Game_of_Life.Tests
{
    public class LocationTests
    {
        [Fact]
        public void BecomeAlive_Sets_DeadCell_To_LivingCell()
        {
            var deadLocation = new Location();
            var aliveLocation = deadLocation.BecomeAlive();
            Assert.IsType<LivingCell>(aliveLocation.Cell);
        }

        [Fact]
        public void BecomeAlive_Sets_LivingCell_To_LivingCell()
        {
            var deadLocation = new Location();
            var aliveLocation = deadLocation.BecomeAlive();
            var stillAliveLocation = aliveLocation.BecomeAlive();
            Assert.IsType<LivingCell>(stillAliveLocation.Cell);
        }

        [Fact]
        public void BecomeDead_Sets_DeadCell_To_DeadCell()
        {
            var deadLocation = new Location();
            var stillDeadLocation = deadLocation.BecomeDead();
            Assert.IsType<DeadCell>(stillDeadLocation.Cell);
        }

        [Fact]
        public void BecomeDead_Sets_LivingCell_To_DeadCell()
        {
            var deadLocation = new Location();
            var aliveLocation = deadLocation.BecomeAlive();
            var nowDeadLocation = aliveLocation.BecomeDead();
            Assert.IsType<DeadCell>(nowDeadLocation.Cell);
        }

        [Fact]
        public void Equals_ReturnsTrue_Comparing_Locations_With_Same_Location()
        {
            var someLocation = new Location();
            var anotherLocationWithSameCoordinates = new Location();
            Assert.Equal(someLocation, anotherLocationWithSameCoordinates);
        }

        [Fact]
        public void Equals_ReturnsFalse_Comparing_Locations_With_Different_Location()
        {
            var someCoordinate = new Coordinate(0, 0, 0);
            var someLocation = new Location(someCoordinate);
            var anotherLocationWithDifferentCoordinates = new Location(new Coordinate(0, 0, 1));
            Assert.NotEqual(someLocation, anotherLocationWithDifferentCoordinates);
        }

        [Fact]
        public void Equals_ReturnsFalse_Comparing_Location3D_With_NotLocation3D()
        {
            var someLocation = new Location();
            var notALocation = new Object();
            Assert.NotEqual(someLocation, notALocation);
        }

    }
}