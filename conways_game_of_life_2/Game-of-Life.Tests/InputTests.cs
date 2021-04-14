using Xunit;

namespace Game_of_Life.Tests
{
    public class InputTests
    {
        [Theory]
        [InlineData("3x3")]
        [InlineData("...\n...\n...")]
        public void Input_Some_String(string someString)
        {
            var mockReadLine = new FakeInput();
            mockReadLine.SetupSequence(someString);
            Assert.Equal(someString, mockReadLine.ReadLine());
            Assert.Equal(1, mockReadLine.readStrings[someString]);
        }
    }
}