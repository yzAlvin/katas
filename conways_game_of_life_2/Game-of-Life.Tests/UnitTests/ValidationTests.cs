using Xunit;

namespace Game_of_Life.Tests
{
    public class ValidationTests
    {
        [Theory]
        [InlineData("-1x-1")]
        [InlineData("99x99")]
        [InlineData("0x0x0")]
        [InlineData("100x100x100")]
        public void ValidWorldSize_ReturnsTrue_On_ProperFormatWorldSize(string worldSizeString)
        {
            var worldSize = worldSizeString.Split("x");
            Assert.True(Validation.ValidWorldSize(worldSize));
        }

        [Theory]
        [InlineData("3")]
        [InlineData("1x1x1x1")]
        [InlineData("abxcdefg")]
        [InlineData("A0xH8")]
        public void ValidWorldSize_ReturnsFalse_On_ImproperFormatWorldSize(string worldSizeString)
        {
            var worldSize = worldSizeString.Split("x");
            Assert.False(Validation.ValidWorldSize(worldSize));
        }

        [Theory]
        [InlineData("0,0.1,1.2,2", "0,0.1,1.2,2")]
        [InlineData("()0,0.1 ,   1.(2, )2", "0,0.1,1.2,2")]
        [InlineData("(1,1,2) . 3,3,1 . (0,0,0)", "1,1,2.3,3,1.0,0,0")]
        [InlineData("..a1b2c.,", "..12.,")]
        public void FormatCoords_Strips_InvalidChars(string coords, string expectedFormattedCoords)
        {
            var actualFormattedCoords = Validation.FormatCoords(coords);
            Assert.Equal(expectedFormattedCoords, actualFormattedCoords);
        }

        [Theory]
        [InlineData("0,0.1,1.2,2")]
        [InlineData("0,0,0.1,1,1.2,2,2")]
        public void ValidCoords_ReturnsTrue_On_ProperFormatCoords(string formattedCoords)
        {
            var worldSize = new WorldSize(3, 3, 3);
            Assert.True(Validation.ValidCoords(formattedCoords, worldSize));
        }

        [Theory]
        [InlineData("0, 0 . 1,1 . 2,2")]
        [InlineData("0,0,0 . 1,1,1 . 2,2,2")]
        public void ValidCoords_ReturnsFalse_On_ImproperFormatCoords(string formattedCoords)
        {
            var worldSize = new WorldSize(3, 3, 3);
            Assert.False(Validation.ValidCoords(formattedCoords, worldSize));
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