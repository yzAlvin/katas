using System;
using Xunit;
using Moq;
using System.IO;

namespace game_of_life.Tests
{
    public class InputTests
    {
        [Theory]
        [InlineData("3x3")]
        [InlineData("...\n.*.\n...")]
        public void Can_Input_Some_Text(string someText)
        {
            var mockReadLine = Mock.Of<TextReader>(x => x.ReadLine() == someText);
            var consoleInput = new Input(mockReadLine);

            Assert.Equal(someText, consoleInput.ReadLine());
        }
    }
}
