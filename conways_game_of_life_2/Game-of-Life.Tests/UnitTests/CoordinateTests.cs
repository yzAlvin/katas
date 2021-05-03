using System;
using Xunit;

namespace Game_of_Life.Tests
{
    public class CoordinateTests
    {
        [Fact]
        public void Neighbours_Returns_Collection_Of_Surrounding_Locations_On_2D()
        {
            var some2DCoordinate = new Coordinate(0, 0);
            var expectedNeighbours = new Coordinate[]
            {
                new Coordinate(-1, -1),
                new Coordinate(-1, 0),
                new Coordinate(-1, 1),
                new Coordinate(0, -1),
                new Coordinate(0, 1),
                new Coordinate(1, -1),
                new Coordinate(1, 0),
                new Coordinate(1, 1),
            };
            var actualNeighbours = some2DCoordinate.Neighbours();
            Array.ForEach(expectedNeighbours, n => Assert.Contains(n, actualNeighbours));
        }

        [Fact]
        public void Neighbours_Returns_Collection_Of_Surrounding_Locations()
        {
            var some3DCoordinate = new Coordinate(0, 0, 0);
            var expectedNeighbours = new Coordinate[]
            {
                new Coordinate(-1, -1, -1),
                new Coordinate(-1, -1, 0),
                new Coordinate(-1, -1, 1),
                new Coordinate(-1, 0, -1),
                new Coordinate(-1, 0, 0),
                new Coordinate(-1, 0, 1),
                new Coordinate(-1, 1, -1),
                new Coordinate(-1, 1, 0),
                new Coordinate(-1, 1, 1),

                new Coordinate(0, -1, -1),
                new Coordinate(0, -1, 0),
                new Coordinate(0, -1, 1),
                new Coordinate(0, 0, -1),
                new Coordinate(0, 0, 1),
                new Coordinate(0, 1, -1),
                new Coordinate(0, 1, 0),
                new Coordinate(0, 1, 1),

                new Coordinate(1, -1, -1),
                new Coordinate(1, -1, 0),
                new Coordinate(1, -1, 1),
                new Coordinate(1, 0, -1),
                new Coordinate(1, 0, 0),
                new Coordinate(1, 0, 1),
                new Coordinate(1, 1, -1),
                new Coordinate(1, 1, 0),
                new Coordinate(1, 1, 1),
            };
            var actualNeighbours = some3DCoordinate.Neighbours();
            Assert.Equal(expectedNeighbours, actualNeighbours);
        }

        [Fact]
        public void WrapCoordinate_Returns_LowerCoordinate_Wrapped_By_UpperBound()
        {
            var someCoordinate = new Coordinate(-1, -1, -1);
            var expectedWrappedCoordinate = new Coordinate(2, 2, 2);
            var actualWrappedCoordinate = someCoordinate.WrapCoordinate(new WorldSize(3, 3, 3));
            Assert.Equal(expectedWrappedCoordinate, actualWrappedCoordinate);
        }

        [Fact]
        public void WrapCoordinate_Returns_HigherCoordinate_Wrapped_By_UpperBound()
        {
            var someCoordinate = new Coordinate(3, 3, 3);
            var expectedWrappedCoordinate = new Coordinate(0, 0, 0);
            var actualWrappedCoordinate = someCoordinate.WrapCoordinate(new WorldSize(3, 3, 3));
            Assert.Equal(expectedWrappedCoordinate, actualWrappedCoordinate);
        }

        [Fact]
        public void Equals_ReturnsTrue_Comparing_Locations_With_Same_Location()
        {
            var someCoordinate = new Coordinate(0, 0, 0);
            var anotherCoordinate = new Coordinate(0, 0, 0);
            Assert.Equal(someCoordinate, anotherCoordinate);
        }

        [Fact]
        public void Equals_ReturnsFalse_Comparing_Locations_With_Different_Location()
        {
            var someCoordinate = new Coordinate(0, 0, 0);
            var anotherDifferentCoordinate = new Coordinate(0, 0, 1);
            Assert.NotEqual(someCoordinate, anotherDifferentCoordinate);
        }

        [Fact]
        public void Equals_ReturnsFalse_Comparing_Location3D_With_NotLocation3D()
        {
            var someCoordinate = new Coordinate();
            var notACoordinate = new Object();
            Assert.NotEqual(someCoordinate, notACoordinate);
        }


    }
}