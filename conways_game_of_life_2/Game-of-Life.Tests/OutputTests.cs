using Xunit;

namespace Game_of_Life.Tests
{
    public class FakeOutputTests
    {
        // probably unnecessary?
        // don't test builtin c# functions so maybe I don't need these classes
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