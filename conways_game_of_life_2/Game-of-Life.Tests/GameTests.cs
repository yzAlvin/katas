using System;
using System.IO;
using Xunit;

namespace Game_of_Life.Tests
{
    public class GameTests
    {

        // I built this test incrementally, is that still TDD? world size > rows > prints world > ticks > etc.
        [Fact]
        public void Game_Gets_World()
        {
            var worldSize = "5x4";
            var row1 = ".*...";
            var row2 = ".....";
            var row3 = ".*.*.";
            var row4 = "...*.";
            var shouldNotBeRead = "notRead";

            var expectedGenerationOne = "Generation 1: ";
            var expectedGenerationTwo = "Generation 2: ";
            var expectedGenerationThree = "Generation 3: ";
            var expectedGenerationOneWorldString = $"{row1}\n{row2}\n{row3}\n{row4}\n";
            var expectedGenerationTwoWorldString = $".....\n..*..\n..*..\n.....\n";
            var expectedGenerationThreeWorldString = $".....\n.....\n.....\n.....\n";

            var fakeInput = new FakeInput();
            var fakeOutput = new FakeOutput();
            fakeInput.SetupSequence(worldSize);
            fakeInput.SetupSequence(row1);
            fakeInput.SetupSequence(row2);
            fakeInput.SetupSequence(row3);
            fakeInput.SetupSequence(row4);
            fakeInput.SetupSequence(shouldNotBeRead);
            var game = new Game(fakeInput, fakeOutput);
            game.Run();

            Assert.Equal(1, fakeInput.readStrings[worldSize]);
            Assert.Equal(1, fakeInput.readStrings[row1]);
            Assert.Equal(1, fakeInput.readStrings[row2]);
            Assert.Equal(1, fakeInput.readStrings[row3]);

            Assert.Contains(expectedGenerationOneWorldString, fakeOutput.wroteStrings.Keys);
            Assert.Contains(expectedGenerationTwoWorldString, fakeOutput.wroteStrings.Keys);
            Assert.Contains(expectedGenerationThreeWorldString, fakeOutput.wroteStrings.Keys);

            Assert.Equal(1, fakeOutput.wroteStrings[expectedGenerationOne]);
            Assert.Equal(1, fakeOutput.wroteStrings[expectedGenerationTwo]);
            Assert.Equal(1, fakeOutput.wroteStrings[expectedGenerationThree]);

            Assert.False(fakeInput.readStrings.ContainsKey(shouldNotBeRead));
        }
    }
}