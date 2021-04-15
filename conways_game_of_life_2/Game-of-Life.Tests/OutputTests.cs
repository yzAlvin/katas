using Xunit;

namespace Game_of_Life.Tests
{
    public class FakeOutputTests
    {
        // probably unnecessary?
        [Fact]
        public void Output_Some_String()
        {
            var someString = "just a test";
            var mockWriteLine = new FakeOutput();
            mockWriteLine.WriteLine(someString);
            Assert.True(mockWriteLine.wroteStrings.ContainsKey(someString));
        }
    }
}