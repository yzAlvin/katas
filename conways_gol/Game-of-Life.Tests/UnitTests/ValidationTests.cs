using Xunit;

namespace Game_of_Life.Tests
{
    public class ValidationTests
    {
        [Theory]
        [InlineData("99x99")]
        [InlineData("0x0x0")]
        [InlineData("100x100x100")]
        public void ValidWorldSize_ReturnsTrue_On_ProperFormatWorldSize(string worldSize)
        {
            Assert.True(Validation.ValidWorldSize(worldSize));
        }

        [Theory]
        [InlineData("3")]
        [InlineData("-1x-1")]
        [InlineData("1x1x1x1")]
        [InlineData("abxcdefg")]
        [InlineData("A0xH8")]
        public void ValidWorldSize_ReturnsFalse_On_ImproperFormatWorldSize(string worldSize)
        {
            Assert.False(Validation.ValidWorldSize(worldSize));
        }

        /*
            Leaving this test to give an example of writing a test to
            implement something that I realise later that I don't need to 
            test because it is covered by the test I really want to write.
            just like Kent Beck describes in TDD by example
        */

        // [Theory]
        // [InlineData("0,0.1,1.2,2", "0,0.1,1.2,2")]
        // [InlineData("()0,0.1 ,   1.(2, )2", "0,0.1,1.2,2")]
        // [InlineData("(1,1,2) . 3,3,1 . (0,0,0)", "1,1,2.3,3,1.0,0,0")]
        // [InlineData("..a1b2c.,", "..12.,")]
        // public void FormatCoords_Strips_InvalidChars(string coords, string expectedFormattedCoords)
        // {
        //     var actualFormattedCoords = Validation.FormatCoords(coords);
        //     Assert.Equal(expectedFormattedCoords, actualFormattedCoords);
        // }

        [Theory]
        [InlineData("0,0.1,1.2,2")]
        [InlineData("0,0,0.1,1,1.2,2,2")]
        [InlineData("0, 0 . 1,1 . 2,2")]
        [InlineData("0,0,0 . 1,1,1 . 2,2,2")]
        public void ValidCoords_ReturnsTrue_On_AnyFormatCoords(string formattedCoords)
        {
            var worldSize = new WorldSize(3, 3, 3);
            Assert.True(Validation.ValidCoords(formattedCoords, worldSize));
        }

        [Theory]
        [InlineData("3,3")]
        [InlineData("0,0.1,1.-1,-1")]
        public void ValidCoords_ReturnsFalse_On_CoordsOutOfBounds(string formattedCoords)
        {
            var worldSize = new WorldSize(3, 3, 3);
            Assert.False(Validation.ValidCoords(formattedCoords, worldSize));
        }
    }
}