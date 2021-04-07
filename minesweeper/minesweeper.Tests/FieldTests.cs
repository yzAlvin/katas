using System.Linq;
using Xunit;

namespace minesweeper.Tests
{
    public class FieldTests
    {
        [Fact]
        public void Field_Contains_Correct_Cell_Count()
        {
            var field = new Field(4, 4);
            Assert.Equal(16, field.Cells.Count);
        }

        [Fact]
        public void Field_Contains_No_Mines_At_Start()
        {
            var field = new Field(4, 4);
            Assert.True(field.Cells.All(c => !c.IsMine));
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 0)]
        [InlineData(1, 2)]
        public void Field_Sets_Mines_At_Location(int x, int y)
        {
            var field = new Field(4, 4);
            Location mineLocation = new Location(x, y);
            field.SetMine(mineLocation);
            
            Assert.True(field.GetCell(mineLocation).IsMine);
        }
        
        [Theory]
        //corners
        [InlineData(0, 0, 3)]
        [InlineData(2, 0, 3)]
        [InlineData(0, 2, 3)]
        [InlineData(2, 2, 3)]
        //edges and not corner
        [InlineData(0, 1, 5)]
        [InlineData(1, 0, 5)]
        [InlineData(1, 2, 5)]
        [InlineData(2, 1, 5)]
        //middle
        [InlineData(1, 1, 8)]
        public void Field_Gets_Neighbouring_Cells_Of_A_Location(int x, int y, int expectedNeighbourCount)
        {
            var field = new Field(3, 3);

            var neighbouringCells = field.GetNeighbouringCells(new Location(x, y));
            
            Assert.Equal(expectedNeighbourCount, neighbouringCells.Count());
        }

        [Theory]
        [InlineData(2, 0, 1)]
        [InlineData(3, 0, 0)]
        [InlineData(4, 0, 0)]
        [InlineData(0, 1, 3)]
        [InlineData(1, 1, 3)]
        [InlineData(2, 1, 2)]
        [InlineData(3, 1, 0)]
        [InlineData(4, 1, 0)]
        [InlineData(0, 2, 1)]
        [InlineData(2, 2, 1)]
        [InlineData(3, 2, 0)]
        [InlineData(4, 2, 0)]
        public void Field_Calculates_Number_Of_Neighbouring_Mines(int x, int y, int expectedNeighbourMinesCount)
        {
            var field = new Field(3, 5);
            
            field.SetMine(new Location(0, 0)); // **100
            field.SetMine(new Location(1, 0)); // 33200
            field.SetMine(new Location(1, 2)); // 1*100
            
            Assert.Equal(expectedNeighbourMinesCount, field.CountNeighbouringMines(new Location(x, y)));
        }
    }
}