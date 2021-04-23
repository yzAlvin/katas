using System;
using Xunit;

namespace Game_of_Life.Tests
{
    public class LocationTests
    {
        Location2D someLocation = new Location2D(0, 0);

        [Fact]
        public void BecomeAlive_Sets_DeadCell_To_LivingCell()
        {
            var deadCellToBecomeAlive = someLocation;
            deadCellToBecomeAlive.BecomeAlive();
            Assert.IsType<LivingCell>(deadCellToBecomeAlive.Cell);
        } 
        
        [Fact]
        public void BecomeAlive_Sets_LivingCell_To_LivingCell()
        {
            var livingCellToStayAlive = someLocation;
            livingCellToStayAlive.BecomeAlive();
            Assert.IsType<LivingCell>(livingCellToStayAlive.Cell);
        } 

        [Fact]
        public void BecomeDead_Sets_DeadCell_To_DeadCell()
        {
            var deadCellToStayDead = someLocation;
            deadCellToStayDead.BecomeDead();
            Assert.IsType<DeadCell>(deadCellToStayDead.Cell);
        } 

        [Fact]
        public void BecomeDead_Sets_LivingCell_To_DeadCell()
        {
            var livingCellToBecomeDead = someLocation;
            livingCellToBecomeDead.BecomeDead();
            Assert.IsType<DeadCell>(livingCellToBecomeDead.Cell);
        } 

        [Fact]
        public void Equals_ReturnsTrue_Comparing_Locations_With_Same_Location()
        {
            
            var anotherLocationWithSameCoordinates = someLocation;
            Assert.True(someLocation.Equals(anotherLocationWithSameCoordinates));
        }

        [Fact]
        public void Equals_ReturnsFalse_Comparing_Locations_With_Different_Location()
        {
            var anotherLocationWithDifferentCoordinates = new Location2D(0, 1);
            Assert.False(someLocation.Equals(anotherLocationWithDifferentCoordinates));
        }

        [Fact]
        public void Equals_ReturnsFalse_Comparing_Location2D_With_NotLocation2D()
        {
            var notALocation = new Object();
            Assert.False(someLocation.Equals(notALocation));
        }

        [Fact]
        public void Neighbours_Returns_Collection_Of_Surrounding_Locations()
        {
            var expectedNeighbours = new Location2D[]
            {
                new Location2D(-1, -1),
                new Location2D(-1, 0),
                new Location2D(-1, 1),
                new Location2D(0, -1),
                new Location2D(0, 1),
                new Location2D(1, -1),
                new Location2D(1, 0),
                new Location2D(1, 1),
            };
            var actualNeighbours = someLocation.Neighbours();
            Assert.Equal(expectedNeighbours, actualNeighbours);
        }

    }
}