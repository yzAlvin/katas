using System;
using Xunit;

namespace Game_of_Life.Tests
{
    public class Location3DTests
    {
        [Fact]
        public void BecomeAlive_Sets_DeadCell_To_LivingCell()
        {
            var deadCellToBecomeAlive = new Location(); 
            deadCellToBecomeAlive.BecomeAlive();
            Assert.IsType<LivingCell>(deadCellToBecomeAlive.Cell);
        } 
        
        [Fact]
        public void BecomeAlive_Sets_LivingCell_To_LivingCell()
        {
            var livingCellToStayAlive = new Location(); 
            livingCellToStayAlive.BecomeAlive();
            livingCellToStayAlive.BecomeAlive();
            Assert.IsType<LivingCell>(livingCellToStayAlive.Cell);
        } 

        [Fact]
        public void BecomeDead_Sets_DeadCell_To_DeadCell()
        {
            var deadCellToStayDead = new Location(); 
            deadCellToStayDead.BecomeDead();
            Assert.IsType<DeadCell>(deadCellToStayDead.Cell);
        } 

        [Fact]
        public void BecomeDead_Sets_LivingCell_To_DeadCell()
        {
            var livingCellToBecomeDead = new Location(); 
            livingCellToBecomeDead.BecomeDead();
            Assert.IsType<DeadCell>(livingCellToBecomeDead.Cell);
        }

        [Fact]
        public void Equals_ReturnsTrue_Comparing_Locations_With_Same_Location()
        {
            var someLocation = new Location(0, 0, 0);
            var anotherLocationWithSameCoordinates = new Location(0, 0, 0); 
            Assert.Equal(someLocation, anotherLocationWithSameCoordinates);
        }

        [Fact]
        public void Equals_ReturnsFalse_Comparing_Locations_With_Different_Location()
        {
            var someLocation = new Location(0, 0, 0);
            var anotherLocationWithDifferentCoordinates = new Location(0, 0, 1);
            Assert.NotEqual(someLocation, anotherLocationWithDifferentCoordinates);
        }

        [Fact]
        public void Equals_ReturnsFalse_Comparing_Location3D_With_NotLocation3D()
        {
            var someLocation = new Location();
            var notALocation = new Object();
            Assert.NotEqual(someLocation, notALocation);
        }

        [Fact]
        public void Neighbours_Returns_Collection_Of_Surrounding_Locations()
        {
            var someLocation = new Location(0, 0, 0);
            var expectedNeighbours = new Location[]
            {
                new Location(-1, -1, -1),
                new Location(-1, -1, 0),
                new Location(-1, -1, 1),
                new Location(-1, 0, -1),
                new Location(-1, 0, 0),
                new Location(-1, 0, 1),
                new Location(-1, 1, -1),
                new Location(-1, 1, 0),
                new Location(-1, 1, 1),

                new Location(0, -1, -1),
                new Location(0, -1, 0),
                new Location(0, -1, 1),
                new Location(0, 0, -1),
                new Location(0, 0, 1),
                new Location(0, 1, -1),
                new Location(0, 1, 0),
                new Location(0, 1, 1),

                new Location(1, -1, -1),
                new Location(1, -1, 0),
                new Location(1, -1, 1),
                new Location(1, 0, -1),
                new Location(1, 0, 0),
                new Location(1, 0, 1),
                new Location(1, 1, -1),
                new Location(1, 1, 0),
                new Location(1, 1, 1),
            };
            var actualNeighbours = someLocation.Neighbours();
            Assert.Equal(expectedNeighbours, actualNeighbours);
        }
    }
}