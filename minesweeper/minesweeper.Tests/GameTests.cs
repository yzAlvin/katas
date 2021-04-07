using System.IO;
using Moq;
using Xunit;
namespace minesweeper.Tests
{
    public class GameTests
    {
        [Fact]
        public void Game_Mock_ConsoleInput_And_Mock_WriteFields_To_Console()
        {
            var expectedFirstHeader = "Field #1: ";
            var expectedFirstField = "*100\n2210\n1*10\n1110";
            
            var expectedSecondHeader = "Field #2: ";
            var expectedSecondField = "**100\n33200\n1*100";

            var mockInputStream = new Mock<TextReader>();
            mockInputStream.SetupSequence(i => i.ReadLine())
                .Returns("44")
                .Returns("*...")
                .Returns("....")
                .Returns(".*..")
                .Returns("....")
                .Returns("35")
                .Returns("**...")
                .Returns(".....")
                .Returns(".*...")
                .Returns("00");
            var mockOutputStream = new Mock<TextWriter>();

            var consoleReader = new Input(mockInputStream.Object);
            var consoleWriter = new Output(mockOutputStream.Object);
            var game = new Game(consoleReader, consoleWriter);
            
            game.Play();
            
            mockOutputStream.Verify(m => m.WriteLine(expectedFirstHeader), Times.Once);
            mockOutputStream.Verify(m => m.WriteLine(expectedFirstField), Times.Once);
            mockOutputStream.Verify(m => m.WriteLine(expectedSecondHeader), Times.Once);
            mockOutputStream.Verify(m => m.WriteLine(expectedSecondField), Times.Once);
        }
    }
}