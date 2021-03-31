using Xunit;
using Moq;
using System.IO;

namespace minesweeper.Tests
{
    public class InputTests
    {
        [Theory]
        [InlineData("44")]
        [InlineData("35")]
        [InlineData("00")]
        public void RequestFieldDimensions(string expectedDimensions)
        {
            var mockReadLine = Mock.Of<TextReader>(x => x.ReadLine() == expectedDimensions);
            var consoleInput = new Input(mockReadLine);
            
            Assert.Equal(expectedDimensions, consoleInput.ReadLine());
        }
    }
}