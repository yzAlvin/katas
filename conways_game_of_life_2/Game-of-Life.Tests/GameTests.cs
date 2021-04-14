using Xunit;

namespace Game_of_Life.Tests
{
    public class GameTests
    {
        [Fact]
        public void Game_Mock_TextReader_And_TextWriter()
        {
            var expectedInput = "3x3";
            var fakeInput = new FakeInput();
            fakeInput.SetupSequence(expectedInput);
            var game = new Game(fakeInput);
            game.Run();
            Assert.Equal(1, fakeInput.readStrings[expectedInput]);
        }
    }
}